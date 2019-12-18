namespace FrontMeasure
{
    partial class UC_Record
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnFrontcase = new System.Windows.Forms.Button();
            this.btnFrontgear = new System.Windows.Forms.Button();
            this.panelHLine = new System.Windows.Forms.Panel();
            this.DGVFrontGear = new System.Windows.Forms.DataGridView();
            this.DGVFrontCase = new System.Windows.Forms.DataGridView();
            this.lblHdName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVFrontGear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVFrontCase)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Linen;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(5, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Size = new System.Drawing.Size(1260, 835);
            this.splitContainer1.SplitterDistance = 780;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.Linen;
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.splitContainer2.Panel1.Controls.Add(this.btnFrontcase);
            this.splitContainer2.Panel1.Controls.Add(this.btnFrontgear);
            this.splitContainer2.Panel1.Controls.Add(this.panelHLine);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.DGVFrontGear);
            this.splitContainer2.Panel2.Controls.Add(this.DGVFrontCase);
            this.splitContainer2.Panel2.Controls.Add(this.lblHdName);
            this.splitContainer2.Size = new System.Drawing.Size(1260, 835);
            this.splitContainer2.SplitterDistance = 33;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 1;
            // 
            // btnFrontcase
            // 
            this.btnFrontcase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnFrontcase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFrontcase.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnFrontcase.FlatAppearance.BorderSize = 0;
            this.btnFrontcase.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSpringGreen;
            this.btnFrontcase.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepPink;
            this.btnFrontcase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFrontcase.Font = new System.Drawing.Font("현대하모니 M", 11F, System.Drawing.FontStyle.Bold);
            this.btnFrontcase.ForeColor = System.Drawing.Color.White;
            this.btnFrontcase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFrontcase.Location = new System.Drawing.Point(120, 0);
            this.btnFrontcase.Name = "btnFrontcase";
            this.btnFrontcase.Size = new System.Drawing.Size(120, 28);
            this.btnFrontcase.TabIndex = 233;
            this.btnFrontcase.TabStop = false;
            this.btnFrontcase.Tag = "Front Case 단차";
            this.btnFrontcase.Text = "FrontCase";
            this.btnFrontcase.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFrontcase.UseVisualStyleBackColor = false;
            // 
            // btnFrontgear
            // 
            this.btnFrontgear.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnFrontgear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFrontgear.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnFrontgear.FlatAppearance.BorderSize = 0;
            this.btnFrontgear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSpringGreen;
            this.btnFrontgear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepPink;
            this.btnFrontgear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFrontgear.Font = new System.Drawing.Font("현대하모니 M", 11F, System.Drawing.FontStyle.Bold);
            this.btnFrontgear.ForeColor = System.Drawing.Color.Black;
            this.btnFrontgear.Image = global::FrontMeasure.Properties.Resources.check;
            this.btnFrontgear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFrontgear.Location = new System.Drawing.Point(0, 0);
            this.btnFrontgear.Name = "btnFrontgear";
            this.btnFrontgear.Size = new System.Drawing.Size(120, 28);
            this.btnFrontgear.TabIndex = 231;
            this.btnFrontgear.TabStop = false;
            this.btnFrontgear.Tag = "Front Gear 단차";
            this.btnFrontgear.Text = "FrontGear";
            this.btnFrontgear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFrontgear.UseVisualStyleBackColor = false;
            // 
            // panelHLine
            // 
            this.panelHLine.BackColor = System.Drawing.Color.DarkBlue;
            this.panelHLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelHLine.Location = new System.Drawing.Point(0, 28);
            this.panelHLine.Margin = new System.Windows.Forms.Padding(0);
            this.panelHLine.Name = "panelHLine";
            this.panelHLine.Size = new System.Drawing.Size(1258, 3);
            this.panelHLine.TabIndex = 230;
            // 
            // DGVFrontGear
            // 
            this.DGVFrontGear.AllowUserToAddRows = false;
            this.DGVFrontGear.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DGVFrontGear.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVFrontGear.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGVFrontGear.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVFrontGear.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.DGVFrontGear.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVFrontGear.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("현대하모니 M", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGVFrontGear.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVFrontGear.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("현대하모니 M", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVFrontGear.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGVFrontGear.Location = new System.Drawing.Point(246, 29);
            this.DGVFrontGear.Name = "DGVFrontGear";
            this.DGVFrontGear.ReadOnly = true;
            this.DGVFrontGear.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVFrontGear.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DGVFrontGear.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DGVFrontGear.RowTemplate.Height = 23;
            this.DGVFrontGear.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVFrontGear.ShowEditingIcon = false;
            this.DGVFrontGear.Size = new System.Drawing.Size(234, 200);
            this.DGVFrontGear.TabIndex = 171;
            this.DGVFrontGear.Tag = "Front Gear 단차";
            // 
            // DGVFrontCase
            // 
            this.DGVFrontCase.AllowUserToAddRows = false;
            this.DGVFrontCase.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DGVFrontCase.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DGVFrontCase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGVFrontCase.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVFrontCase.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.DGVFrontCase.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVFrontCase.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("현대하모니 M", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DGVFrontCase.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DGVFrontCase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("현대하모니 M", 9F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVFrontCase.DefaultCellStyle = dataGridViewCellStyle7;
            this.DGVFrontCase.Location = new System.Drawing.Point(4, 29);
            this.DGVFrontCase.Name = "DGVFrontCase";
            this.DGVFrontCase.ReadOnly = true;
            this.DGVFrontCase.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVFrontCase.RowHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DGVFrontCase.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.DGVFrontCase.RowTemplate.Height = 23;
            this.DGVFrontCase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVFrontCase.ShowEditingIcon = false;
            this.DGVFrontCase.Size = new System.Drawing.Size(236, 197);
            this.DGVFrontCase.TabIndex = 169;
            this.DGVFrontCase.Tag = "Front Case 단차";
            // 
            // lblHdName
            // 
            this.lblHdName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(228)))), ((int)(((byte)(254)))));
            this.lblHdName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHdName.Font = new System.Drawing.Font("현대하모니 M", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblHdName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblHdName.Location = new System.Drawing.Point(0, 0);
            this.lblHdName.Name = "lblHdName";
            this.lblHdName.Size = new System.Drawing.Size(1258, 23);
            this.lblHdName.TabIndex = 170;
            this.lblHdName.Text = "Front Gear 단차";
            this.lblHdName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UC_Shim
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(38)))), ((int)(((byte)(56)))));
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("현대하모니 M", 9F);
            this.Name = "UC_Shim";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(1270, 845);
            this.Load += new System.EventHandler(this.UC_Home_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVFrontGear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVFrontCase)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        internal System.Windows.Forms.DataGridView DGVFrontGear;
        internal System.Windows.Forms.DataGridView DGVFrontCase;
        internal System.Windows.Forms.Label lblHdName;
        internal System.Windows.Forms.Button btnFrontgear;
        private System.Windows.Forms.Panel panelHLine;
        internal System.Windows.Forms.Button btnFrontcase;
    }
}
