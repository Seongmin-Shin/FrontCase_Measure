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

namespace FrontMeasure
{
    public partial class UC_Record : UserControl
    {
        
        private IinterRef I_Home = null;
        private Dictionary<string, Button> btnMenus = new Dictionary<string, Button>();
        private Dictionary<WorkStep, DataGridView> DGVMenus = new Dictionary<WorkStep, DataGridView>();
        
       
        public UC_Record(IinterRef I_Home)
        {
            InitializeComponent();
            this.I_Home = I_Home;

            foreach (Button btn in splitContainer2.Panel1.Controls.OfType<Button>())
            {
                //Array.Resize(ref btnMenus, i + 1);
                //btnMenus[i] = btn;
                btnMenus.Add(btn.Text, btn);
                btnMenus[btn.Text].Click += btn_HeaderMuClick;        
            }
            foreach(DataGridView dgv in splitContainer2.Panel2.Controls.OfType<DataGridView>())
            {
                dgv.DoubleBuffered();
                dgv.Dock = DockStyle.Fill;                
            }
            DGVMenus.Add(WorkStep.FrontGear, DGVFrontGear);
            DGVMenus.Add(WorkStep.FrontCase, DGVFrontCase);
            DGVFrontGear.BringToFront();
            lblHdName.Text = btnFrontgear.Tag.ToString();
           
        }

        private void btn_HeaderMuClick(object sender, EventArgs e)
        {
            Button sendbtn = sender as Button;
            lblHdName.Text = sendbtn.Tag.ToString();
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
                        item.Value.BackColor = Color.LightGoldenrodYellow;
                        item.Value.ForeColor = Color.Black;
                        item.Value.Image = Properties.Resources.check;
                        //idx = Array.FindIndex(Uc_Subitem, item => (string)item.Tag == (string)btnMenus[i].Tag);
                    }
                }

