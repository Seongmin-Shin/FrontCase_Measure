namespace FrontMeasure
{
    partial class frmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.StusBar = new System.Windows.Forms.StatusStrip();
            this.ToolBarDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolBarTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolBarSplite = new System.Windows.Forms.ToolStripStatusLabel();
            this.PHead = new System.Windows.Forms.Panel();
            this.lbl_PlcReady = new System.Windows.Forms.Label();
            this.btnCodeSet = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.btnPlcData = new System.Windows.Forms.Button();
            this.btnSerch = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.PHead1 = new System.Windows.Forms.Panel();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PMain = new System.Windows.Forms.Panel();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.StusBar.SuspendLayout();
            this.PHead.SuspendLayout();
            this.PHead1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // StusBar
            // 
            this.StusBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.StusBar.Font = new System.Drawing.Font("현대하모니 M", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolBarDate,
            this.ToolBarTime,
            this.ToolBarSplite});
            this.StusBar.Location = new System.Drawing.Point(0, 968);
            this.StusBar.Name = "StusBar";
            this.StusBar.Size = new System.Drawing.Size(1280, 22);
            this.StusBar.TabIndex = 29;
            this.StusBar.Text = "StatusBar";
            // 
            // ToolBarDate
            // 
            this.ToolBarDate.ForeColor = System.Drawing.Color.White;
            this.ToolBarDate.Name = "ToolBarDate";
            this.ToolBarDate.Size = new System.Drawing.Size(31, 17);
            this.ToolBarDate.Text = "Date";
            // 
            // ToolBarTime
            // 
            this.ToolBarTime.ForeColor = System.Drawing.Color.White;
            this.ToolBarTime.Image = ((System.Drawing.Image)(resources.GetObject("ToolBarTime.Image")));
            this.ToolBarTime.Name = "ToolBarTime";
            this.ToolBarTime.Size = new System.Drawing.Size(47, 17);
            this.ToolBarTime.Text = "Time";
            // 
            // ToolBarSplite
            // 
            this.ToolBarSplite.Name = "ToolBarSplite";
            this.ToolBarSplite.Size = new System.Drawing.Size(9, 17);
            this.ToolBarSplite.Text = " ";
            // 
            // PHead
            // 
            this.PHead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.PHead.Controls.Add(this.lbl_PlcReady);
            this.PHead.Controls.Add(this.btnCodeSet);
            this.PHead.Controls.Add(this.btnLog);
            this.PHead.Controls.Add(this.btnPlcData);
            this.PHead.Controls.Add(this.btnSerch);
            this.PHead.Controls.Add(this.btnHome);
            this.PHead.Controls.Add(this.PHead1);
            this.PHead.Controls.Add(this.pictureBox1);
            this.PHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.PHead.Location = new System.Drawing.Point(0, 0);
            this.PHead.Name = "PHead";
            this.PHead.Size = new System.Drawing.Size(1280, 80);
            this.PHead.TabIndex = 30;
            // 
            // lbl_PlcReady
            // 
            this.lbl_PlcReady.BackColor = System.Drawing.Color.LemonChiffon;
            this.lbl_PlcReady.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_PlcReady.Font = new System.Drawing.Font("현대하모니 M", 14F, System.Drawing.FontStyle.Bold);
            this.lbl_PlcReady.ForeColor = System.Drawing.Color.White;
            this.lbl_PlcReady.Image = global::FrontMeasure.Properties.Resources.Close;
            this.lbl_PlcReady.Location = new System.Drawing.Point(1153, 43);
            this.lbl_PlcReady.Name = "lbl_PlcReady";
            this.lbl_PlcReady.Size = new System.Drawing.Size(127, 35);
            this.lbl_PlcReady.TabIndex = 206;
            this.lbl_PlcReady.Text = "PLC OFF";
            this.lbl_PlcReady.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCodeSet
            // 
            this.btnCodeSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnCodeSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCodeSet.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCodeSet.FlatAppearance.BorderSize = 0;
            this.btnCodeSet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aqua;
            this.btnCodeSet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.btnCodeSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCodeSet.Font = new System.Drawing.Font("현대하모니 M", 11F, System.Drawing.FontStyle.Bold);
            this.btnCodeSet.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodeSet.Image = ((System.Drawing.Image)(resources.GetObject("btnCodeSet.Image")));
            this.btnCodeSet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCodeSet.Location = new System.Drawing.Point(573, 42);
            this.btnCodeSet.Name = "btnCodeSet";
            this.btnCodeSet.Size = new System.Drawing.Size(100, 38);
            this.btnCodeSet.TabIndex = 205;
            this.btnCodeSet.Tag = "5";
            this.btnCodeSet.Text = "차종설정";
            this.btnCodeSet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolTip.SetToolTip(this.btnCodeSet, "클릭시 진행된 상황 확인 가능~!");
            this.btnCodeSet.UseVisualStyleBackColor = false;
            this.btnCodeSet.Click += new System.EventHandler(this.BtnMenu_Click);
            // 
            // btnLog
            // 
            this.btnLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLog.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLog.FlatAppearance.BorderSize = 0;
            this.btnLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aqua;
            this.btnLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.btnLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLog.Font = new System.Drawing.Font("현대하모니 M", 11F, System.Drawing.FontStyle.Bold);
            this.btnLog.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnLog.Image = ((System.Drawing.Image)(resources.GetObject("btnLog.Image")));
            this.btnLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLog.Location = new System.Drawing.Point(473, 42);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(100, 38);
            this.btnLog.TabIndex = 155;
            this.btnLog.Tag = "4";
            this.btnLog.Text = "로 그";
            this.btnLog.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolTip.SetToolTip(this.btnLog, "클릭시 진행된 상황 확인 가능~!");
            this.btnLog.UseVisualStyleBackColor = false;
            this.btnLog.Click += new System.EventHandler(this.BtnMenu_Click);
            // 
            // btnPlcData
            // 
            this.btnPlcData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnPlcData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlcData.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPlcData.FlatAppearance.BorderSize = 0;
            this.btnPlcData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aqua;
            this.btnPlcData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.btnPlcData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlcData.Font = new System.Drawing.Font("현대하모니 M", 11F, System.Drawing.FontStyle.Bold);
            this.btnPlcData.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPlcData.Image = ((System.Drawing.Image)(resources.GetObject("btnPlcData.Image")));
            this.btnPlcData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlcData.Location = new System.Drawing.Point(373, 42);
            this.btnPlcData.Name = "btnPlcData";
            this.btnPlcData.Size = new System.Drawing.Size(100, 38);
            this.btnPlcData.TabIndex = 154;
            this.btnPlcData.Tag = "3";
            this.btnPlcData.Text = "PLC";
            this.btnPlcData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolTip.SetToolTip(this.btnPlcData, "클릭시 PLC Address 관련 데이터 확인~!");
            this.btnPlcData.UseVisualStyleBackColor = false;
            this.btnPlcData.Click += new System.EventHandler(this.BtnMenu_Click);
            // 
            // btnSerch
            // 
            this.btnSerch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnSerch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSerch.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSerch.FlatAppearance.BorderSize = 0;
            this.btnSerch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aqua;
            this.btnSerch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.btnSerch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSerch.Font = new System.Drawing.Font("현대하모니 M", 11F, System.Drawing.FontStyle.Bold);
            this.btnSerch.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSerch.Image = ((System.Drawing.Image)(resources.GetObject("btnSerch.Image")));
            this.btnSerch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSerch.Location = new System.Drawing.Point(273, 42);
            this.btnSerch.Name = "btnSerch";
            this.btnSerch.Size = new System.Drawing.Size(100, 38);
            this.btnSerch.TabIndex = 153;
            this.btnSerch.Tag = "2";
            this.btnSerch.Text = "조 회";
            this.btnSerch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolTip.SetToolTip(this.btnSerch, "클릭시 데이터 조회 확인~!");
            this.btnSerch.UseVisualStyleBackColor = false;
            this.btnSerch.Click += new System.EventHandler(this.BtnMenu_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aqua;
            this.btnHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("현대하모니 M", 11F, System.Drawing.FontStyle.Bold);
            this.btnHome.ForeColor = System.Drawing.Color.Black;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(173, 42);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(100, 38);
            this.btnHome.TabIndex = 152;
            this.btnHome.Tag = "1";
            this.btnHome.Text = "Home";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolTip.SetToolTip(this.btnHome, "초기 화면으로...");
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.BtnMenu_Click);
            // 
            // PHead1
            // 
            this.PHead1.Controls.Add(this.btnSetting);
            this.PHead1.Controls.Add(this.btnExit);
            this.PHead1.Controls.Add(this.lblTitle);
            this.PHead1.Dock = System.Windows.Forms.DockStyle.Top;
            this.PHead1.Location = new System.Drawing.Point(173, 0);
            this.PHead1.Name = "PHead1";
            this.PHead1.Size = new System.Drawing.Size(1107, 42);
            this.PHead1.TabIndex = 1;
            // 
            // btnSetting
            // 
            this.btnSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(0)))), ((int)(((byte)(136)))));
            this.btnSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetting.FlatAppearance.BorderSize = 0;
            this.btnSetting.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aqua;
            this.btnSetting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetting.Font = new System.Drawing.Font("현대하모니 M", 11F, System.Drawing.FontStyle.Bold);
            this.btnSetting.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSetting.Image = ((System.Drawing.Image)(resources.GetObject("btnSetting.Image")));
            this.btnSetting.Location = new System.Drawing.Point(1030, 2);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(35, 35);
            this.btnSetting.TabIndex = 156;
            this.btnSetting.TabStop = false;
            this.btnSetting.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolTip.SetToolTip(this.btnSetting, "프로그램 설정...");
            this.btnSetting.UseVisualStyleBackColor = false;
            this.btnSetting.Visible = false;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(0)))), ((int)(((byte)(136)))));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aqua;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("현대하모니 M", 11F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(1069, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(35, 35);
            this.btnExit.TabIndex = 155;
            this.btnExit.TabStop = false;
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolTip.SetToolTip(this.btnExit, "프로그램 종료 버튼~!!!");
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(0)))), ((int)(((byte)(136)))));
            this.lblTitle.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("현대하모니 M", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1107, 42);
            this.lblTitle.TabIndex = 28;
            this.lblTitle.Text = "Program Title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::FrontMeasure.Properties.Resources.Wia;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(173, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            // 
            // PMain
            // 
            this.PMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.PMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PMain.Location = new System.Drawing.Point(0, 80);
            this.PMain.Name = "PMain";
            this.PMain.Size = new System.Drawing.Size(1280, 888);
            this.PMain.TabIndex = 31;
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1280, 990);
            this.Controls.Add(this.PMain);
            this.Controls.Add(this.PHead);
            this.Controls.Add(this.StusBar);
            this.Font = new System.Drawing.Font("현대하모니 M", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Gen2거리 측정 Program";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.StusBar.ResumeLayout(false);
            this.StusBar.PerformLayout();
            this.PHead.ResumeLayout(false);
            this.PHead1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.StatusStrip StusBar;
        internal System.Windows.Forms.ToolStripStatusLabel ToolBarDate;
        internal System.Windows.Forms.ToolStripStatusLabel ToolBarTime;
        private System.Windows.Forms.Panel PHead;
        private System.Windows.Forms.Panel PMain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel PHead1;
        internal System.Windows.Forms.Label lblTitle;
        internal System.Windows.Forms.Button btnExit;
        internal System.Windows.Forms.ToolTip ToolTip;
       
        internal System.Windows.Forms.Button btnLog;
        internal System.Windows.Forms.Button btnPlcData;
        internal System.Windows.Forms.Button btnSerch;
        internal System.Windows.Forms.Button btnHome;
        
        internal System.Windows.Forms.Button btnSetting;
        //private UC_Home uC_Home1;
        private System.Windows.Forms.ToolStripStatusLabel ToolBarSplite;
        private System.Windows.Forms.Label lbl_PlcReady;
        internal System.Windows.Forms.Button btnCodeSet;
    }
}

