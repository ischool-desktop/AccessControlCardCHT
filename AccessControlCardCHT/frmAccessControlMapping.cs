using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Data;
using FISCA.UDT;
using K12.Data;
using AccessControlCardCHT.UDT;

namespace AccessControlCardCHT
{
    public partial class frmAccessControlMapping : FISCA.Presentation.Controls.BaseForm
    {
        private QueryHelper mHelper = new QueryHelper();
        private AccessHelper mAccessHelper = new AccessHelper();
        private int constCardNoIndex;
        Dictionary<string, LogObj> _OldDic, _NewDic; //added by Cloud

        public frmAccessControlMapping()
        {
            InitializeComponent();
            //added by Cloud
            constCardNoIndex = colAccessCard.Index;
            //added by Cloud
            grdStudentList.AutoGenerateColumns = false;
        }

        private void AccessControlMapping_Load(object sender, EventArgs e)
        {
            cmbGradeYear.Items.Add("全部");
            cmbGradeYear.Items.Add("1");
            cmbGradeYear.Items.Add("2");
            cmbGradeYear.Items.Add("3");

            cmbGradeYear.SelectedIndex = 0;

            DataTable mTable = mHelper.Select("select class_name from class order by display_order,grade_year,class_name");

            cmbClass.Items.Add("全部");

            foreach (DataRow Row in mTable.Rows)
            {
                string ClassName = Row.Field<string>("class_name");
                cmbClass.Items.Add(ClassName);
            }

            cmbClass.SelectedIndex = 0;
        }

        /// <summary>
        /// 根據年級選取
        /// </summary>
        private void cmbGradeYear_SelectedValueChanged(object sender, EventArgs e)
        {
            string SelectedValue = "" + cmbGradeYear.SelectedItem;

            if (!string.IsNullOrEmpty(SelectedValue))
            {
                StringBuilder strBuilder = new StringBuilder();

                string GradeYearCondition = SelectedValue.Equals("全部") ? string.Empty : " where grade_year=" + SelectedValue;

                strBuilder.Append("select class_name from class ");
                strBuilder.Append(GradeYearCondition);
                strBuilder.Append(" order by grade_year,class_name");

                DataTable mTable = mHelper.Select(strBuilder.ToString());
                cmbClass.Items.Clear();
                cmbClass.Items.Add("全部");

                foreach (DataRow Row in mTable.Rows)
                {
                    string ClassName = Row.Field<string>("class_name");
                    cmbClass.Items.Add(ClassName);
                }

                cmbClass.SelectedIndex = 0;
            }
        }

        private void cmbClass_SelectedValueChanged(object sender, EventArgs e)
        {
            //StringBuilder strBuilder = new StringBuilder();

            //strBuilder.Append("select student.id,student_number,class.class_name,seat_no,name, sms_phone,$access_control_card.student_cardno.card_no from student ");
            //strBuilder.Append(" left outer join class on class.id=student.ref_class_id ");
            //strBuilder.Append(" left outer join $access_control_card.student_cardno on $access_control_card.student_cardno.ref_student_id=student.id ");
            //strBuilder.Append(" where student.status=1");

            //string SelectClass = "" + cmbClass.SelectedItem;
            //string SelectGradeYear = "" + cmbGradeYear.SelectedItem;

            //if (!SelectClass.Equals("全部"))
            //    strBuilder.Append(" and class.class_name='" + SelectClass + "'");
            //else if (!SelectGradeYear.Equals("全部"))
            //    strBuilder.Append(" and class.grade_year=" + SelectGradeYear);

            //strBuilder.AppendLine(" order by class.grade_year,class.class_name,student.seat_no");

            //DataTable table = mHelper.Select(strBuilder.ToString());

            //StudentCardBindingList StudentCards = new StudentCardBindingList();

            //foreach (DataRow row in table.Rows)
            //{
            //    StudentCard vStudentCard = new StudentCard(row);
            //    StudentCards.Add(vStudentCard);
            //}

            //grdStudentList.DataSource = StudentCards;

            btnSearch.Pulse(10);
        }

