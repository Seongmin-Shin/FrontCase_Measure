namespace FrontMeasure
{
    partial class UC_PlcDataState
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.PHead = new System.Windows.Forms.Panel();
            this.lblPlcMsg = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControlPLC = new System.Windows.Forms.TabControl();
            this.PHead.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PHead
            // 
            this.PHead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.PHead.Controls.Add(this.lblPlcMsg);
            this.PHead.Controls.Add(this.label2);
            this.PHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.PHead.Location = new System.Drawing.Point(10, 10);
            this.PHead.Name = "PHead";
            this.PHead.Size = new System.Drawing.Size(1260, 82);
            this.PHead.TabIndex = 40;
            // 
            // lblPlcMsg
            // 
            this.lblPlcMsg.AutoSize = true;
            this.lblPlcMsg.Font = new System.Drawing.Font("현대하모니 M", 11F);
            this.lblPlcMsg.ForeColor = System.Drawing.Color.White;
            this.lblPlcMsg.Location = new System.Drawing.Point(107, 37);
            this.lblPlcMsg.Name = "lblPlcMsg";
            this.lblPlcMsg.Size = new System.Drawing.Size(100, 15);
            this.lblPlcMsg.TabIndex = 0;
            this.lblPlcMsg.Text = "Plc 통신 속도 : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("현대하모니 M", 11F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(14, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "<Plc Status>";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(10, 92);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1260, 786);
            this.tabControl1.TabIndex = 41;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tabControlPLC);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1252, 760);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "PLC Data";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControlPLC
            // 
            this.tabControlPLC.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControlPLC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPLC.Location = new System.Drawing.Point(3, 3);
            this.tabControlPLC.Multiline = true;
            this.tabControlPLC.Name = "tabControlPLC";
            this.tabControlPLC.SelectedIndex = 0;
            this.tabControlPLC.Size = new System.Drawing.Size(1246, 754);
            this.tabControlPLC.TabIndex = 42;
            // 
            // UC_PlcDataState
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(38)))), ((int)(((byte)(56)))));
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.PHead);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("현대하모니 M", 9F);
            this.Name = "UC_PlcDataState";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(1280, 888);
            this.Load += new System.EventHandler(this.UC_PlcDataState_Load);
            this.PHead.ResumeLayout(false);
            this.PHead.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PHead;
        private System.Windows.Forms.Label lblPlcMsg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.TabControl tabControlPLC;
    }
}
