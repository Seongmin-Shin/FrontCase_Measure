using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SmLibrary.Tools;
namespace FrontMeasure
{
    public partial class frmWaiting : MetroFramework.Forms.MetroForm
    {
        public frmWaiting()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                int CP_NOCLOSE_BUTTON = 0x200;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        private void frmWaiting_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            Share.DisableX(this);
        }

        private void MetroProgressSpinner1_Click(object sender, EventArgs e)
        {

        }
    }
}
