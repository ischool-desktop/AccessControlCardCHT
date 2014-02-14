using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AccessControlCardCHT.UDT;

namespace AccessControlCardCHT
{
    public partial class formSetCHTAccount : FISCA.Presentation.Controls.BaseForm
    {
        // 帳號密碼資料
        ChtAccount _data = null;
        
        public formSetCHTAccount()
        {
            InitializeComponent();
            this.MaximumSize = this.MinimumSize = this.Size;
        }

        private void formSetCHTAccount_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            txtAccount.Enabled = false;
            txtPassword.Enabled = false;
            _data = DAL.DALTransfer.GetChtAccountInfo();

            if (_data == null)
                _data = new ChtAccount();

            txtAccount.Text = _data.Account;
            txtPassword.Text = _data.Password;

            txtAccount.Enabled = true;
            txtPassword.Enabled = true;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // 取得畫面上資料連入UDT

                if (_data == null)
                    _data = new ChtAccount();

                _data.Account = txtAccount.Text;
                _data.Password = txtPassword.Text;

                // 儲存資料
                _data.Save();
                FISCA.Presentation.Controls.MsgBox.Show("儲存完成");
                this.Close();
            }
            catch (Exception ex)
            {
                FISCA.Presentation.Controls.MsgBox.Show("儲存失敗:" + ex.Message);
                return;
            }
        }
    }
}
