namespace FrontMeasure
{
    partial class UC_DataView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_DataView));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PHead = new System.Windows.Forms.Panel();
            this.CB_TableName = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnDataView = new System.Windows.Forms.Button();
            this.eDate = new System.Windows.Forms.DateTimePicker();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.sDate = new System.Windows.Forms.DateTimePicker();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.DGVGrd = new System.Windows.Forms.DataGridView();
            this.SaveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnFix = new System.Windows.Forms.Button();
            this.txtSChkVal = new System.Windows.Forms.TextBox();
            this.txtHMd = new System.Windows.Forms.TextBox();
            this.txtSOffset = new System.Windows.Forms.TextBox();
            this.txtHGear = new System.Windows.Forms.TextBox();
            this.txtSVal = new System.Windows.Forms.TextBox();
            this.txtHMax = new System.Windows.Forms.TextBox();
            this.txtFMax = new System.Windows.Forms.TextBox();
            this.txtHMin = new System.Windows.Forms.TextBox();
            this.txtFMin = new System.Windows.Forms.TextBox();
            this.txtHVal = new System.Windows.Forms.TextBox();
            this.txtFVal = new System.Windows.Forms.TextBox();
            this.txtHBar = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtFBar = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblPart = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblWorkNo = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblWorkDate = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSGVal = new System.Windows.Forms.TextBox();
            this.txtSGChkVal = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.PHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVGrd)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PHead
            // 
            this.PHead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.PHead.Controls.Add(this.CB_TableName);
            this.PHead.Controls.Add(this.Label2);
            this.PHead.Controls.Add(this.btnExportExcel);
            this.PHead.Controls.Add(this.btnDataView);
            this.PHead.Controls.Add(this.eDate);
            this.PHead.Controls.Add(this.Label1);
            this.PHead.Controls.Add(this.Label5);
            this.PHead.Controls.Add(this.sDate);
            this.PHead.Controls.Add(this.PictureBox1);
            this.PHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.PHead.Location = new System.Drawing.Point(0, 0);
            this.PHead.Name = "PHead";
            this.PHead.Size = new System.Drawing.Size(1280, 30);
            this.PHead.TabIndex = 0;
            // 
            // CB_TableName
            // 
            this.CB_TableName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.CB_TableName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CB_TableName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_TableName.Font = new System.Drawing.Font("현대하모니 M", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CB_TableName.ForeColor = System.Drawing.Color.White;
            this.CB_TableName.FormattingEnabled = true;
            this.CB_TableName.Location = new System.Drawing.Point(136, 2);
            this.CB_TableName.Name = "CB_TableName";
            this.CB_TableName.Size = new System.Drawing.Size(222, 24);
            this.CB_TableName.TabIndex = 46;
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Label2.Font = new System.Drawing.Font("현대하모니 M", 10F);
            this.Label2.ForeColor = System.Drawing.Color.White;
            this.Label2.Location = new System.Drawing.Point(30, 8);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(100, 16);
            this.Label2.TabIndex = 45;
            this.Label2.Text = "공정 라인";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportExcel.Font = new System.Drawing.Font("현대하모니 M", 10F);
            this.btnExportExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExportExcel.Image")));
            this.btnExportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportExcel.Location = new System.Drawing.Point(1097, 4);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(82, 25);
            this.btnExportExcel.TabIndex = 43;
            this.btnExportExcel.Text = "Excel";
            this.btnExportExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnDataView
            // 
            this.btnDataView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDataView.Font = new System.Drawing.Font("현대하모니 M", 10F);
            this.btnDataView.Image = ((System.Drawing.Image)(resources.GetObject("btnDataView.Image")));
            this.btnDataView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDataView.Location = new System.Drawing.Point(1012, 4);
            this.btnDataView.Name = "btnDataView";
            this.btnDataView.Size = new System.Drawing.Size(82, 25);
            this.btnDataView.TabIndex = 44;
            this.btnDataView.Text = "Search";
            this.btnDataView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDataView.UseVisualStyleBackColor = true;
            this.btnDataView.Click += new System.EventHandler(this.btnDataView_Click);
            // 
            // eDate
            // 
            this.eDate.CalendarFont = new System.Drawing.Font("현대하모니 M", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.eDate.CalendarForeColor = System.Drawing.Color.White;
            this.eDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.eDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.eDate.Font = new System.Drawing.Font("현대하모니 M", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.eDate.Location = new System.Drawing.Point(788, 5);
            this.eDate.Name = "eDate";
            this.eDate.Size = new System.Drawing.Size(218, 22);
            this.eDate.TabIndex = 39;
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Label1.Font = new System.Drawing.Font("현대하모니 M", 10F);
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(686, 8);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(100, 16);
            this.Label1.TabIndex = 41;
            this.Label1.Text = "작업 완료일 선택";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Label5
            // 
            this.Label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Label5.Font = new System.Drawing.Font("현대하모니 M", 10F);
            this.Label5.ForeColor = System.Drawing.Color.White;
            this.Label5.Location = new System.Drawing.Point(361, 8);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(100, 16);
            this.Label5.TabIndex = 42;
            this.Label5.Text = "작업 시작일 선택";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // sDate
            // 
            this.sDate.CalendarFont = new System.Drawing.Font("현대하모니 M", 11F);
            this.sDate.CalendarForeColor = System.Drawing.Color.White;
            this.sDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.sDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sDate.CustomFormat = "yyyyMMdd";
            this.sDate.Font = new System.Drawing.Font("현대하모니 M", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sDate.Location = new System.Drawing.Point(463, 5);
            this.sDate.Name = "sDate";
            this.sDate.Size = new System.Drawing.Size(218, 22);
            this.sDate.TabIndex = 40;
            // 
            // PictureBox1
            // 
            this.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
            this.PictureBox1.Location = new System.Drawing.Point(0, 0);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(25, 30);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox1.TabIndex = 38;
            this.PictureBox1.TabStop = false;
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(122)))), ((int)(((byte)(198)))));
            this.Label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label3.Font = new System.Drawing.Font("현대하모니 M", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label3.ForeColor = System.Drawing.Color.White;
            this.Label3.Location = new System.Drawing.Point(0, 30);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(1280, 16);
            this.Label3.TabIndex = 29;
            this.Label3.Text = "<데이터>";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DGVGrd
            // 
            this.DGVGrd.AllowUserToAddRows = false;
            this.DGVGrd.AllowUserToDeleteRows = false;
            this.DGVGrd.AllowUserToResizeColumns = false;
            this.DGVGrd.AllowUserToResizeRows = false;
            this.DGVGrd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGVGrd.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVGrd.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DGVGrd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("현대하모니 M", 9F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVGrd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.DGVGrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("현대하모니 M", 9F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVGrd.DefaultCellStyle = dataGridViewCellStyle11;
            this.DGVGrd.Dock = System.Windows.Forms.DockStyle.Top;
            this.DGVGrd.GridColor = System.Drawing.Color.DarkGray;
            this.DGVGrd.Location = new System.Drawing.Point(0, 46);
            this.DGVGrd.Name = "DGVGrd";
            this.DGVGrd.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("현대하모니 M", 9F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVGrd.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.DGVGrd.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DGVGrd.RowTemplate.Height = 23;
            this.DGVGrd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVGrd.Size = new System.Drawing.Size(1280, 653);
            this.DGVGrd.TabIndex = 30;
            this.DGVGrd.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVGrd_CellClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.btnDel);
            this.panel1.Controls.Add(this.btnFix);
            this.panel1.Controls.Add(this.txtSGChkVal);
            this.panel1.Controls.Add(this.txtSChkVal);
            this.panel1.Controls.Add(this.txtHMd);
            this.panel1.Controls.Add(this.txtSOffset);
            this.panel1.Controls.Add(this.txtHGear);
            this.panel1.Controls.Add(this.txtSGVal);
            this.panel1.Controls.Add(this.txtSVal);
            this.panel1.Controls.Add(this.txtHMax);
            this.panel1.Controls.Add(this.txtFMax);
            this.panel1.Controls.Add(this.txtHMin);
            this.panel1.Controls.Add(this.txtFMin);
            this.panel1.Controls.Add(this.txtHVal);
            this.panel1.Controls.Add(this.txtFVal);
            this.panel1.Controls.Add(this.txtHBar);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.txtFBar);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.lblPart);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.lblWorkNo);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.lblWorkDate);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 699);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 189);
            this.panel1.TabIndex = 188;
            // 
            // btnDel
            // 
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDel.Font = new System.Drawing.Font("현대하모니 M", 16F, System.Drawing.FontStyle.Bold);
            this.btnDel.Location = new System.Drawing.Point(1139, 139);
            this.btnDel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(107, 29);
            this.btnDel.TabIndex = 215;
            this.btnDel.Text = "삭 제";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnFix
            // 
            this.btnFix.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFix.Font = new System.Drawing.Font("현대하모니 M", 16F, System.Drawing.FontStyle.Bold);
            this.btnFix.Location = new System.Drawing.Point(1139, 106);
            this.btnFix.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFix.Name = "btnFix";
            this.btnFix.Size = new System.Drawing.Size(107, 29);
            this.btnFix.TabIndex = 214;
            this.btnFix.Text = "수 정";
            this.btnFix.UseVisualStyleBackColor = true;
            this.btnFix.Click += new System.EventHandler(this.btnFix_Click);
            // 
            // txtSChkVal
            // 
            this.txtSChkVal.Font = new System.Drawing.Font("현대하모니 M", 14F, System.Drawing.FontStyle.Bold);
            this.txtSChkVal.Location = new System.Drawing.Point(1051, 70);
            this.txtSChkVal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSChkVal.Name = "txtSChkVal";
            this.txtSChkVal.Size = new System.Drawing.Size(97, 26);
            this.txtSChkVal.TabIndex = 213;
            // 
            // txtHMd
            // 
            this.txtHMd.Font = new System.Drawing.Font("현대하모니 M", 14F, System.Drawing.FontStyle.Bold);
            this.txtHMd.Location = new System.Drawing.Point(737, 150);
            this.txtHMd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHMd.Name = "txtHMd";
            this.txtHMd.Size = new System.Drawing.Size(223, 26);
            this.txtHMd.TabIndex = 213;
            // 
            // txtSOffset
            // 
            this.txtSOffset.Font = new System.Drawing.Font("현대하모니 M", 14F, System.Drawing.FontStyle.Bold);
            this.txtSOffset.Location = new System.Drawing.Point(1051, 43);
            this.txtSOffset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSOffset.Name = "txtSOffset";
            this.txtSOffset.Size = new System.Drawing.Size(195, 26);
            this.txtSOffset.TabIndex = 213;
            // 
            // txtHGear
            // 
            this.txtHGear.Font = new System.Drawing.Font("현대하모니 M", 14F, System.Drawing.FontStyle.Bold);
            this.txtHGear.Location = new System.Drawing.Point(737, 123);
            this.txtHGear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHGear.Name = "txtHGear";
            this.txtHGear.Size = new System.Drawing.Size(223, 26);
            this.txtHGear.TabIndex = 213;
            // 
            // txtSVal
            // 
            this.txtSVal.Font = new System.Drawing.Font("현대하모니 M", 14F, System.Drawing.FontStyle.Bold);
            this.txtSVal.Location = new System.Drawing.Point(1051, 16);
            this.txtSVal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSVal.Name = "txtSVal";
            this.txtSVal.Size = new System.Drawing.Size(97, 26);
            this.txtSVal.TabIndex = 213;
            // 
            // txtHMax
            // 
            this.txtHMax.Font = new System.Drawing.Font("현대하모니 M", 14F, System.Drawing.FontStyle.Bold);
            this.txtHMax.Location = new System.Drawing.Point(737, 96);
            this.txtHMax.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHMax.Name = "txtHMax";
            this.txtHMax.Size = new System.Drawing.Size(223, 26);
            this.txtHMax.TabIndex = 213;
            // 
            // txtFMax
            // 
            this.txtFMax.Font = new System.Drawing.Font("현대하모니 M", 14F, System.Drawing.FontStyle.Bold);
            this.txtFMax.Location = new System.Drawing.Point(406, 95);
            this.txtFMax.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFMax.Name = "txtFMax";
            this.txtFMax.Size = new System.Drawing.Size(223, 26);
            this.txtFMax.TabIndex = 213;
            // 
            // txtHMin
            // 
            this.txtHMin.Font = new System.Drawing.Font("현대하모니 M", 14F, System.Drawing.FontStyle.Bold);
            this.txtHMin.Location = new System.Drawing.Point(737, 69);
            this.txtHMin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHMin.Name = "txtHMin";
            this.txtHMin.Size = new System.Drawing.Size(223, 26);
            this.txtHMin.TabIndex = 213;
            // 
            // txtFMin
            // 
            this.txtFMin.Font = new System.Drawing.Font("현대하모니 M", 14F, System.Drawing.FontStyle.Bold);
            this.txtFMin.Location = new System.Drawing.Point(406, 68);
            this.txtFMin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFMin.Name = "txtFMin";
            this.txtFMin.Size = new System.Drawing.Size(223, 26);
            this.txtFMin.TabIndex = 213;
            // 
            // txtHVal
            // 
            this.txtHVal.Font = new System.Drawing.Font("현대하모니 M", 14F, System.Drawing.FontStyle.Bold);
            this.txtHVal.Location = new System.Drawing.Point(737, 42);
            this.txtHVal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHVal.Name = "txtHVal";
            this.txtHVal.Size = new System.Drawing.Size(223, 26);
            this.txtHVal.TabIndex = 213;
            // 
            // txtFVal
            // 
            this.txtFVal.Font = new System.Drawing.Font("현대하모니 M", 14F, System.Drawing.FontStyle.Bold);
            this.txtFVal.Location = new System.Drawing.Point(406, 41);
            this.txtFVal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFVal.Name = "txtFVal";
            this.txtFVal.Size = new System.Drawing.Size(223, 26);
            this.txtFVal.TabIndex = 213;
            // 
            // txtHBar
            // 
            this.txtHBar.Font = new System.Drawing.Font("현대하모니 M", 14F, System.Drawing.FontStyle.Bold);
            this.txtHBar.Location = new System.Drawing.Point(737, 15);
            this.txtHBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHBar.Name = "txtHBar";
            this.txtHBar.Size = new System.Drawing.Size(223, 26);
            this.txtHBar.TabIndex = 213;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label20.Font = new System.Drawing.Font("현대하모니 M", 14F);
            this.label20.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label20.Location = new System.Drawing.Point(965, 70);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(80, 27);
            this.label20.TabIndex = 195;
            this.label20.Text = "심확인값";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFBar
            // 
            this.txtFBar.Font = new System.Drawing.Font("현대하모니 M", 14F, System.Drawing.FontStyle.Bold);
            this.txtFBar.Location = new System.Drawing.Point(406, 14);
            this.txtFBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFBar.Name = "txtFBar";
            this.txtFBar.Size = new System.Drawing.Size(223, 26);
            this.txtFBar.TabIndex = 213;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label17.Font = new System.Drawing.Font("현대하모니 M", 14F);
            this.label17.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label17.Location = new System.Drawing.Point(633, 150);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(98, 27);
            this.label17.TabIndex = 195;
            this.label17.Text = "기준거리";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label19.Font = new System.Drawing.Font("현대하모니 M", 14F);
            this.label19.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label19.Location = new System.Drawing.Point(965, 43);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(80, 27);
            this.label19.TabIndex = 195;
            this.label19.Text = "심오프셋";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPart
            // 
            this.lblPart.BackColor = System.Drawing.Color.DarkGray;
            this.lblPart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPart.Font = new System.Drawing.Font("현대하모니 M", 14F);
            this.lblPart.ForeColor = System.Drawing.Color.Black;
            this.lblPart.Location = new System.Drawing.Point(116, 95);
            this.lblPart.Name = "lblPart";
            this.lblPart.Size = new System.Drawing.Size(181, 40);
            this.lblPart.TabIndex = 195;
            this.lblPart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label16.Font = new System.Drawing.Font("현대하모니 M", 14F);
            this.label16.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label16.Location = new System.Drawing.Point(633, 123);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(98, 27);
            this.label16.TabIndex = 195;
            this.label16.Text = "기어번호";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label18.Font = new System.Drawing.Font("현대하모니 M", 14F);
            this.label18.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label18.Location = new System.Drawing.Point(965, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 27);
            this.label18.TabIndex = 195;
            this.label18.Text = "심값";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("현대하모니 M", 16F);
            this.label8.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Location = new System.Drawing.Point(9, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 40);
            this.label8.TabIndex = 195;
            this.label8.Text = "PART :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label15.Font = new System.Drawing.Font("현대하모니 M", 14F);
            this.label15.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label15.Location = new System.Drawing.Point(633, 96);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(98, 27);
            this.label15.TabIndex = 195;
            this.label15.Text = "(P)상한값";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblWorkNo
            // 
            this.lblWorkNo.BackColor = System.Drawing.Color.DarkGray;
            this.lblWorkNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblWorkNo.Font = new System.Drawing.Font("현대하모니 M", 14F);
            this.lblWorkNo.ForeColor = System.Drawing.Color.Black;
            this.lblWorkNo.Location = new System.Drawing.Point(116, 54);
            this.lblWorkNo.Name = "lblWorkNo";
            this.lblWorkNo.Size = new System.Drawing.Size(181, 40);
            this.lblWorkNo.TabIndex = 195;
            this.lblWorkNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Font = new System.Drawing.Font("현대하모니 M", 14F);
            this.label12.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label12.Location = new System.Drawing.Point(302, 95);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 27);
            this.label12.TabIndex = 195;
            this.label12.Text = "(L)상한값";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label14.Font = new System.Drawing.Font("현대하모니 M", 14F);
            this.label14.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label14.Location = new System.Drawing.Point(633, 69);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(98, 27);
            this.label14.TabIndex = 195;
            this.label14.Text = "(P)하한값";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("현대하모니 M", 16F);
            this.label9.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label9.Location = new System.Drawing.Point(9, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 40);
            this.label9.TabIndex = 195;
            this.label9.Text = "생산순번 :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("현대하모니 M", 14F);
            this.label11.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label11.Location = new System.Drawing.Point(302, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 27);
            this.label11.TabIndex = 195;
            this.label11.Text = "(L)하한값";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label13.Font = new System.Drawing.Font("현대하모니 M", 14F);
            this.label13.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label13.Location = new System.Drawing.Point(633, 42);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 27);
            this.label13.TabIndex = 195;
            this.label13.Text = "(P)단차값";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblWorkDate
            // 
            this.lblWorkDate.BackColor = System.Drawing.Color.DarkGray;
            this.lblWorkDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblWorkDate.Font = new System.Drawing.Font("현대하모니 M", 14F);
            this.lblWorkDate.ForeColor = System.Drawing.Color.Black;
            this.lblWorkDate.Location = new System.Drawing.Point(116, 13);
            this.lblWorkDate.Name = "lblWorkDate";
            this.lblWorkDate.Size = new System.Drawing.Size(181, 40);
            this.lblWorkDate.TabIndex = 195;
            this.lblWorkDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("현대하모니 M", 14F);
            this.label10.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label10.Location = new System.Drawing.Point(302, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 27);
            this.label10.TabIndex = 195;
            this.label10.Text = "(L)단차값";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("현대하모니 M", 14F);
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(633, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 27);
            this.label4.TabIndex = 195;
            this.label4.Text = "(P)바코드";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("현대하모니 M", 16F);
            this.label7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Location = new System.Drawing.Point(9, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 40);
            this.label7.TabIndex = 195;
            this.label7.Text = "생산일자 :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("현대하모니 M", 14F);
            this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(302, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 27);
            this.label6.TabIndex = 195;
            this.label6.Text = "(L)바코드";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSGVal
            // 
            this.txtSGVal.Font = new System.Drawing.Font("현대하모니 M", 14F, System.Drawing.FontStyle.Bold);
            this.txtSGVal.Location = new System.Drawing.Point(1149, 16);
            this.txtSGVal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSGVal.Name = "txtSGVal";
            this.txtSGVal.Size = new System.Drawing.Size(97, 26);
            this.txtSGVal.TabIndex = 213;
            // 
            // txtSGChkVal
            // 
            this.txtSGChkVal.Font = new System.Drawing.Font("현대하모니 M", 14F, System.Drawing.FontStyle.Bold);
            this.txtSGChkVal.Location = new System.Drawing.Point(1149, 70);
            this.txtSGChkVal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSGChkVal.Name = "txtSGChkVal";
            this.txtSGChkVal.Size = new System.Drawing.Size(97, 26);
            this.txtSGChkVal.TabIndex = 213;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label21.Font = new System.Drawing.Font("현대하모니 M", 8F);
            this.label21.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label21.Location = new System.Drawing.Point(1149, 3);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(97, 12);
            this.label21.TabIndex = 216;
            this.label21.Text = "Gen 2";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label22.Font = new System.Drawing.Font("현대하모니 M", 8F);
            this.label22.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label22.Location = new System.Drawing.Point(1051, 3);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(97, 12);
            this.label22.TabIndex = 217;
            this.label22.Text = "일반";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UC_DataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DGVGrd);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.PHead);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("현대하모니 M", 9F);
            this.Name = "UC_DataView";
            this.Size = new System.Drawing.Size(1280, 888);
            this.Load += new System.EventHandler(this.UC_DataView_Load);
            this.PHead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVGrd)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PHead;
        internal System.Windows.Forms.ComboBox CB_TableName;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button btnExportExcel;
        internal System.Windows.Forms.Button btnDataView;
        internal System.Windows.Forms.DateTimePicker eDate;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.DateTimePicker sDate;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.DataGridView DGVGrd;
        internal System.Windows.Forms.SaveFileDialog SaveFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnFix;
        private System.Windows.Forms.TextBox txtSChkVal;
        private System.Windows.Forms.TextBox txtHMd;
        private System.Windows.Forms.TextBox txtSOffset;
        private System.Windows.Forms.TextBox txtHGear;
        private System.Windows.Forms.TextBox txtSVal;
        private System.Windows.Forms.TextBox txtHMax;
        private System.Windows.Forms.TextBox txtFMax;
        private System.Windows.Forms.TextBox txtHMin;
        private System.Windows.Forms.TextBox txtFMin;
        private System.Windows.Forms.TextBox txtHVal;
        private System.Windows.Forms.TextBox txtFVal;
        private System.Windows.Forms.TextBox txtHBar;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtFBar;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblPart;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblWorkNo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblWorkDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtSGChkVal;
        private System.Windows.Forms.TextBox txtSGVal;
    }
}
