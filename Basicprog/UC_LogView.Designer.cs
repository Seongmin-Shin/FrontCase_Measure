namespace FrontMeasure
{
    partial class UC_LogView
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
            this.spc_Main = new System.Windows.Forms.SplitContainer();
            this.txtProcessLog = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtErrorLog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spc_Main)).BeginInit();
            this.spc_Main.Panel1.SuspendLayout();
            this.spc_Main.Panel2.SuspendLayout();
            this.spc_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // spc_Main
            // 
            this.spc_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spc_Main.Location = new System.Drawing.Point(20, 20);
            this.spc_Main.Name = "spc_Main";
            // 
            // spc_Main.Panel1
            // 
            this.spc_Main.Panel1.Controls.Add(this.txtProcessLog);
            this.spc_Main.Panel1.Controls.Add(this.Label3);
            // 
            // spc_Main.Panel2
            // 
            this.spc_Main.Panel2.Controls.Add(this.txtErrorLog);
            this.spc_Main.Panel2.Controls.Add(this.label1);
            this.spc_Main.Size = new System.Drawing.Size(1240, 848);
            this.spc_Main.SplitterDistance = 599;
            this.spc_Main.SplitterWidth = 2;
            this.spc_Main.TabIndex = 0;
            // 
            // txtProcessLog
            // 
            this.txtProcessLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProcessLog.Font = new System.Drawing.Font("현대하모니 L", 12F);
            this.txtProcessLog.Location = new System.Drawing.Point(0, 16);
            this.txtProcessLog.Multiline = true;
            this.txtProcessLog.Name = "txtProcessLog";
            this.txtProcessLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtProcessLog.Size = new System.Drawing.Size(599, 832);
            this.txtProcessLog.TabIndex = 32;
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.Label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label3.Font = new System.Drawing.Font("현대하모니 M", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.Label3.Location = new System.Drawing.Point(0, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(599, 16);
            this.Label3.TabIndex = 30;
            this.Label3.Text = "<Process Note>";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtErrorLog
            // 
            this.txtErrorLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtErrorLog.Font = new System.Drawing.Font("현대하모니 L", 12F);
            this.txtErrorLog.Location = new System.Drawing.Point(0, 16);
            this.txtErrorLog.Multiline = true;
            this.txtErrorLog.Name = "txtErrorLog";
            this.txtErrorLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtErrorLog.Size = new System.Drawing.Size(639, 832);
            this.txtErrorLog.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(87)))), ((int)(((byte)(181)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("현대하모니 M", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(639, 16);
            this.label1.TabIndex = 30;
            this.label1.Text = "<Error Note>";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UC_LogView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Controls.Add(this.spc_Main);
            this.Font = new System.Drawing.Font("현대하모니 M", 9F);
            this.Name = "UC_LogView";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Size = new System.Drawing.Size(1280, 888);
            this.Load += new System.EventHandler(this.UC_LogView_Load);
            this.spc_Main.Panel1.ResumeLayout(false);
            this.spc_Main.Panel1.PerformLayout();
            this.spc_Main.Panel2.ResumeLayout(false);
            this.spc_Main.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spc_Main)).EndInit();
            this.spc_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spc_Main;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtProcessLog;
        public System.Windows.Forms.TextBox txtErrorLog;
    }
}
