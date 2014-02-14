using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Data;
using AccessControlCardCHT.UDT;

namespace AccessControlCardCHT
{
    public partial class frmQuerySMS : FISCA.Presentation.Controls.BaseForm
    {
        public frmQuerySMS()
        {
            InitializeComponent();
            reSend.Enabled = false;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            btnQuery.Enabled = false;
            try
            {
                if (dteEnd.Value < dteStart.Value)
                    MessageBox.Show("結束日期必須大於等於開始日期！");
                grdSMSQueqe.Rows.Clear();
                QueryHelper helper = new QueryHelper();

                string str1 = "";
                // 只顯示傳送失敗
                if (chkSendError.Checked)
                    str1 = "and cht_status<>'0' and send_date is not null";

                // 只顯示沒有傳送
                if(chkDbR.Checked)
                    str1 = "and send_date is null";

                // 只顯示傳送失敗與沒有傳送
                if(chkDbR.Checked && chkSendError.Checked)
                    str1 = "and cht_status<>'0' and send_date is null";

                string strSQL = "select student.student_number,student.name,send_date,cell_phone,send_message, cht_message,card_no,uid,cht_status,cht_msg_id,cht_chk_date,use_time from $cht_access_control_card.history inner join student on student.id=$cht_access_control_card.history.ref_student_id where card_no is not null "+str1+" and use_time>='" + dteStart.Value.ToShortDateString() + "' and use_time<='" + dteEnd.Value.AddDays(1).ToShortDateString() + "' order by student_number,send_date desc";

                DataTable table = helper.Select(strSQL);

                grdSMSQueqe.Rows.Clear();
                //BindingList<SMSRecord> StudentCards = new BindingList<SMSRecord>();

                //foreach (DataRow row in table.Rows)
                //{
                //    SMSRecord vStudentCard = new SMSRecord(row);
                //    StudentCards.Add(vStudentCard);
                //}

                //grdSMSQueqe.DataSource = StudentCards;

                // 填入值
                foreach (DataRow dr in table.Rows)
                {
                    int RowIdx = grdSMSQueqe.Rows.Add();
                    grdSMSQueqe.Rows[RowIdx].Tag = dr;
                    grdSMSQueqe.Rows[RowIdx].Cells[colStudentNumber.Index].Value = dr["student_number"].ToString();
                    grdSMSQueqe.Rows[RowIdx].Cells[colStudentName.Index].Value = dr["name"].ToString();
                    grdSMSQueqe.Rows[RowIdx].Cells[colDeliveryDateTime.Index].Value = dr["send_date"].ToString();
                    grdSMSQueqe.Rows[RowIdx].Cells[colPhone.Index].Value = dr["cell_phone"].ToString();
                    grdSMSQueqe.Rows[RowIdx].Cells[colSMSMessage.Index].Value = dr["send_message"].ToString();
                    grdSMSQueqe.Rows[RowIdx].Cells[colStatus.Index].Value = dr["cht_message"].ToString();
                    grdSMSQueqe.Rows[RowIdx].Cells[colCard.Index].Value = dr["card_no"].ToString();
                    grdSMSQueqe.Rows[RowIdx].Cells[colUseTime.Index].Value = dr["use_time"].ToString();                
                }

                lblMsg.Text = "共 " + table.Rows.Count + " 筆";

                // 傳送失敗勾起才可以使用
                if(chkSendError.Checked || chkDbR.Checked)
                    reSend.Enabled = true;
            }
            catch (Exception ex)
            {
                btnQuery.Enabled = true;
                reSend.Enabled = false;
                FISCA.Presentation.Controls.MsgBox.Show("查詢失敗," + ex.Message);
            }
            btnQuery.Enabled = true;
        }

        private void QuerySMS_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            dteStart.Value = DateTime.Now;
            dteEnd.Value = DateTime.Now;
            
        }

        /// <summary>
        /// 匯出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = "查詢門禁簡訊發送記錄";
            saveFileDialog1.Filter = "Excel (*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

