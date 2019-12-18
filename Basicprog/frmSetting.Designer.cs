namespace FrontMeasure
{
    partial class frmSetting
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
            this.btnViewSet = new MetroFramework.Controls.MetroButton();
            this.btnModify = new MetroFramework.Controls.MetroButton();
            this.btnSaveAddress = new MetroFramework.Controls.MetroButton();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage_1 = new System.Windows.Forms.TabPage();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.DGV_PlcPart = new System.Windows.Forms.DataGridView();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.DGV_BlockPart = new System.Windows.Forms.DataGridView();
            this.Splitter1 = new System.Windows.Forms.Splitter();
            this.TabPage_2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.TabControl1.SuspendLayout();
            this.TabPage_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_PlcPart)).BeginInit();
            this.GroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_BlockPart)).BeginInit();
            this.TabPage_2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnViewSet
            // 
            this.btnViewSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewSet.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnViewSet.Location = new System.Drawing.Point(691, 9);
            this.btnViewSet.Name = "btnViewSet";
            this.btnViewSet.Size = new System.Drawing.Size(141, 35);
            this.btnViewSet.TabIndex = 2;
            this.btnViewSet.Text = "ViewSetPlc";
            this.btnViewSet.UseSelectable = true;
            this.btnViewSet.Click += new System.EventHandler(this.btnViewSet_Click);
            // 
            // btnModify
            // 
            this.btnModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModify.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnModify.Location = new System.Drawing.Point(538, 9);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(141, 35);
            this.btnModify.TabIndex = 2;
            this.btnModify.Text = "Add/Modify";
            this.btnModify.UseSelectable = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnSaveAddress
            // 
            this.btnSaveAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAddress.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveAddress.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnSaveAddress.Location = new System.Drawing.Point(691, 3);
            this.btnSaveAddress.Name = "btnSaveAddress";
            this.btnSaveAddress.Size = new System.Drawing.Size(141, 35);
            this.btnSaveAddress.TabIndex = 2;
            this.btnSaveAddress.Text = "SaveAddress";
            this.btnSaveAddress.UseSelectable = true;
            this.btnSaveAddress.Click += new System.EventHandler(this.SaveAddress_Click);
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage_1);
            this.TabControl1.Controls.Add(this.TabPage_2);
            this.TabControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl1.Font = new System.Drawing.Font("현대하모니 L", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TabControl1.Location = new System.Drawing.Point(20, 60);
            this.TabControl1.Multiline = true;
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(850, 590);
            this.TabControl1.TabIndex = 3;
            // 
            // TabPage_1
            // 
            this.TabPage_1.Controls.Add(this.btnModify);
            this.TabPage_1.Controls.Add(this.btnViewSet);
            this.TabPage_1.Controls.Add(this.SplitContainer1);
            this.TabPage_1.Controls.Add(this.Splitter1);
            this.TabPage_1.Location = new System.Drawing.Point(4, 25);
            this.TabPage_1.Name = "TabPage_1";
            this.TabPage_1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_1.Size = new System.Drawing.Size(842, 561);
            this.TabPage_1.TabIndex = 1;
            this.TabPage_1.Text = "PLC설정";
            this.TabPage_1.UseVisualStyleBackColor = true;
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.Location = new System.Drawing.Point(3, 50);
            this.SplitContainer1.Name = "SplitContainer1";
            this.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.Controls.Add(this.GroupBox1);
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.GroupBox4);
            this.SplitContainer1.Size = new System.Drawing.Size(836, 508);
            this.SplitContainer1.SplitterDistance = 223;
            this.SplitContainer1.SplitterWidth = 1;
            this.SplitContainer1.TabIndex = 42;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.DGV_PlcPart);
            this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox1.Location = new System.Drawing.Point(0, 0);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(836, 223);
            this.GroupBox1.TabIndex = 6;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "PLC Part";
            // 
            // DGV_PlcPart
            // 
            this.DGV_PlcPart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGV_PlcPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_PlcPart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_PlcPart.Location = new System.Drawing.Point(3, 18);
            this.DGV_PlcPart.Name = "DGV_PlcPart";
            this.DGV_PlcPart.RowTemplate.Height = 23;
            this.DGV_PlcPart.Size = new System.Drawing.Size(830, 202);
            this.DGV_PlcPart.TabIndex = 3;
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.DGV_BlockPart);
            this.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox4.Location = new System.Drawing.Point(0, 0);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(836, 284);
            this.GroupBox4.TabIndex = 7;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Block Part";
            // 
            // DGV_BlockPart
            // 
            this.DGV_BlockPart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGV_BlockPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_BlockPart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_BlockPart.Location = new System.Drawing.Point(3, 18);
            this.DGV_BlockPart.Name = "DGV_BlockPart";
            this.DGV_BlockPart.RowTemplate.Height = 23;
            this.DGV_BlockPart.Size = new System.Drawing.Size(830, 263);
            this.DGV_BlockPart.TabIndex = 3;
            // 
            // Splitter1
            // 
            this.Splitter1.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.Splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Splitter1.Location = new System.Drawing.Point(3, 3);
            this.Splitter1.Name = "Splitter1";
            this.Splitter1.Size = new System.Drawing.Size(836, 47);
            this.Splitter1.TabIndex = 15;
            this.Splitter1.TabStop = false;
            // 
            // TabPage_2
            // 
            this.TabPage_2.Controls.Add(this.tabControl2);
            this.TabPage_2.Controls.Add(this.panel1);
            this.TabPage_2.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TabPage_2.Location = new System.Drawing.Point(4, 25);
            this.TabPage_2.Name = "TabPage_2";
            this.TabPage_2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_2.Size = new System.Drawing.Size(842, 561);
            this.TabPage_2.TabIndex = 0;
            this.TabPage_2.Text = "PLCAddress";
            this.TabPage_2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSaveAddress);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(836, 42);
            this.panel1.TabIndex = 3;
            // 
            // tabControl2
            // 
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(3, 45);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(836, 513);
            this.tabControl2.TabIndex = 4;
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 670);
            this.Controls.Add(this.TabControl1);
            this.Name = "frmSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Setting";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSetting_FormClosed);
            this.Load += new System.EventHandler(this.frmSetting_Load);
            this.TabControl1.ResumeLayout(false);
            this.TabPage_1.ResumeLayout(false);
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_PlcPart)).EndInit();
            this.GroupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_BlockPart)).EndInit();
            this.TabPage_2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroButton btnViewSet;
        private MetroFramework.Controls.MetroButton btnModify;
        private MetroFramework.Controls.MetroButton btnSaveAddress;
        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage_1;
        internal System.Windows.Forms.SplitContainer SplitContainer1;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.DataGridView DGV_PlcPart;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.DataGridView DGV_BlockPart;
        internal System.Windows.Forms.Splitter Splitter1;
        internal System.Windows.Forms.TabPage TabPage_2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl2;
    }
}