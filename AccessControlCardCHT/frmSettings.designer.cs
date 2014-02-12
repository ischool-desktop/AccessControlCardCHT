namespace AccessControlCardCHT
{
    partial class frmSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtLeaveSchoolSMS = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.chkEnableLeaveSchoolSMS = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.txtArriveSchoolSMS = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.chkEnableArriveSchoolSMS = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkAuotDelivery = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtErrorPhone = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.chkEnableErrorSMS = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(272, 405);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "儲存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExit.Location = new System.Drawing.Point(355, 405);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "離開";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.txtLeaveSchoolSMS);
            this.groupPanel1.Controls.Add(this.chkEnableLeaveSchoolSMS);
            this.groupPanel1.Controls.Add(this.txtArriveSchoolSMS);
            this.groupPanel1.Controls.Add(this.chkEnableArriveSchoolSMS);
            this.groupPanel1.Controls.Add(this.chkAuotDelivery);
            this.groupPanel1.DrawTitleBox = false;
            this.groupPanel1.Location = new System.Drawing.Point(11, 12);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(420, 298);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.Class = "";
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.Class = "";
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.Class = "";
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 12;
            this.groupPanel1.Text = "每日發送設定";
            // 
            // txtLeaveSchoolSMS
            // 
            // 
            // 
            // 
            this.txtLeaveSchoolSMS.Border.Class = "TextBoxBorder";
            this.txtLeaveSchoolSMS.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLeaveSchoolSMS.Location = new System.Drawing.Point(217, 62);
            this.txtLeaveSchoolSMS.Multiline = true;
            this.txtLeaveSchoolSMS.Name = "txtLeaveSchoolSMS";
            this.txtLeaveSchoolSMS.Size = new System.Drawing.Size(190, 198);
            this.txtLeaveSchoolSMS.TabIndex = 13;
            this.txtLeaveSchoolSMS.WatermarkText = "貴子弟{姓名}於{時間}離開學校，如有疑問，請電03-5643162世界高中敬啟。";
            // 
            // chkEnableLeaveSchoolSMS
            // 
            this.chkEnableLeaveSchoolSMS.AutoSize = true;
            this.chkEnableLeaveSchoolSMS.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkEnableLeaveSchoolSMS.BackgroundStyle.Class = "";
            this.chkEnableLeaveSchoolSMS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkEnableLeaveSchoolSMS.Location = new System.Drawing.Point(217, 35);
            this.chkEnableLeaveSchoolSMS.Name = "chkEnableLeaveSchoolSMS";
            this.chkEnableLeaveSchoolSMS.Size = new System.Drawing.Size(107, 21);
            this.chkEnableLeaveSchoolSMS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkEnableLeaveSchoolSMS.TabIndex = 12;
            this.chkEnableLeaveSchoolSMS.Text = "發送離校簡訊";
            this.chkEnableLeaveSchoolSMS.CheckedChanged += new System.EventHandler(this.chkEnableLeaveSchoolSMS_CheckedChanged);
            // 
            // txtArriveSchoolSMS
            // 
            // 
            // 
            // 
            this.txtArriveSchoolSMS.Border.Class = "TextBoxBorder";
            this.txtArriveSchoolSMS.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtArriveSchoolSMS.Location = new System.Drawing.Point(5, 62);
            this.txtArriveSchoolSMS.Multiline = true;
            this.txtArriveSchoolSMS.Name = "txtArriveSchoolSMS";
            this.txtArriveSchoolSMS.Size = new System.Drawing.Size(190, 197);
            this.txtArriveSchoolSMS.TabIndex = 11;
            this.txtArriveSchoolSMS.WatermarkText = "貴子弟{姓名}於{時間}到達學校，如有疑問，請電03-5643162世界高中敬啟。";
            // 
            // chkEnableArriveSchoolSMS
            // 
            this.chkEnableArriveSchoolSMS.AutoSize = true;
            this.chkEnableArriveSchoolSMS.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkEnableArriveSchoolSMS.BackgroundStyle.Class = "";
            this.chkEnableArriveSchoolSMS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkEnableArriveSchoolSMS.Location = new System.Drawing.Point(5, 35);
            this.chkEnableArriveSchoolSMS.Name = "chkEnableArriveSchoolSMS";
            this.chkEnableArriveSchoolSMS.Size = new System.Drawing.Size(107, 21);
            this.chkEnableArriveSchoolSMS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkEnableArriveSchoolSMS.TabIndex = 10;
            this.chkEnableArriveSchoolSMS.Text = "發送到校簡訊";
            this.chkEnableArriveSchoolSMS.CheckedChanged += new System.EventHandler(this.chkEnableArriveSchoolSMS_CheckedChanged);
            // 
            // chkAuotDelivery
            // 
            this.chkAuotDelivery.AutoSize = true;
            this.chkAuotDelivery.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkAuotDelivery.BackgroundStyle.Class = "";
            this.chkAuotDelivery.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkAuotDelivery.Location = new System.Drawing.Point(5, 8);
            this.chkAuotDelivery.Name = "chkAuotDelivery";
            this.chkAuotDelivery.Size = new System.Drawing.Size(134, 21);
            this.chkAuotDelivery.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkAuotDelivery.TabIndex = 9;
            this.chkAuotDelivery.Text = "啟動自動發送功能";
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.labelX1);
            this.groupPanel2.Controls.Add(this.txtErrorPhone);
            this.groupPanel2.Controls.Add(this.chkEnableErrorSMS);
            this.groupPanel2.DrawTitleBox = false;
            this.groupPanel2.Location = new System.Drawing.Point(12, 316);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(419, 73);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.Class = "";
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.Class = "";
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.Class = "";
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 13;
            this.groupPanel2.Text = "異常設定";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(216, 10);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(60, 21);
            this.labelX1.TabIndex = 12;
            this.labelX1.Text = "門號設定";
            // 
            // txtErrorPhone
            // 
            // 
            // 
            // 
            this.txtErrorPhone.Border.Class = "TextBoxBorder";
            this.txtErrorPhone.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtErrorPhone.Location = new System.Drawing.Point(282, 10);
            this.txtErrorPhone.Name = "txtErrorPhone";
            this.txtErrorPhone.Size = new System.Drawing.Size(100, 25);
            this.txtErrorPhone.TabIndex = 11;
            // 
            // chkEnableErrorSMS
            // 
            this.chkEnableErrorSMS.AutoSize = true;
            this.chkEnableErrorSMS.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkEnableErrorSMS.BackgroundStyle.Class = "";
            this.chkEnableErrorSMS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkEnableErrorSMS.Location = new System.Drawing.Point(12, 10);
            this.chkEnableErrorSMS.Name = "chkEnableErrorSMS";
            this.chkEnableErrorSMS.Size = new System.Drawing.Size(107, 21);
            this.chkEnableErrorSMS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkEnableErrorSMS.TabIndex = 10;
            this.chkEnableErrorSMS.Text = "發送異常通知";
            this.chkEnableErrorSMS.CheckedChanged += new System.EventHandler(this.chkEnableErrorSMS_CheckedChanged);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 437);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.DoubleBuffered = true;
            this.Name = "frmSettings";
            this.Text = "發送設定";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnExit;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtLeaveSchoolSMS;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkEnableLeaveSchoolSMS;
        private DevComponents.DotNetBar.Controls.TextBoxX txtArriveSchoolSMS;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkEnableArriveSchoolSMS;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkAuotDelivery;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtErrorPhone;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkEnableErrorSMS;
    }
}