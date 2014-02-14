using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FISCA.UDT;
using System.Text;
using AccessControlCardCHT.UDT;

namespace AccessControlCardCHT
{
    /// <summary>
    /// 設定
    /// </summary>
    public partial class frmSettings : FISCA.Presentation.Controls.BaseForm
    {
        private AccessHelper mHelper = new AccessHelper();
        private Setting mSetting = null;

        /// <summary>
        /// 無參數建構式
        /// </summary>
        public frmSettings()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 載入表單
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Settings_Load(object sender, EventArgs e)
        {
            List<Setting> Settings = mHelper.Select<Setting>();

            if (Settings.Count == 0)
                mSetting = new Setting();
            else
                mSetting = Settings[0];

            chkEnableArriveSchoolSMS.Checked = mSetting.EnableArriveSchoolSMS;
            chkEnableErrorSMS.Checked = mSetting.EnableErrorSMS;
            chkAuotDelivery.Checked = mSetting.EnableAutoSMS;
            chkEnableLeaveSchoolSMS.Checked = mSetting.EnableLeaveSchoolSMS;
            txtErrorPhone.Text = mSetting.ErrorPhone;
            txtArriveSchoolSMS.Text = mSetting.ArriveSchoolSMS;
            txtLeaveSchoolSMS.Text = mSetting.LeaveSchoolSMS;
            txtArriveSchoolSMS.Enabled = chkEnableArriveSchoolSMS.Checked;
            txtLeaveSchoolSMS.Enabled = chkEnableLeaveSchoolSMS.Checked;
            txtErrorPhone.Enabled = chkEnableErrorSMS.Enabled;
            txtErrorPhone.Enabled = chkEnableErrorSMS.Checked; //modified by Cloud
        }

        /// <summary>
        /// 儲存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (!ValidatorHelper.IsMobile(txtErrorPhone.Text))
            //{
            //    MessageBox.Show("手機格式有誤，無法儲存！");
            //    return;
            //}

            

            try
            {
                //紀錄上次設定作修改比對用 added by Cloud
                Setting oldSetting = new Setting();
                oldSetting.EnableAutoSMS = mSetting.EnableAutoSMS;
                oldSetting.EnableArriveSchoolSMS = mSetting.EnableArriveSchoolSMS;
                oldSetting.EnableLeaveSchoolSMS = mSetting.EnableLeaveSchoolSMS;
                oldSetting.ArriveSchoolSMS = mSetting.ArriveSchoolSMS;
                oldSetting.LeaveSchoolSMS = mSetting.LeaveSchoolSMS;
                oldSetting.EnableErrorSMS = mSetting.EnableErrorSMS;
                oldSetting.ErrorPhone = mSetting.ErrorPhone;
                //紀錄上次設定作修改比對用 added by Cloud

                mSetting.ArriveSchoolSMS = txtArriveSchoolSMS.Text;
                mSetting.EnableArriveSchoolSMS = chkEnableArriveSchoolSMS.Checked;
                mSetting.EnableAutoSMS = chkAuotDelivery.Checked;
                mSetting.EnableErrorSMS = chkEnableErrorSMS.Checked;
                mSetting.EnableLeaveSchoolSMS = chkEnableLeaveSchoolSMS.Checked;
                mSetting.ErrorPhone = txtErrorPhone.Text;
                mSetting.LeaveSchoolSMS = txtLeaveSchoolSMS.Text;

                mSetting.Save();

                MessageBox.Show("儲存成功！");

                //比對修改並寫Log added by Cloud
                LogChecker(oldSetting, mSetting);
            }
            catch (Exception ve)
            {
                MessageBox.Show("儲存失敗，錯誤訊息為：" + ve.Message);
            }
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

        private void chkEnableArriveSchoolSMS_CheckedChanged(object sender, EventArgs e)
        {
            txtArriveSchoolSMS.Enabled = chkEnableArriveSchoolSMS.Checked;
        }

        private void chkEnableLeaveSchoolSMS_CheckedChanged(object sender, EventArgs e)
        {
            txtLeaveSchoolSMS.Enabled = chkEnableLeaveSchoolSMS.Checked;
        }

        private void chkEnableErrorSMS_CheckedChanged(object sender, EventArgs e)
        {
            txtErrorPhone.Enabled = chkEnableErrorSMS.Checked;
        }

        //Log功能 added by Cloud
        private void LogChecker(Setting oldSetting,Setting newSetting)
        {
            StringBuilder sb = new StringBuilder();

            ////自動發送功能Log
            //if (oldSetting.EnableAutoSMS != newSetting.EnableAutoSMS)
            //{
            //    String str = newSetting.EnableAutoSMS ? "被開啟\r\n" : "被關閉\r\n";
            //    sb.Append("【發送設定:啟動自動發送功能】" + str );
            //}
            //到校簡訊功能Log
            if(oldSetting.EnableArriveSchoolSMS != newSetting.EnableArriveSchoolSMS)
            {
                String str = newSetting.EnableArriveSchoolSMS ? "被開啟\r\n" : "被關閉\r\n";
                sb.Append("【發送設定:發送到校簡訊功能】" + str);
            }
            //離校簡訊功能Log
            if(oldSetting.EnableLeaveSchoolSMS != newSetting.EnableLeaveSchoolSMS)
            {
                String str = newSetting.EnableLeaveSchoolSMS ? "被開啟\r\n" : "被關閉\r\n";
                sb.Append("【發送設定:發送離校簡訊功能】" + str);
            }
            //到校簡訊內容Log
            if(oldSetting.ArriveSchoolSMS != newSetting.ArriveSchoolSMS)
            {
                sb.Append(String.Format("【發送設定:到校簡訊內容】被修改\r\n『{0}』修改為\r\n『{1}』\r\n", oldSetting.ArriveSchoolSMS, newSetting.ArriveSchoolSMS));
            }
            //離校簡訊內容Log
            if (oldSetting.LeaveSchoolSMS != newSetting.LeaveSchoolSMS)
            {
                sb.Append(String.Format("【發送設定:離校簡訊內容】被修改\r\n『{0}』修改為\r\n『{1}』\r\n", oldSetting.LeaveSchoolSMS, newSetting.LeaveSchoolSMS));
            }
            //異常通知功能Log
            if(oldSetting.EnableErrorSMS != newSetting.EnableErrorSMS)
            {
                String str = newSetting.EnableErrorSMS ? "被開啟\r\n" : "被關閉\r\n";
                sb.Append("【發送設定:發送異常通知功能】" + str);
            }
            //門號設定內容Log
            if (oldSetting.ErrorPhone != newSetting.ErrorPhone)
            {
                sb.Append(String.Format("【發送設定:門號設定內容】被修改\r\n『{0}』修改為\r\n『{1}』\r\n", oldSetting.ErrorPhone, newSetting.ErrorPhone));
            }
            //寫入Log
            if(!string.IsNullOrEmpty(sb.ToString()))
            {
                FISCA.LogAgent.ApplicationLog.Log("門禁系統", "修改", sb.ToString());
            }
        }

        private void btnSetAccount_Click(object sender, EventArgs e)
        {
            // 設定中華電信簡訊帳號密碼
            formSetCHTAccount formCHT = new formSetCHTAccount();
            formCHT.ShowDialog();
        }
    }
}