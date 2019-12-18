namespace FrontMeasure
{
    partial class UC_Home
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
            this.components = new System.ComponentModel.Container();
            this.TTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnShim = new System.Windows.Forms.Button();
            this.btnMeasure = new System.Windows.Forms.Button();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.panelHLine = new System.Windows.Forms.Panel();
            this.PanSubItem = new System.Windows.Forms.Panel();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnShim
            // 
            this.btnShim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnShim.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShim.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnShim.FlatAppearance.BorderSize = 0;
            this.btnShim.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aqua;
            this.btnShim.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.btnShim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShim.Font = new System.Drawing.Font("현대하모니 M", 11F, System.Drawing.FontStyle.Bold);
            this.btnShim.ForeColor = System.Drawing.Color.White;
            this.btnShim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShim.Location = new System.Drawing.Point(100, 0);
            this.btnShim.Name = "btnShim";
            this.btnShim.Size = new System.Drawing.Size(100, 30);
            this.btnShim.TabIndex = 190;
            this.btnShim.TabStop = false;
            this.btnShim.Tag = "Shim";
            this.btnShim.Text = "이 력";
            this.btnShim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.TTip.SetToolTip(this.btnShim, "측정 이력 확인");
            this.btnShim.UseVisualStyleBackColor = false;
            this.btnShim.Click += new System.EventHandler(this.btn_HeaderMuClick);
            // 
            // btnMeasure
            // 
            this.btnMeasure.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnMeasure.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMeasure.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMeasure.FlatAppearance.BorderSize = 0;
            this.btnMeasure.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aqua;
            this.btnMeasure.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.btnMeasure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMeasure.Font = new System.Drawing.Font("현대하모니 M", 11F, System.Drawing.FontStyle.Bold);
            this.btnMeasure.ForeColor = System.Drawing.Color.White;
            this.btnMeasure.Image = global::FrontMeasure.Properties.Resources.check;
            this.btnMeasure.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMeasure.Location = new System.Drawing.Point(0, 0);
            this.btnMeasure.Name = "btnMeasure";
            this.btnMeasure.Size = new System.Drawing.Size(100, 30);
            this.btnMeasure.TabIndex = 229;
            this.btnMeasure.TabStop = false;
            this.btnMeasure.Tag = "Measure";
            this.btnMeasure.Text = "측 정";
            this.btnMeasure.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.TTip.SetToolTip(this.btnMeasure, "단차 측정 값 확인");
            this.btnMeasure.UseVisualStyleBackColor = false;
            // 
            // metroPanel1
            // 
            this.metroPanel1.AutoScroll = true;
            this.metroPanel1.BackColor = System.Drawing.Color.DarkGray;
            this.metroPanel1.Controls.Add(this.btnShim);
            this.metroPanel1.Controls.Add(this.btnMeasure);
            this.metroPanel1.Controls.Add(this.panelHLine);
            this.metroPanel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel1.HorizontalScrollbar = true;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 5;
            this.metroPanel1.Location = new System.Drawing.Point(5, 5);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1270, 33);
            this.metroPanel1.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroPanel1.TabIndex = 2;
            this.metroPanel1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroPanel1.VerticalScrollbar = true;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // panelHLine
            // 
            this.panelHLine.BackColor = System.Drawing.Color.Maroon;
            this.panelHLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelHLine.Location = new System.Drawing.Point(0, 30);
            this.panelHLine.Margin = new System.Windows.Forms.Padding(0);
            this.panelHLine.Name = "panelHLine";
            this.panelHLine.Size = new System.Drawing.Size(1270, 3);
            this.panelHLine.TabIndex = 187;
            // 
            // PanSubItem
            // 
            this.PanSubItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.PanSubItem.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.PanSubItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanSubItem.Location = new System.Drawing.Point(5, 38);
            this.PanSubItem.Name = "PanSubItem";
            this.PanSubItem.Size = new System.Drawing.Size(1270, 845);
            this.PanSubItem.TabIndex = 4;
            this.PanSubItem.Click += new System.EventHandler(this.btn_HeaderMuClick);
            // 
            // UC_Home
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(38)))), ((int)(((byte)(56)))));
            this.Controls.Add(this.PanSubItem);
            this.Controls.Add(this.metroPanel1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("현대하모니 M", 9F);
            this.Name = "UC_Home";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(1280, 888);
            this.Load += new System.EventHandler(this.UC_Home_Load);
            this.metroPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.ToolTip TTip;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        internal System.Windows.Forms.Button btnShim;
        private System.Windows.Forms.Panel panelHLine;
        public System.Windows.Forms.Panel PanSubItem;
        internal System.Windows.Forms.Button btnMeasure;
    }
}