        /// <summary>
        /// 匯出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = "門禁系統對應資料";
            saveFileDialog1.Filter = "Excel (*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

            DataGridViewExport export = new DataGridViewExport(grdStudentList);
            export.Save(saveFileDialog1.FileName);

            if (new CompleteForm().ShowDialog() == DialogResult.Yes)
                System.Diagnostics.Process.Start(saveFileDialog1.FileName);
        }

        /// <summary>
        /// 儲存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<StudentCard> StudentCards = new List<StudentCard>();
            Dictionary<string, int> CardNoCount = new Dictionary<string, int>();
            List<string> DupCardNo = new List<string>();

            foreach (DataGridViewRow Row in grdStudentList.Rows)
            {
                StudentCard vStudentCard = Row.DataBoundItem as StudentCard;

                if (("" + Row.Tag).Equals("Changed"))
                {
                    StudentCards.Add(vStudentCard);
                }

                if (!string.IsNullOrEmpty(vStudentCard.CardNo))
                {
                    if (!CardNoCount.ContainsKey(vStudentCard.CardNo))
                        CardNoCount.Add(vStudentCard.CardNo, 0);
                    CardNoCount[vStudentCard.CardNo]++;

                    if (CardNoCount[vStudentCard.CardNo] > 1)
                        if (!DupCardNo.Contains(vStudentCard.CardNo))
                            DupCardNo.Add(vStudentCard.CardNo);
                }
            }

            if (DupCardNo.Count > 0)
            {
                MessageBox.Show("輸入重覆的卡號「" + string.Join(",", DupCardNo.ToArray()) + "」，請修正後再儲存！");
                return;
            }

