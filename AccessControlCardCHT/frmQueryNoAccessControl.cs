using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FISCA.Data;
using K12.Data;

namespace AccessControlCardCHT
{
    public partial class frmQueryNoAccessControl : FISCA.Presentation.Controls.BaseForm
    {
        public frmQueryNoAccessControl()
        {
            InitializeComponent();

            //使用者輸入日期，系統依到校/離校狀態列出末刷卡學生。
            //(可比對該日期的缺曠記錄，當日無缺曠記錄者才列出。)並可匯出資料。
        }

        private void grdStudentList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder strBuilder = new StringBuilder();

                strBuilder.Append("select student.id,student_number,class.class_name,seat_no,name, card_no from student left outer join class on class.id=student.ref_class_id");
                strBuilder.Append(" inner join $cht_access_control_card.student_cardno on $cht_access_control_card.student_cardno.ref_student_id=student.id ");
                strBuilder.Append("where $cht_access_control_card.student_cardno.card_no is not null and student.ref_class_id is not null and student.status in (1,2)");
                strBuilder.Append(" order by class.class_name,seat_no");
                List<NoAccessControlRecord> Records = new List<NoAccessControlRecord>();

                QueryHelper helper = new QueryHelper();

                DataTable table = helper.Select(strBuilder.ToString());

                foreach (DataRow row in table.Rows)
                {
                    if (chkArrive.Checked)
                    {
                        NoAccessControlRecord RecordA = new NoAccessControlRecord(row, "到校");
                        Records.Add(RecordA);
                    }

                    if (chkLeave.Checked)
                    {
                        NoAccessControlRecord RecordL = new NoAccessControlRecord(row, "離校");
                        Records.Add(RecordL);
                    }
                }

                StringBuilder strHistory = new StringBuilder();

                strHistory.AppendLine(" select card_no,use_type from  $cht_access_control_card.history where to_char(use_time,'YYYY/MM/DD')='" + dateTimeInput1.Value.ToString("yyyy/MM/dd") + "'");

                table = helper.Select(strHistory.ToString());

                foreach (DataRow row in table.Rows)
                {
                    string CardNo = row.Field<string>("card_no");
                    string UseType = row.Field<string>("use_type");

                    if (UseType.Equals("01"))
                        UseType = "到校";
                    else if (UseType.Equals("02"))
                        UseType = "離校";

                    NoAccessControlRecord Record = Records
                        .Find(x => x.Status.Equals(UseType) && x.CardNo.Equals(CardNo));

                    if (Record != null)
                        Records.Remove(Record);
                }

                //if (chkAttendance.Checked)
                //{
                //    List<AttendanceRecord> AttendanceRecords = Attendance.SelectByDate(dateTimeInput1.Value, dateTimeInput1.Value);

                //    foreach (AttendanceRecord AttendanceRecord in AttendanceRecords)
                //    {
                //        List<NoAccessControlRecord> Record = Records
                //            .FindAll(x => x.StudentID.Equals(AttendanceRecord.RefStudentID));

                //        Record.ForEach(x => Records.Remove(x));
                //    }
                //}

                //需合併的ID清單
                List<string> mustMerge = new List<string>();
                
                Dictionary<string, List<string>> checker = new Dictionary<string,List<string>>();

                Dictionary<string,NoAccessControlRecord> sorter = new Dictionary<string,NoAccessControlRecord>();

                foreach (NoAccessControlRecord elem in Records)
                {
                    //以學生ID建立字典
                    if (!checker.ContainsKey(elem.StudentID))
                    {
                        checker.Add(elem.StudentID, new List<string>());
                    }

                    //將刷卡狀態增加到對應學生
                    if (!checker[elem.StudentID].Contains(elem.Status))
                    {
                        checker[elem.StudentID].Add(elem.Status);
                    }

                    //建立分類用學生字典
                    if (!sorter.ContainsKey(elem.StudentID))
                    {
                        sorter.Add(elem.StudentID, null);
                    }
                }

                foreach (string id in checker.Keys)
                {
                    bool a = false;
                    bool b = false;

                    //判斷該學生ID是否同時存在到校及離校狀態
                    foreach (string status in checker[id])
                    {
                        if (status == "到校")
                        {
                            a = true;
                        }

                        if (status == "離校")
                        {
                            b = true;
                        }
                    }

                    //若相同ID同時存在兩種狀態,加入合併清單中
                    if (a && b)
                    {
                        mustMerge.Add(id);
                    }
                }

                foreach (NoAccessControlRecord elem in Records)
                {
                    //若在合併清單中的ID,該物件狀態修改為"到校&離校"
                    if (mustMerge.Contains(elem.StudentID))
                    {
                        elem.Status = "到校&離校";
                    }

                    sorter[elem.StudentID] = elem;
                }

                //重新加入整理後的資料
                Records.Clear();
                foreach (NoAccessControlRecord record in sorter.Values)
                {
                    Records.Add(record);
                }

                grdSutdentList.DataSource = Records;
            }
            catch (Exception ex)
            {
                FISCA.Presentation.Controls.MsgBox.Show("查詢過程發生錯誤:" + ex.Message);                    
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = "未刷卡學生";
            saveFileDialog1.Filter = "Excel (*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

            DataGridViewExport export = new DataGridViewExport(grdSutdentList);
            export.Save(saveFileDialog1.FileName);

            if (new CompleteForm().ShowDialog() == DialogResult.Yes)
                System.Diagnostics.Process.Start(saveFileDialog1.FileName);
        }

        private void frmQueryNoAccessControl_Load(object sender, EventArgs e)
        {
            dateTimeInput1.Value = DateTime.Now;
        }
    }
}