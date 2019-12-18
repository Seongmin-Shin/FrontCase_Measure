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
using System.Diagnostics;
using System.Data.SqlClient;
using SmLibrary.Net;
using Microsoft.VisualBasic;
using System.Threading;
//using FrontMeasure.SubItem;

namespace FrontMeasure
{
    public interface InterHome
    {
        void btn_HeaderMuClick(object sender, EventArgs e);
    }
    public partial class UC_Home : UserControl, InterHome
    {
        private IinterRef I_Home = null;
        delegate void StringlblDelegate(string text, Label lbl);

        public static Dictionary<string, Button> btnMenus = new Dictionary<string, Button>();
        //internal Button[] btnMenus = new Button[1];
        internal UserControl[] Uc_Subitem = new UserControl[2];
        //internal Dictionary<string, UserControl> Uc_Subitem = new Dictionary<string, UserControl>();
        internal UC_Measure uC_Measure;
        internal UC_Record uC_Record;

        public UC_Home(IinterRef I_Home)
        {
            InitializeComponent();
            this.I_Home = I_Home;
            #region ################### Add UserControls ###################

            uC_Measure = new UC_Measure(I_Home);
            uC_Record = new UC_Record(I_Home);
            //Uc_Subitem.Add("STATUS", new UC_Sub_MAIN(I_Home));
            uC_Measure.Tag = btnMeasure.Tag;
            uC_Record.Tag = btnShim.Tag;
            Uc_Subitem[0] = uC_Measure;
            Uc_Subitem[1] = uC_Record;

            int i = 0;
            foreach (UserControl item in Uc_Subitem)
            {
                item.Font = new Font("현대하모니 M", 9F);
                item.BackColor = Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
                item.TabIndex = i;
                item.Padding = new Padding(2);
                item.Size = new Size(331, 228);
                item.Location = new Point(22, 278);

                PanSubItem.Controls.Add(item);
                item.Dock = DockStyle.Fill;
                item.Visible = true;

                i++;
            }

            i = 0;
            foreach (Button btn in metroPanel1.Controls.OfType<Button>())
            {
                //Array.Resize(ref btnMenus, i + 1);
                //btnMenus[i] = btn;
                btnMenus.Add(btn.Text, btn);
                btnMenus[btn.Text].Click += btn_HeaderMuClick;
                i++;
            }
            Uc_Subitem[0].Visible = true;
            Uc_Subitem[0].BringToFront();
            #endregion
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                base.OnPaint(e);
            }
            catch (Exception ex)
            {
                StackTrace trace = new StackTrace(ex, true);
                StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                int lineNumber = stackFrame.GetFileLineNumber();

                I_Home.ErrorLog(($" ({lineNumber})[OnPaint] : {ex.ToString()}"));
                this.Invalidate();
            }

        }
        private void UC_Home_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                StackTrace trace = new StackTrace(ex, true);
                StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                int lineNumber = stackFrame.GetFileLineNumber();

                I_Home.ErrorLog(($" ({lineNumber}) : {ex.ToString()}"));
            }
        }

        public void btn_HeaderMuClick(object sender, EventArgs e)
        {
            Button sendbtn = sender as Button;
            try
            {

                foreach (KeyValuePair<string, Button> item in btnMenus)
                {
                    if (sendbtn.Tag != item.Value.Tag)
                    {
                        item.Value.BackColor = Color.FromArgb(28, 28, 28);
                        item.Value.ForeColor = Color.WhiteSmoke;
                        item.Value.Image = null;

                    }
                    else
                    {
                        item.Value.BackColor = Color.DarkSeaGreen;
                        item.Value.ForeColor = Color.Black;
                        item.Value.Image = Properties.Resources.check;
                        //idx = Array.FindIndex(Uc_Subitem, item => (string)item.Tag == (string)btnMenus[i].Tag);
                    }
                }

                foreach (UserControl item in Uc_Subitem)
                {
                    if (sendbtn.Tag == item.Tag)
                    {
                        item.Visible = true;
                        item.BringToFront();
                    }
                    else
                    {
                        item.Visible = false;
                        item.SendToBack();
                    }
                }

            }
            catch (Exception ex)
            {
                StackTrace trace = new StackTrace(ex, true);
                StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                int lineNumber = stackFrame.GetFileLineNumber();

                I_Home.ErrorLog(($"btn_HeaderMuClick_Err({lineNumber}) : {ex.ToString()}"));
            }

        }

        internal void ShowMeasure(frmMain.GData gData, WorkStep key)
        {
            Task.Run(() => uC_Measure.UpdateData(gData, key));
            Task.Run(() => uC_Record.AddGridView(gData, key));
        }
        internal void ShowShim(frmMain.PlcReference refplc, int shimno, double selshim, WorkStep index = WorkStep.FrontShim)
        {
            Task.Run(() => uC_Measure.ShowShim(refplc, shimno, selshim, index));
            Task.Run(() => uC_Measure.ShowShimVal(shimno, selshim, index));
            Task.Run(() => uC_Measure.ShowShimDGV(refplc.WorkDate, uC_Measure.DGVShim_Fc , refplc.WorkNo));
        }
    }
}