            if (StudentCards.Count > 0)
            {
                try
                {
                    string StudentCondition = string.Join(",", StudentCards.Select(x => x.StudentID).ToArray());
                    //查詢並儲存學生被修改前的資料 by Cloud
                    String StudentIDs = string.Join("','", StudentCards.Select(x => x.StudentID).ToArray());
                    SavePreviousData(StudentIDs); 

                    //找出系統中相同卡號的學生
                    string CardCondition = string.Join(",", StudentCards.Select(x => "'" + x.CardNo + "'").ToArray());

                    List<AccessControlCard> Cards = mAccessHelper.Select<AccessControlCard>("ref_student_id in (" + StudentCondition + ")");

                    List<AccessControlCard> DupCards = mAccessHelper.Select<AccessControlCard>("card_no in (" + CardCondition + ")");

                    List<StudentCard> DupStudentCards = new List<StudentCard>();

                    foreach (StudentCard vStudentCard in StudentCards)
                    {
                        AccessControlCard Card = Cards.Find(x => ("" + x.StudentID).Equals(vStudentCard.StudentID));

                        //檢查是否有相同卡號，但是系統編號不一樣的學生
                        AccessControlCard DupCard = DupCards.Find(x => x.CardNo.Equals(vStudentCard.CardNo) &&
                            !("" + x.StudentID).Equals(vStudentCard.StudentID));

                        if (DupCard != null)
                            DupStudentCards.Add(vStudentCard);

                        if (Card == null)
                        {
                            Card = new AccessControlCard();
                            Card.StudentID = int.Parse(vStudentCard.StudentID);
                            Card.CardNo = vStudentCard.CardNo;
                            Card.CellPhone = vStudentCard.StudentPhone;
                            Cards.Add(Card);
                        }
                        else
                        {
                            Card.CardNo = vStudentCard.CardNo;
                            Card.CellPhone = vStudentCard.StudentPhone;
                        }
                    }

                    if (DupStudentCards.Count > 0)
                    {
                        StringBuilder strBuilder = new StringBuilder();

                        strBuilder.Append("以下學生的卡號已存在系統中「" + string.Join(",", DupStudentCards
                            .Select(x => x.StudentName + "(" + x.ClassName + " " + x.StudentSeatNo + ")").ToArray()) + "」");

                        MessageBox.Show(strBuilder.ToString());

                        return;
                    }

                    Cards.SaveAll();

                    //UpdateHelper vUpdateHelper = new UpdateHelper();

                    //List<string> Commands = new List<string>();

                    //foreach (StudentCard vStudentCard in StudentCards)
                    //{
                    //    Commands.Add("UPDATE $cht_access_control_card.student_cardno SET cell_phone='" + vStudentCard.StudentPhone + "' WHERE ref_student_id =" + vStudentCard.StudentID);
                    //}

                    //int Count = vUpdateHelper.Execute(Commands);

                    //查詢並儲存學生更新後的資料 by Cloud
                    SaveCurrentData(StudentIDs);
                    LogChecker();

                    MessageBox.Show("儲存成功！");
                }
                catch (Exception ve)
                {
                    MessageBox.Show(ve.Message);
                }
            }
        }

        private void grdStudentList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string CurrentCardNo = "" + grdStudentList.Rows[e.RowIndex].Cells[constCardNoIndex].Value;

                foreach (DataGridViewRow Row in grdStudentList.Rows)
                {
                    //卡號欄位空白跳離檢查 added by Cloud 
                    if (string.IsNullOrEmpty(CurrentCardNo)) break; 

                    if (!Row.Index.Equals(e.RowIndex))
                    {
                        string CardNo = "" + Row.Cells[constCardNoIndex].Value;

                        if (CurrentCardNo.Equals(CardNo))
                        {
                            grdStudentList.Rows[e.RowIndex].Cells[constCardNoIndex].ErrorText = "輸入重覆的卡號「" + CardNo + "」，請修正後再儲存！";

                            return;
                        }
                    }
                }

                grdStudentList.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = string.Empty;

                grdStudentList.Rows[e.RowIndex].Tag = "Changed";
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //搜尋功能,應該包含於篩選條件之範圍
        //背景模式處理
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbClass.SelectedItem == null || cmbGradeYear.SelectedItem == null)
            {
                if (cmbClass.SelectedItem == null)
                    MessageBox.Show("Class是NULL");
                if (cmbGradeYear.SelectedItem == null)
                    MessageBox.Show("GradeYear是NULL");
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtName.Text))
            {
                #region 當使用者輸入條件時
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.Append("select student.id,student_number,class.class_name,class.grade_year,seat_no,name, $cht_access_control_card.student_cardno.cell_phone, $cht_access_control_card.student_cardno.card_no from student ");
                strBuilder.Append(" left outer join class on class.id=student.ref_class_id ");
                strBuilder.Append(" left outer join  $cht_access_control_card.student_cardno on  $cht_access_control_card.student_cardno.ref_student_id=student.id ");
                strBuilder.Append(" where student.status=1 and student.name like '%" + txtName.Text + "%' or student.student_number like '%" + txtName.Text + "%' or  $cht_access_control_card.student_cardno.card_no like '%" + txtName.Text + "%'");

                string SelectClass = "" + cmbClass.SelectedItem;
                string SelectGradeYear = "" + cmbGradeYear.SelectedItem;

                strBuilder.AppendLine(" order by class.grade_year,class.class_name,student.seat_no");

                DataTable table = mHelper.Select(strBuilder.ToString());

                StudentCardBindingList StudentCards = new StudentCardBindingList();

                foreach (DataRow row in table.Rows)
                {
                    StudentCard vStudentCard = new StudentCard(row);
                    if (!SelectClass.Equals("全部"))
                    {
                        if (vStudentCard.ClassName != SelectClass)
                        {
                            continue;
                        }
                    }
                    else if (!SelectGradeYear.Equals("全部"))
                    {
                        if (vStudentCard.GradeYear != SelectGradeYear)
                        {
                            continue;
                        }
                    }
                    StudentCards.Add(vStudentCard);
                }

                grdStudentList.DataSource = StudentCards;
                
                #endregion
            }
            else
            {
                #region 當學號 姓名 卡號是空值時
                StringBuilder strBuilder = new StringBuilder();

                strBuilder.Append("select student.id,student_number,class.class_name,class.grade_year,seat_no,name, $cht_access_control_card.student_cardno.cell_phone, $cht_access_control_card.student_cardno.card_no from student ");
                strBuilder.Append(" left outer join class on class.id=student.ref_class_id ");
                strBuilder.Append(" left outer join  $cht_access_control_card.student_cardno on  $cht_access_control_card.student_cardno.ref_student_id=student.id ");
                strBuilder.Append(" where student.status=1");

                string SelectClass = "" + cmbClass.SelectedItem;
                string SelectGradeYear = "" + cmbGradeYear.SelectedItem;

                if (!SelectClass.Equals("全部"))
                    strBuilder.Append(" and class.class_name='" + SelectClass + "'");
                else if (!SelectGradeYear.Equals("全部"))
                    strBuilder.Append(" and class.grade_year=" + SelectGradeYear);

                strBuilder.AppendLine(" order by class.grade_year,class.class_name,student.seat_no");

                DataTable table = mHelper.Select(strBuilder.ToString());

                StudentCardBindingList StudentCards = new StudentCardBindingList();

                foreach (DataRow row in table.Rows)
                {
                    StudentCard vStudentCard = new StudentCard(row);
                    StudentCards.Add(vStudentCard);
                }

                grdStudentList.DataSource = StudentCards;
                #endregion
            }
        }

        //added by Cloud
        private void LogChecker()
        {
            StringBuilder sb = new StringBuilder();
            foreach(String id in _OldDic.Keys)
            {
                if(_OldDic[id].Sms_phone != _NewDic[id].Sms_phone)
                {
                    sb.Append("學生「" + _OldDic[id].Name + "」的行動電話「" + _OldDic[id].Sms_phone + "」改為" + "「" + _NewDic[id].Sms_phone + "」\r\n");
                }

                if (_OldDic[id].Card_no != _NewDic[id].Card_no)
                {
                    sb.Append("學生「" + _OldDic[id].Name + "」的卡號「" + _OldDic[id].Card_no + "」改為" + "「" + _NewDic[id].Card_no + "」\r\n");
                }
            }

            //寫入Log
            if (!string.IsNullOrEmpty(sb.ToString()))
            {
                FISCA.LogAgent.ApplicationLog.Log("門禁系統", "修改", sb.ToString());
            }
        }
        //查詢並儲存學生被修改前的資料 by Cloud
        private void SavePreviousData(String id)
        {
            _OldDic = new Dictionary<string, LogObj>();
            String ids = "('" + id + "')";
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("select id,name,$cht_access_control_card.student_cardno.cell_phone,card_no from student ");
            strBuilder.Append("left join  $cht_access_control_card.student_cardno on  $cht_access_control_card.student_cardno.ref_student_id=student.id ");
            strBuilder.Append("where id in " + ids);

            QueryHelper _Q = new QueryHelper();
            DataTable dt = _Q.Select(strBuilder.ToString());

            foreach (DataRow row in dt.Rows)
            {
                if (!_OldDic.ContainsKey(row["id"].ToString()))
                {
                    _OldDic.Add(row["id"].ToString(),new LogObj(row));
                }
            }
        }
        //查詢並儲存學生更新後的資料 by Cloud
        private void SaveCurrentData(String id)
        {
            _NewDic = new Dictionary<string, LogObj>();
            String ids = "('" + id + "')";
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("select id,name,$cht_access_control_card.student_cardno.cell_phone,card_no from student ");
            strBuilder.Append("left join  $cht_access_control_card.student_cardno on  $cht_access_control_card.student_cardno.ref_student_id=student.id ");
            strBuilder.Append("where id in " + ids);

            QueryHelper _Q = new QueryHelper();
            DataTable dt = _Q.Select(strBuilder.ToString());

            foreach (DataRow row in dt.Rows)
            {
                if (!_NewDic.ContainsKey(row["id"].ToString()))
                {
                    _NewDic.Add(row["id"].ToString(), new LogObj(row));
                }
            }
        }
    }
}