            DataGridViewExport export = new DataGridViewExport(grdSMSQueqe);
            export.Save(saveFileDialog1.FileName);

            if (new CompleteForm().ShowDialog() == DialogResult.Yes)
                System.Diagnostics.Process.Start(saveFileDialog1.FileName);
        }

        /// <summary>
        /// 離開
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void reSend_Click(object sender, EventArgs e)
        {
            try
            {
                // 取得畫面上所選資料
                if (grdSMSQueqe.SelectedRows.Count > 0)
                {
                    // 存放UID，取得UDT資料使用
                    List<string> uidList = new List<string>();

                    // 存放需要被傳送的資料
                    List<DataRow> sendDataRowList = new List<DataRow>();

                    // 取得所選 UID,條件：chk_status <>0
                    foreach (DataGridViewRow drv in grdSMSQueqe.SelectedRows)
                    {
                        DataRow dr = drv.Tag as DataRow;

                        if (dr == null)
                            continue;

                        if (dr["cht_status"] != null)
                        {
                            string val = dr["cht_status"].ToString();
                            if (val != "0")
                            {
                                if (dr["uid"] != null)
                                {
                                    uidList.Add(dr["uid"].ToString());
                                    sendDataRowList.Add(dr);
                                }
                            }
                        }
                    }

                    // 透過 UID 取得簡訊 UDT 資料
                    List<AccessControlCardHistory> AccessControlCardHistoryList = DAL.DALTransfer.GetAccessControlCardHistoryByUIDList(uidList);

                    // 建立更新資料 Dict，並存放資料
                    Dictionary<string, AccessControlCardHistory> AccessControlCardHistoryDict = new Dictionary<string, AccessControlCardHistory>();
                    foreach (AccessControlCardHistory data in AccessControlCardHistoryList)
                        AccessControlCardHistoryDict.Add(data.UID, data);

                    // 需要回寫UDT資料
                    List<AccessControlCardHistory> updateAccessControlCardHistoryList = new List<AccessControlCardHistory>();

                    // 取得中華電信帳號密碼
                    string Account = "";
                    string Passowrd = "";
                    ChtAccount user = DAL.DALTransfer.GetChtAccountInfo();
                    if (user != null)
                    {
                        Account = user.Account;
                        Passowrd = user.Password;
                    }

                    // 處理 DataGridRow 需要傳送簡訊資料
                    foreach (DataRow dr in sendDataRowList)
                    {
                        // 取得 uid
                        string uidIdx = "";
                        if (dr["uid"] != null)
                            uidIdx = dr["uid"].ToString();

                        // 檢查取得 uid 有在更新UDT uid 內
                        if (AccessControlCardHistoryDict.ContainsKey(uidIdx))
                        {
                            // 傳送簡訊資料
                            updateAccessControlCardHistoryList.Add(DAL.DALTransfer.SendCHTSMSData(AccessControlCardHistoryDict[uidIdx],Account,Passowrd));
                        }
                    }

                    // 回寫 UDT 資料
                    if (updateAccessControlCardHistoryList.Count > 0)
                    {
                        updateAccessControlCardHistoryList.SaveAll();
                        FISCA.Presentation.Controls.MsgBox.Show("傳送完成，請重新查詢");
                    }
                }
            }
            catch (Exception ex)
            {
                FISCA.Presentation.Controls.MsgBox.Show("傳送失敗:" + ex.Message);
            }
        }

        private void dteStart_ValueChanged(object sender, EventArgs e)
        {
            reSend.Enabled = false;
        }

        private void dteEnd_ValueChanged(object sender, EventArgs e)
        {
            reSend.Enabled = false;
        }

        private void chkSendError_CheckedChanged(object sender, EventArgs e)
        {
            reSend.Enabled = false;
        }

        private void chkDbR_CheckedChanged(object sender, EventArgs e)
        {
            reSend.Enabled = false;
        }
        
    }
}