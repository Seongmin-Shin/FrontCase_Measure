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
    public enum WorkStep
    {
        FrontGear,
        Gear4WD,
        FrontCase,
        FrontShim,
        IMCase4WD,
        IMCaseFront,
        IMCaseShim
    }
    public partial class UC_Measure : UserControl
    {
        private IinterRef I_Home = null;

        private Dictionary<WorkStep, DataGridView> DGVMenus = new Dictionary<WorkStep, DataGridView>();
        
        public UC_Measure(IinterRef I_Home)
        {
            InitializeComponent();
            this.I_Home = I_Home;

            DGVMenus.Add(WorkStep.FrontGear, DGVFGear);
            DGVMenus.Add(WorkStep.FrontCase, DGVFCase);
           
        }

        private void UC_Home_Load(object sender, EventArgs e)
        {
            try
            {
                rcvProcess = lvNotice;

                rcvProcess.Columns.Add("NOTICE", "");
                rcvProcess.GridLines = true;
                rcvProcess.FullRowSelect = true;
                rcvProcess.Columns["NOTICE"].TextAlign = HorizontalAlignment.Center;
                rcvProcess.Columns["NOTICE"].Width = -2;
                rcvProcess.HeaderStyle = ColumnHeaderStyle.None;

                DGVFGear.DoubleBuffered();
                DGVFCase.DoubleBuffered();
                DGVShim_Fc.DoubleBuffered();

                DGVFGear.Font = new Font("현대하모니 M", 17f, FontStyle.Regular, GraphicsUnit.Point, Convert.ToByte(129));
                DGVFCase.Font = new Font("현대하모니 M", 17f, FontStyle.Regular, GraphicsUnit.Point, Convert.ToByte(129)); 
                DGVShim_Fc.Font = new Font("현대하모니 M", 17f, FontStyle.Regular, GraphicsUnit.Point, Convert.ToByte(129));
                
                DGVShim_Fc.RowCount = 1;
                DGVShim_Fc["NumG4", 0].Value = "0001";
                DGVShim_Fc["ShimG4", 0].Value = "122.123";

                HomeInitial(20191205);                
            }
            catch (Exception ex)
            {
                StackTrace trace = new StackTrace(ex, true);
                StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                int lineNumber = stackFrame.GetFileLineNumber();

                I_Home.ErrorLog(($" ({lineNumber}) : {ex.ToString()}"));
            }
        }

        #region ################### 메소드 ###################
        private DateTime dDate_Process = DateTime.Now.Date;
        private DateTime dPreDate_Process = DateTime.Now.Date;
        internal ListView rcvProcess;
        private ListViewItem _Commprocess;
        internal void Noticeview(string notice)
        {
            BeginInvoke((Action)(() =>
            {
                try
                {
                    dPreDate_Process = DateTime.Now.Date;
                    if (dDate_Process != dPreDate_Process)
                    {
                        dDate_Process = dPreDate_Process;
                        rcvProcess.Items.Clear();
                    }
                    if (rcvProcess.Items.Count > 200)
                        rcvProcess.Items.RemoveAt(0);

                    _Commprocess = rcvProcess.Items.Add($"{DateTime.Now.ToString("yy-MM-dd hh:mm:ss")}-{notice}");
                    if (notice.Contains("SHIMF"))
                    {
                        _Commprocess.BackColor = Color.White;
                        _Commprocess.ForeColor = Color.DarkBlue;
                    }
                    else if (notice.Contains("SHIMI"))
                    {
                        _Commprocess.BackColor = Color.White;
                        _Commprocess.ForeColor = Color.Red;
                    }
                    else
                    {
                        _Commprocess.BackColor = Color.White;
                        _Commprocess.ForeColor = Color.Black;
                    }
                    rcvProcess.Items[rcvProcess.Items.Count - 1].EnsureVisible();
                }
                catch (Exception ex)
                {
                    StackTrace trace = new StackTrace(ex, true);
                    StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                    int lineNumber = stackFrame.GetFileLineNumber();

                    I_Home.ErrorLog(($" ({lineNumber})[Noticeview] : {ex.ToString()}"));
                }
            }));

        }
        internal void HomeInitial(int WorkDate)
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
        internal async Task ShowShim(frmMain.PlcReference refplc, int shimno, double selshim, WorkStep index = WorkStep.FrontShim)
        {
            try
            {               
                BeginInvoke((Action)(() =>
                {
                    lbl_FSG4_Bar.Text = refplc.Barcode;
                    lbl_FSG4_Part.Text = refplc.PartName;
                    lbl_FSG4_WorkDate.Text = refplc.WorkDate.ToString();
                    lbl_FSG4_WorkNo.Text = refplc.WorkNo.ToString();
                    lbl_FSG4_SelVal.Text = selshim.ToString("0.000");
                    lbl_FSG4_Plcno.Text = shimno.ToString();
                }));                        
            }
            catch (Exception ex)
            {
                StackTrace trace = new StackTrace(ex, true);
                StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                int lineNumber = stackFrame.GetFileLineNumber();

                I_Home.ErrorLog(($" ({lineNumber})[ShowShim({index.ToString()}) Error] : {ex.ToString()}"));                
            }
        }
        internal async Task<bool> ShowShimChk(frmMain.PlcReference refplc, double chkkshim, string strindex = "G4")
        {
            bool bReturn = false;
            try
            {
                TB_FrontSetting sETTING = frmMain.G_Data._SETTING;
                if (refplc.AlcCode != frmMain.G_Data._SETTING.ALC_Code)
                {
                    using (GEN2_MEASUREDBEntities db = new GEN2_MEASUREDBEntities())
                    {
                        sETTING = await db.TB_FrontSetting.FindAsync(refplc.AlcCode);
                    }
                }
              
                BeginInvoke((Action)(() =>
                {
                    double dSelShim = double.Parse(lbl_FSG4_SelVal.Text);
                    lbl_FSG4_ChkVal.Text = chkkshim.ToString("0.000");
                    if (chkkshim >= dSelShim && chkkshim < (double)(dSelShim + sETTING.Shim_G4_Range))
                    {
                        lbl_FSG4_ChkVal.ForeColor = Color.DarkBlue;
                        lbl_FSG4_ChkVal.BackColor = SystemColors.Window;
                        bReturn = true;
                    }
                    else
                    {
                        lbl_FSG4_ChkVal.ForeColor = Color.Red;
                        lbl_FSG4_ChkVal.BackColor = Color.Yellow;
                        I_Home.ProcessLog(($"[ShimConfirmValue(G4) Error] " +
                                                $" 선택 값 :  {dSelShim}, 확인 값 : {chkkshim}"));
                        bReturn = false;
                    }
                }));
                using (GEN2_MEASUREDBEntities db = new GEN2_MEASUREDBEntities())
                {
                    TB_FrontShim tbShim = await db.TB_FrontShim.FindAsync(refplc.WorkDate, refplc.Barcode);

                    if(tbShim !=null)
                    {
                        tbShim.ShimG4_Chk_Val = chkkshim;

                        await db.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                StackTrace trace = new StackTrace(ex, true);
                StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                int lineNumber = stackFrame.GetFileLineNumber();

                I_Home.ErrorLog(($" ({lineNumber})[ShowShimChk({strindex}) Error] : {ex.ToString()}"));
            }
            return bReturn;
        }       
        internal void ClearGearFrontText()
        {
            BeginInvoke((Action)(() =>
            {
                lbl_GF_Bar.Text = string.Empty;
                lbl_GF_Part.Text = string.Empty;                
                lbl_GF_WorkDate.Text = string.Empty;
                lbl_GF_WorkNo.Text = string.Empty;
                lbl_GF_G2.Text = string.Empty;
                lbl_GF_G4.Text = string.Empty;
            }));
        }
        internal void ClearFrontCaseText()
        {
            BeginInvoke((Action)(() =>
            {
                lbl_FC_Bar.Text = string.Empty;
                lbl_FC_Part.Text = string.Empty;
                lbl_FC_WorkDate.Text = string.Empty;
                lbl_FC_WorkNo.Text = string.Empty;
                lbl_FC_G4.Text = string.Empty;
                lbl_FC_4WD.Text = string.Empty;
            }));
        }
        internal async Task UpdateData(frmMain.GData gData , WorkStep key, bool bmaster = false)//frmMain.GData gData
        {
            List<string> addrow = new List<string>();
            if (key == WorkStep.FrontGear)
            {
                TB_GearFront tmp = gData._GearFront;                
                addrow.Add(tmp.Work_No.ToString());
                addrow.Add(tmp.FGear_G2_Val.ToString());
                addrow.Add(tmp.FGear_G4_Val.ToString());
                Task.Run(()=> GearFrontUpdate(gData, bmaster));
            }
            else if (key == WorkStep.FrontCase)
            {
                TB_FrontCase tmp = gData._FrontCase;
                addrow.Add(tmp.Work_No.ToString());
                addrow.Add(bmaster ? tmp.FrontCase_Bar : gData._WORKMASTER.Master_No);
                addrow.Add(tmp.FCase_4WD_Val.ToString());
                addrow.Add(tmp.FCase_G4_Val.ToString());
                Task.Run(() => CaseFrontUpdate(gData, bmaster));
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
        private void GearFrontUpdate(frmMain.GData tmp, bool bmaster =false)
        {
            BeginInvoke((Action)(() =>
            {
                lbl_GF_Bar.Text = !bmaster ? tmp._GearFront.GearNo_Front : tmp._WORKMASTER.Master_No;
                lbl_GF_Part.Text = tmp._GearFront.Part_Name;
                lbl_GF_WorkDate.Text = !bmaster ? tmp._GearFront.Work_Date.ToString() : tmp._WORKMASTER.Work_Date.ToString();
                lbl_GF_WorkNo.Text = !bmaster ? tmp._GearFront.Work_No.ToString() : tmp.PLC[frmMain.cProcFG].iMasterCnt.ToString();
                lbl_GF_G2.Text = tmp.PLC[frmMain.cProcFG].Value1.ToString("0.000");
                lbl_GF_G4.Text = tmp.PLC[frmMain.cProcFG].Value2.ToString("0.000");
                //if(bmaster)
                //{
                //    lbl_GF_G2.Text += $" : {tmp.PLC[frmMain.cProcFG].sMaster1}";
                //    lbl_GF_G4.Text += $" : {tmp.PLC[frmMain.cProcFG].sMaster2}";
                //}
            }));
        }
        private void CaseFrontUpdate(frmMain.GData tmp, bool bmaster = false)
        {
            BeginInvoke((Action)(() =>
            {
                lbl_FC_Bar.Text = !bmaster ? tmp._FrontCase.FrontCase_Bar : tmp._WORKMASTER.Master_No;
                lbl_FC_Part.Text = tmp._FrontCase.Part_Name;
                lbl_FC_WorkDate.Text = !bmaster ? tmp._FrontCase.Work_Date.ToString() : tmp._WORKMASTER.Work_Date.ToString() ;
                lbl_FC_WorkNo.Text = !bmaster ? tmp._FrontCase.Work_No.ToString() : tmp.PLC[frmMain.cProcFC].iMasterCnt.ToString();
                lbl_FC_4WD.Text = tmp.PLC[frmMain.cProcFC].Value1.ToString("0.000");
                lbl_FC_G4.Text = tmp.PLC[frmMain.cProcFC].Value2.ToString("0.000");
                //if (bmaster)
                //{
                //    lbl_FC_4WD.Text += $" : {tmp.PLC[frmMain.cProcFC].sMaster1}";
                //    lbl_FC_G4.Text += $" : {tmp.PLC[frmMain.cProcFC].sMaster2}";
                //}
            }));
        }
        internal void ClearShimG4Text()
        {
            BeginInvoke((Action)(() =>
            {
                lbl_FSG4_Bar.Text = string.Empty;
                lbl_FSG4_Part.Text = string.Empty;
                lbl_FSG4_WorkDate.Text = string.Empty;
                lbl_FSG4_WorkNo.Text = string.Empty;
                lbl_FSG4_SelVal.Text = "0.000";
                lbl_FSG4_Plcno.Text = "0";
                lbl_FSG4_ChkVal.Text = "0.000";
            }));
        }
       
        internal async Task ShowShimVal(int shimno, double selshim, WorkStep index = WorkStep.FrontShim)
        {
            try
            {
                BeginInvoke((Action)(() =>
                {
                    lbl_FSG4_SelVal.Text = selshim.ToString("0.000");
                    lbl_FSG4_Plcno.Text = shimno.ToString();
                }));
            }
            catch (Exception ex)
            {
                StackTrace trace = new StackTrace(ex, true);
                StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                int lineNumber = stackFrame.GetFileLineNumber();

                I_Home.ErrorLog(($"({lineNumber}) : {ex.ToString()}"));
            }
        }
        internal async Task ShowShimDGV(int iworkdate, DataGridView dgvShim, int iworkno = -1)
        {
            try
            {
                BeginInvoke((Action)(() => dgvShim.Rows.Clear()));

                using (GEN2_MEASUREDBEntities db = new GEN2_MEASUREDBEntities())
                {
                    List<TB_FrontShim> lstShim = await db.TB_FrontShim.SqlQuery($"Select * from TB_FrontShim " +
                                                            $" Order by Work_No Asc").ToListAsync();
                    for (int i = 0; i < lstShim.Count; i++)
                    {
                        if (lstShim[i].ShimG4_Val != null)
                        {
                            List<string> addrow = new List<string>();
                            addrow.Add(lstShim[i].Work_No.ToString());
                            addrow.Add(lstShim[i].ShimG4_Val.ToString());
                            BeginInvoke((Action)(() =>
                            {
                                dgvShim.AddGridrow(addrow.ToArray());
                            }));
                        }                        
                    }
                    if (iworkno != -1) await Task.Run(() => FindShim(iworkno, dgvShim));
                }
            }
            catch (Exception ex)
            {
                StackTrace trace = new StackTrace(ex, true);
                StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                int lineNumber = stackFrame.GetFileLineNumber();

                I_Home.ErrorLog(($"{dgvShim.Tag}({lineNumber}) : {ex.ToString()}"));
            }
        }
        internal async Task FindShim(int iworkno, DataGridView dgvShim)
        {
            try
            {
                int iRowIndex = -1;
                for (int i = 0; i < dgvShim.RowCount; i++)
                {
                    if (iworkno == int.Parse(dgvShim[0, i].Value.ToString()))
                    {
                        iRowIndex = i;
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }
                BeginInvoke((Action)(() =>
                {
                    if (iRowIndex == -1)
                    {
                        I_Home.ProcessLog(($"[{dgvShim.Tag}] 워크번호 : {iworkno}를 찾지 못했습니다."));
                        return;
                    }
                    else if (iRowIndex > 10)
                    {
                        dgvShim.FirstDisplayedScrollingRowIndex = iRowIndex - 8;
                    }
                    else
                    {
                        dgvShim.FirstDisplayedScrollingRowIndex = iRowIndex;
                    }
                    dgvShim.Rows[iRowIndex].DefaultCellStyle.BackColor = Color.Lime;
                    dgvShim.Rows[iRowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(28, 28, 28);
                }));
            }
            catch (Exception ex)
            {
                StackTrace trace = new StackTrace(ex, true);
                StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                int lineNumber = stackFrame.GetFileLineNumber();

                I_Home.ErrorLog(($" ({lineNumber}) : {ex.ToString()}"));
            }
        }
        #endregion

        /// <summary>
        /// Test Add Row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label7_Click(object sender, EventArgs e)
        {
            //DGVCase.CurrentCell = pRoe.Cells[Part_No_INV.Name];
            //DGVCase.BeginEdit(true);
            //DGVCase.NotifyCurrentCellDirty(true);
            //DGVCase.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange);
            //DGVCase.EndEdit();
            //DGVCase.NotifyCurrentCellDirty(false);

            ////Assign the value
            //pRoe.Cells[MyColumn.Name].Value = "TheValue";
            
            //DGVHypoid.Rows.Add("1", "00.213", "000.141");
            //DGVHypoid.FirstDisplayedScrollingRowIndex = DGVHypoid.RowCount ;
            //DGVHypoid.CurrentCell.Selected = false;
        }
               
    }
}
