using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using K12.Data;
using DevComponents.DotNetBar;
using FISCA.Data;
using FISCA.UDT;
using FISCA.LogAgent;
using FISCA.Permission;
using Campus.Windows;
using Aspose.Cells;
using AccessControlCardCHT.UDT;

namespace AccessControlCardCHT
{
    //社團的學生增減
    //必須有另一個背景模式進行處理
    [FISCA.Permission.FeatureCode("AccessControlCardCHT.StudentExtendControls.AccessStudent.cs", "門禁刷卡歷程(中華電信)")]
    public partial class AccessStudentItem : DetailContentBase
    {
        /// <summary>
        /// 畫面資料取得
        /// </summary>
        private BackgroundWorker BGW = new BackgroundWorker();
        /// <summary>
        /// 儲存功能
        /// </summary>
        private BackgroundWorker Save_BGW = new BackgroundWorker();

        private bool BkWBool = false;

        QueryHelper _Q = new QueryHelper();
        AccessHelper _A = new AccessHelper();

        //權限
        internal static FeatureAce UserPermission;

        string CarNo = "";
        StudentRecord _Record;
        AccessControlCard _AccessControlCard;
        List<AccessExtendRecord> AccessRecordList;
        ChangeListener _ChangeListener = new ChangeListener();

        public AccessStudentItem()
        {
            InitializeComponent();

            Group = "門禁刷卡歷程(中華電信)";

            UserPermission = UserAcl.Current[FISCA.Permission.FeatureCodeAttribute.GetCode(GetType())];
            this.Enabled = UserPermission.Editable;

            //背景模式取得學生
            BGW.DoWork += new DoWorkEventHandler(BGW_DoWork);
            BGW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BGW_RunWorkerCompleted);

            Save_BGW.DoWork += new DoWorkEventHandler(Save_BGW_DoWork);
            Save_BGW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Save_BGW_RunWorkerCompleted);


            _ChangeListener.Add(new TextBoxSource(textBoxX1));

