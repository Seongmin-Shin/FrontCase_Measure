namespace FrontMeasure
{
    partial class frmWaiting
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
            this.MetroProgressSpinner1 = new MetroFramework.Controls.MetroProgressSpinner();
            this.SuspendLayout();
            // 
            // MetroProgressSpinner1
            // 
            this.MetroProgressSpinner1.Location = new System.Drawing.Point(165, 63);
            this.MetroProgressSpinner1.Maximum = 100;
            this.MetroProgressSpinner1.Name = "MetroProgressSpinner1";
            this.MetroProgressSpinner1.Size = new System.Drawing.Size(80, 67);
            this.MetroProgressSpinner1.TabIndex = 1;
            this.MetroProgressSpinner1.UseSelectable = true;
            this.MetroProgressSpinner1.Value = 33;
            this.MetroProgressSpinner1.Click += new System.EventHandler(this.MetroProgressSpinner1_Click);
            // 
            // frmWaiting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 153);
            this.Controls.Add(this.MetroProgressSpinner1);
            this.Font = new System.Drawing.Font("현대하모니 M", 9F);
            this.Name = "frmWaiting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Loading...";
            this.Load += new System.EventHandler(this.frmWaiting_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal MetroFramework.Controls.MetroProgressSpinner MetroProgressSpinner1;
    }
}