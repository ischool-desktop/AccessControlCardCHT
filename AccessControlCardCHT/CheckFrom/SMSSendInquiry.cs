using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;

namespace AccessControlCardCHT
{
    public partial class SMSSendInquiry : BaseForm
    {
        public SMSSendInquiry()
        {
            InitializeComponent();
        }

        private void SMSSendInquiry_Load(object sender, EventArgs e)
        {
            dateTimeInput1.Value = DateTime.Today;
            dateTimeInput2.Value = DateTime.Today;
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            try
            {
                //開始時間
                //結束時間
                //條件
                List<SMSInquirtRecord> SMSList = new List<SMSInquirtRecord>();

                StringBuilder sb = new StringBuilder();
                sb.Append("select student.id,student_number,class.class_name,seat_no,name,$cht_access_control_card.student_cardno.card_no,");
                sb.Append("$cht_access_control_card.history.use_time,$cht_access_control_card.history.oclock_name,");
                sb.Append("$cht_access_control_card.history.use_type ");

                //來自student
                //join class
                sb.Append("from student left outer join class on class.id=student.ref_class_id ");
                //join access_control_card.student_cardno
                sb.Append("inner join $cht_access_control_card.student_cardno on $cht_access_control_card.student_cardno.ref_student_id=student.id ");
                //join access_control_card.history
                sb.Append("left outer join $cht_access_control_card.history ");
                sb.Append("on $cht_access_control_card.history.card_no=$cht_access_control_card.student_cardno.card_no ");

                //卡號不得為null
                sb.Append("where $cht_access_control_card.student_cardno is not null ");

                //卡號 / 學號 / 姓名
                if (!string.IsNullOrEmpty(textBoxX1.Text.Trim()))
                {
                    sb.Append(string.Format("and ($cht_access_control_card.student_cardno.card_no like '%{0}%' ", textBoxX1.Text.Trim()));
                    sb.Append(string.Format("or student_number like '%{0}%' ", textBoxX1.Text.Trim()));
                    sb.Append(string.Format("or name like '%{0}%') ", textBoxX1.Text.Trim()));
                }

                //日期判斷式
                sb.Append(string.Format("and ($cht_access_control_card.history.use_time>='{0}' ", dateTimeInput1.Value.ToShortDateString()));
                sb.Append(string.Format("and $cht_access_control_card.history.use_time<='{0}')", dateTimeInput2.Value.AddDays(1).ToShortDateString()));

                //上學 / 放學
                if (checkBoxX1.Checked && checkBoxX2.Checked)
                    sb.Append("and ($cht_access_control_card.history.use_type='01' or $cht_access_control_card.history.use_type='02')");
                else if (checkBoxX1.Checked)
                    sb.Append("and $cht_access_control_card.history.use_type='01'");
                else if (checkBoxX2.Checked)
                    sb.Append("and $cht_access_control_card.history.use_type='02'");
                else
                {
                    dataGridViewX1.DataSource = SMSList;
                    dataGridViewX1.AutoGenerateColumns = false;
                    return;
                }

                FISCA.Data.QueryHelper _q = new FISCA.Data.QueryHelper();
                DataTable dt = _q.Select(sb.ToString());
                foreach (DataRow row in dt.Rows)
                {
                    SMSInquirtRecord sms = new SMSInquirtRecord(row);
                    SMSList.Add(sms);
                }

                SMSList.Sort(SortDateTime);
                dataGridViewX1.DataSource = SMSList;
                dataGridViewX1.AutoGenerateColumns = false;

                this.Text = string.Format("查詢學生刷卡記錄(共 {0} 筆資料)", SMSList.Count);
            }
            catch (Exception ex)
            {
                FISCA.Presentation.Controls.MsgBox.Show("查詢過程發生錯誤:" + ex.Message);
            }
        }

        private int SortDateTime(SMSInquirtRecord sms1, SMSInquirtRecord sms2)
        {
            DateTime dt1;
            DateTime dt2;
            DateTime.TryParse(sms1.use_time, out dt1);
            DateTime.TryParse(sms2.use_time, out dt2);
            if (dt1 != null && dt2 != null)
            {
                return dt1.CompareTo(dt2);
            }
            else //相同
            {
                return 0;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = "查詢學生刷卡記錄";
            saveFileDialog1.Filter = "Excel (*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

            DataGridViewExport export = new DataGridViewExport(dataGridViewX1);
            export.Save(saveFileDialog1.FileName);

            if (new CompleteForm().ShowDialog() == DialogResult.Yes)
                System.Diagnostics.Process.Start(saveFileDialog1.FileName);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