            _ChangeListener.StatusChanged += new EventHandler<ChangeEventArgs>(_ChangeListener_StatusChanged);
        }

        void _ChangeListener_StatusChanged(object sender, ChangeEventArgs e)
        {
            SaveButtonVisible = (e.Status == ValueStatus.Dirty);
            CancelButtonVisible = (e.Status == ValueStatus.Dirty);
        }

        /// <summary>
        /// 按下儲存時
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSaveButtonClick(EventArgs e)
        {
            if (Save_BGW.IsBusy)
            {
                MsgBox.Show("系統忙碌中...");
                return;
            }

            Save_BGW.RunWorkerAsync(textBoxX1.Text.Trim());
        }

        /// <summary>
        /// 取消儲存時
        /// </summary>
        protected override void OnCancelButtonClick(EventArgs e)
        {
            SaveButtonVisible = false;
            CancelButtonVisible = false;

            _ChangeListener.SuspendListen(); //終止變更判斷

            this.Loading = true;

            //判斷是否忙碌後,開始進行資料重置
            Changed();
        }

        void Save_BGW_DoWork(object sender, DoWorkEventArgs e)
        {
            CarNo = "" + e.Argument;
            if (!string.IsNullOrEmpty(CarNo))
            {
                #region 卡號重覆使用檢查
                //取得本卡號之使用學生(是否有2人以上使用)
                List<AccessControlCard> cardList = _A.Select<AccessControlCard>("card_no='" + CarNo + "'");

                if (cardList.Count == 1) //只有一名
                {
                    #region 只有一人使用時
                    if (cardList[0].StudentID == int.Parse(_Record.ID)) //是否為本學生
                    {
                        //新增一筆卡號
                        InsertNewCard(CarNo);
                    }
                    else //錯誤
                    {
                        #region 輸入的卡號已有人使用

                        StudentRecord sr = Student.SelectByID(cardList[0].StudentID.ToString());
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("卡號與其它學生重覆:\n");
                        sb.AppendLine(SetStudent(sr));
                        sb.AppendLine("\n您是否要將重覆資料刪除後新增?");

                        DialogResult dr = MsgBox.Show(sb.ToString(), MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2);
                        if (dr == DialogResult.Yes)
                        {
                            _A.DeletedValues(cardList); //刪除卡片
                            FISCA.LogAgent.ApplicationLog.Log("門禁系統", "刪除", "student", sr.ID, string.Format("學生「{0}」刪除卡號「{1}」", sr.Name, cardList[0].CardNo));
                            InsertNewCard(CarNo); //新增卡號
                        }
                        else
                        {
                            e.Cancel = true;
                        }

                        #endregion
                    }
                    #endregion
                }
                else if (cardList.Count > 1)
                {
                    #region 卡號多人使用
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("卡號與其它學生重覆:\n");
                    List<StudentRecord> StudentList = new List<StudentRecord>();
                    foreach (AccessControlCard each in cardList)
                    {
                        StudentRecord sr = Student.SelectByID(each.StudentID.ToString());
                        StudentList.Add(sr);
                        sb.AppendLine(SetStudent(sr));
                    }
                    sb.AppendLine("\n您是否要將重覆資料刪除後新增?");
                    DialogResult dr = MsgBox.Show(sb.ToString(), MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2);
                    if (dr == DialogResult.Yes)
                    {
                        foreach (StudentRecord sr in StudentList)
                        {
                            FISCA.LogAgent.ApplicationLog.Log("門禁系統", "刪除", "student", sr.ID, string.Format("學生「{0}」刪除卡號「{1}」", sr.Name, cardList[0].CardNo));
                        }
                        _A.DeletedValues(cardList); //刪除卡片

                        InsertNewCard(CarNo); //新增卡號
                    }
                    else
                    {
                        e.Cancel = true;
                    }

                    #endregion
                }
                else
                {
                    #region 卡號沒人使用

                    InsertNewCard(CarNo);

                    #endregion
                }

                #endregion
            }
            else
            {
                //如果內容為空,該本學生之所有卡片將會被刪除
                List<AccessControlCard> list = _A.Select<AccessControlCard>("ref_student_id=" + _Record.ID);
                if (list.Count > 0)
                {
                    _A.DeletedValues(list);

                    FISCA.LogAgent.ApplicationLog.Log("門禁系統", "刪除", "student", _Record.ID, string.Format("學生「{0}」刪除卡號「{1}」", _Record.Name, list[0].CardNo));
                }
            }

            //進行Log資料的記錄
        }

        private string SetStudent(StudentRecord sr)
        {
            StringBuilder sb = new StringBuilder();
            string clsName = sr.Class != null ? sr.Class.Name : "";
            sb.AppendLine("班級:" + clsName);

            string seatno = sr.SeatNo.HasValue ? sr.SeatNo.Value.ToString() : "";
            sb.AppendLine("座號:" + seatno);
            sb.AppendLine("學號:" + sr.StudentNumber);
            sb.AppendLine("姓名:" + sr.Name);

            return sb.ToString();
        }

        void Save_BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                if (e.Error == null)
                {
                    MsgBox.Show("儲存成功!!");
                }
                else
                {
                    MsgBox.Show("儲存失敗!!\n" + e.Error.Message);
                }
            }
            else
            {
                MsgBox.Show("作業已取消!!");
            }

            BGW.RunWorkerAsync();
        }

        private void InsertNewCard(string CarNo)
        {
            StringBuilder sb = new StringBuilder();
            //刪除本學生身上的卡片
            List<AccessControlCard> accList = _A.Select<AccessControlCard>("ref_student_id=" + _Record.ID);
            if (accList.Count > 0)
            {
                foreach (AccessControlCard each in accList)
                {
                    sb.AppendLine(string.Format("學生「{0}」刪除卡號「{1}」", _Record.Name, each.CardNo));
                }
                _A.DeletedValues(accList);
            }

            List<AccessControlCard> list = new List<AccessControlCard>();
            AccessControlCard acc = new AccessControlCard();
            acc.CardNo = CarNo;
            acc.StudentID = int.Parse(_Record.ID);
            list.Add(acc);
            _A.InsertValues(list); //新增
            sb.AppendLine(string.Format("學生「{0}」新增卡號「{1}」", _Record.Name, CarNo));
            FISCA.LogAgent.ApplicationLog.Log("門禁系統", "修改", "student", _Record.ID, sb.ToString());
        }

        void ClubEvents_ClubChanged(object sender, EventArgs e)
        {
            Changed();
        }

        void BGW_DoWork(object sender, DoWorkEventArgs e)
        {
            _Record = Student.SelectByID(this.PrimaryKey);
            if (_Record != null)
            {
                List<AccessControlCard> accList = _A.Select<AccessControlCard>("ref_student_id=" + _Record.ID);
                if (accList.Count == 1)
                {
                    _AccessControlCard = accList[0];

                    //取得學生刷卡歷程
                    StringBuilder sb = new StringBuilder();
                    sb.Append("select oclock_name,use_type,use_time from $cht_access_control_card.history ");
                    sb.Append(string.Format("where card_no='{0}'", _AccessControlCard.CardNo));

                    DataTable dt = _Q.Select(sb.ToString());
                    foreach (DataRow row in dt.Rows)
                    {
                        AccessExtendRecord aer = new AccessExtendRecord(row);
                        AccessRecordList.Add(aer);
                    }
                }
                else if (accList.Count > 1)
                {
                    List<string> list = new List<string>();
                    foreach (AccessControlCard each in accList)
                    {
                        list.Add(each.CardNo);
                    }

                    FISCA.Presentation.Controls.MsgBox.Show(string.Format("資料有誤!!\n\n學生有{0}張門禁卡:\n卡號:{1}", accList.Count, string.Join(",卡號:", list)));

                    _AccessControlCard = accList[0];

                    //取得學生刷卡歷程
                    StringBuilder sb = new StringBuilder();
                    sb.Append("select oclock_name,use_type,use_time from $cht_access_control_card.history ");
                    sb.Append("where card_no='" + _AccessControlCard.CardNo + "'");

                    DataTable dt = _Q.Select(sb.ToString());
                    foreach (DataRow row in dt.Rows)
                    {
                        AccessExtendRecord aer = new AccessExtendRecord(row);
                        AccessRecordList.Add(aer);
                    }
                }
            }
        }

        void BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Loading = false;

            if (e.Cancelled)
            {
                return;
            }

            if (e.Error != null)
            {
                this.Loading = false;
                FISCA.Presentation.Controls.MsgBox.Show("取得[門禁刷卡歷程]發生錯誤!!\n" + e.Error.Message);
                return;
            }

            if (BkWBool) //如果有其他的更新事件
            {
                BkWBool = false;
                BGW.RunWorkerAsync();
                return;
            }

            BindData();
        }

        /// <summary>
        /// 建置畫面內容
        /// </summary>
        private void BindData()
        {
            listViewEx1.Items.Clear();
            AccessRecordList.Sort(SortDateTime);
            foreach (AccessExtendRecord each in AccessRecordList)
            {
                listViewEx1.Items.Add(SetListView(each));
            }

            if (_AccessControlCard != null)
                textBoxX1.Text = _AccessControlCard.CardNo;
            else
                textBoxX1.Text = "";

            linkLabel1.Text = "刷卡歷程數量：" + AccessRecordList.Count;

            BkWBool = false;

            _ChangeListener.Reset();
            _ChangeListener.ResumeListen();

            SaveButtonVisible = false;
            CancelButtonVisible = false;
        }

        private int SortDateTime(AccessExtendRecord aer1, AccessExtendRecord aer2)
        {
            DateTime dt1;
            DateTime dt2;
            DateTime.TryParse(aer1.use_time, out dt1);
            DateTime.TryParse(aer2.use_time, out dt2);
            if (dt1 != null && dt2 != null)
            {
                return dt2.CompareTo(dt1);
            }
            else //相同
            {
                return 0;
            }
        }

        private ListViewItem SetListView(AccessExtendRecord each)
        {
            #region 依資料建立ListView
            DateTime dt;
            DateTime.TryParse(each.use_time, out dt);
            ListViewItem item;
            //座號
            if (dt != null)
            {
                if (dt.ToShortDateString() == DateTime.Today.ToShortDateString())
                {
                    item = new ListViewItem(each.use_time + "　(今日)");
                    item.SubItems.Add(each.use_type);
                    item.SubItems.Add(each.oclock_name);
                }
                else
                {
                    item = new ListViewItem(each.use_time);
                    item.SubItems.Add(each.use_type);
                    item.SubItems.Add(each.oclock_name);
                }
            }
            else
            {
                item = new ListViewItem(each.use_time);
                item.SubItems.Add(each.use_type);
                item.SubItems.Add(each.oclock_name);
            }

            return item;

            #endregion
        }

        protected override void OnPrimaryKeyChanged(EventArgs e)
        {
            Changed();
        }

        private void Changed()
        {
            #region 更新時
            if (this.PrimaryKey != "")
            {
                this.Loading = true;

                if (BGW.IsBusy)
                {
                    BkWBool = true;
                }
                else
                {
                    Reset();
                    BGW.RunWorkerAsync();
                }
            }
            #endregion
        }

        /// <summary>
        /// 重置學生資料
        /// </summary>
        private void Reset()
        {
            _AccessControlCard = null;
            AccessRecordList = new List<AccessExtendRecord>();
            _Record = null;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = "學生刷卡記錄";
            if (_Record != null)
                saveFileDialog1.FileName += "(" + _Record.Name + ")";
            saveFileDialog1.Filter = "Excel (*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

            Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
            //填入標頭
            wb.Worksheets[0].Cells[0, 0].PutValue("刷卡日期");
            wb.Worksheets[0].Cells[0, 1].PutValue("上學/放學");
            wb.Worksheets[0].Cells[0, 2].PutValue("卡鐘編號");

            int y = 1;
            foreach (ListViewItem each in listViewEx1.Items)
            {
                int z = 0;
                foreach (ListViewItem.ListViewSubItem item in each.SubItems)
                {
                    wb.Worksheets[0].Cells[y, z].PutValue(item.Text);
                    z++;
                }
                y++;
            }
            wb.Worksheets[0].AutoFitColumns();
            wb.Save(saveFileDialog1.FileName, FileFormatType.Excel2003);

            //是否開啟檔案
            if (new CompleteForm().ShowDialog() == DialogResult.Yes)
                System.Diagnostics.Process.Start(saveFileDialog1.FileName);
        }
    }
}
