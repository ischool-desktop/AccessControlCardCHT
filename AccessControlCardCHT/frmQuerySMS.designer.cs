namespace AccessControlCardCHT
{
    partial class frmQuerySMS
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dteStart = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dteEnd = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.grdSMSQueqe = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.btnQuery = new DevComponents.DotNetBar.ButtonX();
            this.btnExport = new DevComponents.DotNetBar.ButtonX();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.chkSendError = new System.Windows.Forms.CheckBox();
            this.reSend = new DevComponents.DotNetBar.ButtonX();
            this.lblMsg = new DevComponents.DotNetBar.LabelX();
            this.colStudentNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeliveryDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSMSMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUseTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkDbR = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dteStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSMSQueqe)).BeginInit();
            this.SuspendLayout();
            // 
            // dteStart
            // 
            this.dteStart.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.dteStart.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dteStart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dteStart.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dteStart.ButtonDropDown.Visible = true;
            this.dteStart.IsPopupCalendarOpen = false;
            this.dteStart.Location = new System.Drawing.Point(77, 12);
            // 
            // 
            // 
            this.dteStart.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dteStart.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dteStart.MonthCalendar.BackgroundStyle.Class = "";
            this.dteStart.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dteStart.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dteStart.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dteStart.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dteStart.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dteStart.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dteStart.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dteStart.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dteStart.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dteStart.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dteStart.MonthCalendar.DisplayMonth = new System.DateTime(2013, 6, 1, 0, 0, 0, 0);
            this.dteStart.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dteStart.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dteStart.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dteStart.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dteStart.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dteStart.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dteStart.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dteStart.MonthCalendar.TodayButtonVisible = true;
            this.dteStart.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dteStart.Name = "dteStart";
            this.dteStart.Size = new System.Drawing.Size(130, 25);
            this.dteStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dteStart.TabIndex = 0;
            this.dteStart.ValueChanged += new System.EventHandler(this.dteStart_ValueChanged);
            // 
            // dteEnd
            // 
            this.dteEnd.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.dteEnd.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dteEnd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dteEnd.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dteEnd.ButtonDropDown.Visible = true;
            this.dteEnd.IsPopupCalendarOpen = false;
            this.dteEnd.Location = new System.Drawing.Point(306, 12);
            // 
            // 
            // 
            this.dteEnd.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dteEnd.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dteEnd.MonthCalendar.BackgroundStyle.Class = "";
            this.dteEnd.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dteEnd.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dteEnd.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dteEnd.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dteEnd.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dteEnd.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dteEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dteEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dteEnd.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dteEnd.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dteEnd.MonthCalendar.DisplayMonth = new System.DateTime(2013, 6, 1, 0, 0, 0, 0);
            this.dteEnd.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dteEnd.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dteEnd.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dteEnd.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dteEnd.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dteEnd.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dteEnd.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dteEnd.MonthCalendar.TodayButtonVisible = true;
            this.dteEnd.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dteEnd.Name = "dteEnd";
            this.dteEnd.Size = new System.Drawing.Size(130, 25);
            this.dteEnd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dteEnd.TabIndex = 1;
            this.dteEnd.ValueChanged += new System.EventHandler(this.dteEnd_ValueChanged);
            // 
            // grdSMSQueqe
            // 
            this.grdSMSQueqe.AllowUserToAddRows = false;
            this.grdSMSQueqe.AllowUserToDeleteRows = false;
            this.grdSMSQueqe.AllowUserToOrderColumns = true;
            this.grdSMSQueqe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdSMSQueqe.BackgroundColor = System.Drawing.Color.White;
            this.grdSMSQueqe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSMSQueqe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStudentNumber,
            this.colStudentName,
            this.colDeliveryDateTime,
            this.colPhone,
            this.colCard,
            this.colStatus,
            this.colSMSMessage,
            this.colUseTime});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSMSQueqe.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdSMSQueqe.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.grdSMSQueqe.Location = new System.Drawing.Point(12, 48);
            this.grdSMSQueqe.Name = "grdSMSQueqe";
            this.grdSMSQueqe.ReadOnly = true;
            this.grdSMSQueqe.RowTemplate.Height = 24;
            this.grdSMSQueqe.Size = new System.Drawing.Size(799, 413);
            this.grdSMSQueqe.TabIndex = 2;
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
            this.labelX1.Location = new System.Drawing.Point(14, 14);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(60, 21);
            this.labelX1.TabIndex = 3;
            this.labelX1.Text = "開始日期";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(239, 14);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(60, 21);
            this.labelX2.TabIndex = 4;
            this.labelX2.Text = "結束日期";
            // 
            // btnQuery
            // 
            this.btnQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.AutoSize = true;
            this.btnQuery.BackColor = System.Drawing.Color.Transparent;
            this.btnQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQuery.Location = new System.Drawing.Point(736, 12);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 25);
            this.btnQuery.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnQuery.TabIndex = 5;
            this.btnQuery.Text = "查詢";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnExport
            // 
            this.btnExport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExport.AutoSize = true;
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExport.Location = new System.Drawing.Point(12, 473);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(145, 25);
            this.btnExport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "匯出門禁簡訊發送記錄";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.AutoSize = true;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExit.Location = new System.Drawing.Point(736, 473);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExit.TabIndex = 18;
            this.btnExit.Text = "離開";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // chkSendError
            // 
            this.chkSendError.AutoSize = true;
            this.chkSendError.BackColor = System.Drawing.Color.Transparent;
            this.chkSendError.Location = new System.Drawing.Point(456, 14);
            this.chkSendError.Name = "chkSendError";
            this.chkSendError.Size = new System.Drawing.Size(118, 21);
            this.chkSendError.TabIndex = 19;
            this.chkSendError.Text = "只顯示傳送失敗";
            this.chkSendError.UseVisualStyleBackColor = false;
            this.chkSendError.CheckedChanged += new System.EventHandler(this.chkSendError_CheckedChanged);
            // 
            // reSend
            // 
            this.reSend.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.reSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.reSend.AutoSize = true;
            this.reSend.BackColor = System.Drawing.Color.Transparent;
            this.reSend.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.reSend.Location = new System.Drawing.Point(655, 473);
            this.reSend.Name = "reSend";
            this.reSend.Size = new System.Drawing.Size(75, 25);
            this.reSend.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.reSend.TabIndex = 20;
            this.reSend.Text = "重新傳送";
            this.reSend.Click += new System.EventHandler(this.reSend_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblMsg.BackgroundStyle.Class = "";
            this.lblMsg.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblMsg.Location = new System.Drawing.Point(164, 474);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(53, 21);
            this.lblMsg.TabIndex = 21;
            this.lblMsg.Text = "labelX3";
            // 
            // colStudentNumber
            // 
            this.colStudentNumber.DataPropertyName = "StudentNumber";
            this.colStudentNumber.HeaderText = "學號";
            this.colStudentNumber.Name = "colStudentNumber";
            this.colStudentNumber.ReadOnly = true;
            this.colStudentNumber.Width = 80;
            // 
            // colStudentName
            // 
            this.colStudentName.DataPropertyName = "StudentName";
            this.colStudentName.HeaderText = "姓名";
            this.colStudentName.Name = "colStudentName";
            this.colStudentName.ReadOnly = true;
            this.colStudentName.Width = 80;
            // 
            // colDeliveryDateTime
            // 
            this.colDeliveryDateTime.DataPropertyName = "SendTime";
            this.colDeliveryDateTime.HeaderText = "發送時間";
            this.colDeliveryDateTime.Name = "colDeliveryDateTime";
            this.colDeliveryDateTime.ReadOnly = true;
            // 
            // colPhone
            // 
            this.colPhone.DataPropertyName = "TargetPhone";
            this.colPhone.HeaderText = "行動電話";
            this.colPhone.Name = "colPhone";
            this.colPhone.ReadOnly = true;
            // 
            // colCard
            // 
            this.colCard.DataPropertyName = "CardNo";
            this.colCard.HeaderText = "卡號";
            this.colCard.Name = "colCard";
            this.colCard.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "狀態";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 80;
            // 
            // colSMSMessage
            // 
            this.colSMSMessage.DataPropertyName = "SMSContent";
            this.colSMSMessage.HeaderText = "訊息";
            this.colSMSMessage.Name = "colSMSMessage";
            this.colSMSMessage.ReadOnly = true;
            this.colSMSMessage.Width = 130;
            // 
            // colUseTime
            // 
            this.colUseTime.HeaderText = "刷卡時間";
            this.colUseTime.Name = "colUseTime";
            this.colUseTime.ReadOnly = true;
            // 
            // chkDbR
            // 
            this.chkDbR.AutoSize = true;
            this.chkDbR.BackColor = System.Drawing.Color.Transparent;
            this.chkDbR.Location = new System.Drawing.Point(582, 14);
            this.chkDbR.Name = "chkDbR";
            this.chkDbR.Size = new System.Drawing.Size(118, 21);
            this.chkDbR.TabIndex = 22;
            this.chkDbR.Text = "只顯示沒有傳送";
            this.chkDbR.UseVisualStyleBackColor = false;
            this.chkDbR.CheckedChanged += new System.EventHandler(this.chkDbR_CheckedChanged);
            // 
            // frmQuerySMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 506);
            this.Controls.Add(this.chkDbR);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.reSend);
            this.Controls.Add(this.chkSendError);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.grdSMSQueqe);
            this.Controls.Add(this.dteEnd);
            this.Controls.Add(this.dteStart);
            this.DoubleBuffered = true;
            this.Name = "frmQuerySMS";
            this.Text = "查詢門禁簡訊發送記錄";
            this.Load += new System.EventHandler(this.QuerySMS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dteStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSMSQueqe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.Editors.DateTimeAdv.DateTimeInput dteStart;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dteEnd;
        private DevComponents.DotNetBar.Controls.DataGridViewX grdSMSQueqe;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ButtonX btnQuery;
        private DevComponents.DotNetBar.ButtonX btnExport;
        private DevComponents.DotNetBar.ButtonX btnExit;
        private System.Windows.Forms.CheckBox chkSendError;
        private DevComponents.DotNetBar.ButtonX reSend;
        private DevComponents.DotNetBar.LabelX lblMsg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStudentNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeliveryDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSMSMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUseTime;
        private System.Windows.Forms.CheckBox chkDbR;
    }
}