                foreach (KeyValuePair<WorkStep, DataGridView> item in DGVMenus)
                {
                    if (sendbtn.Tag == item.Value.Tag)
                    {
                        //item.Visible = true;
                        item.Value.BringToFront();
                        if (item.Value.Rows.Count > 0)
                        {
                            item.Value.FirstDisplayedScrollingRowIndex = item.Value.RowCount - 1;
                            item.Value.Rows[0].Selected = false;
                            item.Value.CurrentCell.Selected = false;
                        }
                    }
                    else
                    {
                        //item.Visible = false;
                        item.Value.SendToBack();
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

        List<TB_GearFront> lstGearfrt;
        List<TB_FrontCase> lstFrtCase;
        private void UC_Home_Load(object sender, EventArgs e)
        {
            try
            {     
                DGVFrontGear.ColumnInitial(typeof(TB_GearFront));
                DGVFrontCase.ColumnInitial(typeof(TB_FrontCase));
              
                Task.Run(()=> ShowData(201910209));   
            }
            catch (Exception ex)
            {
                StackTrace trace = new StackTrace(ex, true);
                StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                int lineNumber = stackFrame.GetFileLineNumber();

                I_Home.ErrorLog(($" ({lineNumber}) : {ex.ToString()}"));
            }
        }        
        internal async Task ShowData(int iworkdate)
        {
            try
            {               
                using (GEN2_MEASUREDBEntities db = new GEN2_MEASUREDBEntities())
                {                   
                    lstGearfrt = await db.TB_GearFront.SqlQuery($"Select * from TB_GearFront ").ToListAsync();                    
                    lstFrtCase = await db.TB_FrontCase.SqlQuery($"Select * from TB_FrontCase ").ToListAsync();
                                        
                    for (int i = 0; i < lstGearfrt.Count; i++)
                    {
                        List<string> addrow = new List<string>();
                        addrow.Add(lstGearfrt[i].Insert_Time.ToString());
                        addrow.Add(lstGearfrt[i].Work_Date.ToString());
                        addrow.Add(lstGearfrt[i].Work_No.ToString());
                        addrow.Add(lstGearfrt[i].GearNo_Front.ToString());
                        addrow.Add(lstGearfrt[i].GearNo_4WD.ToString());                        
                        addrow.Add(lstGearfrt[i].Part_Name.ToString());

                        addrow.Add(lstGearfrt[i].FGear_G4_Min.ToString());
                        addrow.Add(lstGearfrt[i].FGear_G4_Val.ToString());
                        addrow.Add(lstGearfrt[i].FGear_G4_Max.ToString());
                        
                        addrow.Add(lstGearfrt[i].FGear_G2_Min.ToString());
                        addrow.Add(lstGearfrt[i].FGear_G2_Val.ToString());
                        addrow.Add(lstGearfrt[i].FGear_G2_Max.ToString());
                        
                        BeginInvoke((Action)(() =>
                        {
                            DGVFrontGear.AddGridrow(addrow.ToArray());
                        }));
                    }

                    for (int i = 0; i < lstFrtCase.Count; i++)
                    {
                        List<string> addrow = new List<string>();
                        addrow.Add(lstFrtCase[i].Insert_Time.ToString());
                        addrow.Add(lstFrtCase[i].Work_Date.ToString());
                        addrow.Add(lstFrtCase[i].Work_No.ToString());
                        addrow.Add(lstFrtCase[i].FrontCase_Bar.ToString());
                        addrow.Add(lstFrtCase[i].Part_Name.ToString());

                        addrow.Add(lstFrtCase[i].FCase_4WD_Min.ToString());
                        addrow.Add(lstFrtCase[i].FCase_4WD_Val.ToString());
                        addrow.Add(lstFrtCase[i].FCase_4WD_Max.ToString());

                        addrow.Add(lstFrtCase[i].FCase_G4_Min.ToString());
                        addrow.Add(lstFrtCase[i].FCase_G4_Val.ToString());
                        addrow.Add(lstFrtCase[i].FCase_G4_Max.ToString());

                        BeginInvoke((Action)(() =>
                        {
                            DGVFrontCase.AddGridrow(addrow.ToArray());
                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                StackTrace trace = new StackTrace(ex, true);
                StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                int lineNumber = stackFrame.GetFileLineNumber();

                I_Home.ErrorLog(($" ({lineNumber}) : {ex.ToString()}"));
            }
        }
        internal async Task AddGridView(frmMain.GData gData, WorkStep key)
        {
            List<string> addrow = new List<string>();
            if (key == WorkStep.FrontGear)
            {
                TB_GearFront tmp = gData._GearFront;
                tmp.Insert_Time = DateTime.Now;

                addrow.Add(tmp.Insert_Time.ToString());
                addrow.Add(tmp.Work_Date.ToString());
                addrow.Add(tmp.GearNo_4WD.ToString());
                addrow.Add(tmp.GearNo_Front.ToString());
                addrow.Add(tmp.Part_Name.ToString());

                addrow.Add(tmp.FGear_G4_Min.ToString());
                addrow.Add(tmp.FGear_G4_Val.ToString());
                addrow.Add(tmp.FGear_G4_Max.ToString());

                addrow.Add(tmp.FGear_G2_Min.ToString());
                addrow.Add(tmp.FGear_G2_Val.ToString());
                addrow.Add(tmp.FGear_G2_Max.ToString());
            }
            else if (key == WorkStep.FrontCase)
            {
                TB_FrontCase tmp = gData._FrontCase;
                tmp.Insert_Time = DateTime.Now;

                addrow.Add(tmp.Insert_Time.ToString());
                addrow.Add(tmp.Work_Date.ToString());
                addrow.Add(tmp.FrontCase_Bar.ToString());
                addrow.Add(tmp.Part_Name.ToString());

                addrow.Add(tmp.FCase_4WD_Min.ToString());
                addrow.Add(tmp.FCase_4WD_Val.ToString());
                addrow.Add(tmp.FCase_4WD_Max.ToString());

                addrow.Add(tmp.FCase_G4_Min.ToString());
                addrow.Add(tmp.FCase_G4_Val.ToString());
                addrow.Add(tmp.FCase_G4_Max.ToString());
            }

            await Task.Run(() => DGVAddRow(key, addrow.ToArray()));
        }
    
    private void DGVAddRow(WorkStep keyname, string[] aydata)
    {
        BeginInvoke((Action)(() =>
        {
            DGVMenus[keyname].AddGridrow(aydata);               
        }));
    }
      
        //internal void AddGridrow(this DataGridView dataGrid, string[] dataRow)
        //{
        //    //BeginInvoke((Action)(() =>
        //    //{
        //        //I_Sub.ProcessLog("Update MA010!!!");

        //        dataGrid.Rows.Add(dataRow);
        //        if (dataGrid.Rows.Count > 0)
        //        {
        //            dataGrid.FirstDisplayedScrollingRowIndex = dataGrid.RowCount - 1;
        //            dataGrid.CurrentCell.Selected = false;
        //        }
        //    //}));
        //}
    }
}
