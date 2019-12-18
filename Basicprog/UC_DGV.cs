using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SmLibrary.Tools;
namespace FrontMeasure
{
    public partial class UC_DGV : UserControl
    {
        public UC_DGV()
        {
            InitializeComponent();
        }

        private void UC_DGV_Load(object sender, EventArgs e)
        {
            DGVPlc.DoubleBuffered(true);
        }
    }
}
