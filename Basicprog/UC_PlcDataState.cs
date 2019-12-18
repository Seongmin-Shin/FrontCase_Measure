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
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Data.OleDb;
using SmLibrary.Net;

namespace FrontMeasure
{
    public partial class UC_PlcDataState : UserControl
    {
        delegate void StringArgReturningVoidDelegate(int iTabindex, int i, string text);
        delegate void StringlblDelegate(string text,Label lbl);
        delegate void ImagelblDelegate(Image img, Label lbl);
        private IinterRef I_Sub = null;
        public UC_DGV[] Uc_dgv;
        public TabPage[] tabPage;
       
        private readonly Image IMG_OFF = Properties.Resources.Off;
        private readonly Image IMG_ON = Properties.Resources.On;

        private string _PLCRefPath = MyApp.RootRef + "PLCAddress.mdb";
  
        public UC_PlcDataState(IinterRef frm)
        {
            InitializeComponent();
            I_Sub = frm;
        }
        private void UC_PlcDataState_Load(object sender, EventArgs e)
        {
            //다른 쓰레드에서 윈폼 컨트롤 사용가능 (비동기 작업에서 사용)
            //Control.CheckForIllegalCrossThreadCalls = false;
           
            if (!Directory.Exists(MyApp.RootRef))
            {
                Directory.CreateDirectory(MyApp.RootRef);
            }
            if (File.Exists(_PLCRefPath))
            {
                try
                {
                    int iArrcnt = 0;
                    string Connstr = MyApp.RootMDB(_PLCRefPath);
                    using (OleDbConnection connDB = new OleDbConnection(Connstr))
                    {
                        connDB.Open();
                        foreach (string tbName in Share.GetMDBTable(connDB))
                        {
                            string sql = $"Select *from {tbName} " + "Order by PlcName ASC,BlockNum ASC,IndexNo ASC";

                            Array.Resize(ref tabPage, iArrcnt + 1);
                            Array.Resize(ref Uc_dgv, iArrcnt + 1);
                            
                            tabPage[iArrcnt] = new TabPage();
                            AddTabpage(tbName,iArrcnt);                            
                            
                            Uc_dgv[iArrcnt] = new UC_DGV();
                            AddDGV(iArrcnt);

                            using (DataSet dsData = new DataSet())
                            {                                
                                OleDbDataAdapter oledbAdapter = new OleDbDataAdapter(sql, connDB);
                                oledbAdapter.Fill(dsData);

                                //.DoubleBuffered(True)
                                Stopwatch Tchk = new Stopwatch();
                                Tchk.Start();

                                Uc_dgv[iArrcnt].DGVPlc.DataSource = dsData.Tables[0];
                                DataGridViewTextBoxColumn addrCol = new DataGridViewTextBoxColumn();

                                addrCol.Name = "PLCVal";
                                addrCol.HeaderText = "PLCVal";

                                Uc_dgv[iArrcnt].DGVPlc.Columns.Add(addrCol);

                                Tchk.Stop();
                                Debug.Print(Tchk.Elapsed.ToString());
                              
                                //DetailsView.Dispose();
                                oledbAdapter.Dispose();
                                oledbAdapter = null;                              

                                for (int i = 0; i < Uc_dgv[iArrcnt].DGVPlc.Columns.Count; i++)
                                {
                                    Uc_dgv[iArrcnt].DGVPlc.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                                }
                            }
                            Uc_dgv[iArrcnt].DGVPlc.DoubleBuffered();
                            iArrcnt++;
                        }
                        connDB.Close();
                        connDB.Dispose();
                    }   
                }
                catch (Exception ex)
                {                   
                    StackTrace trace = new StackTrace(ex, true);
                    StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                    int lineNumber = stackFrame.GetFileLineNumber();

                    I_Sub.ErrorLog(($"({lineNumber}) : {ex.ToString()}"));                    
                }                
            }
        }
        private void AddDGV(int idex)
        {
            #region Add DataGridView
            tabPage[idex].Controls.Add(Uc_dgv[idex]);
            Uc_dgv[idex].Dock = DockStyle.Fill;
            // 
            Uc_dgv[idex].BackColor = Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            Uc_dgv[idex].Font = new Font("현대하모니 M", 9F);
            Uc_dgv[idex].Location = new Point(563, 115);
            Uc_dgv[idex].Name = $"Uc_dgv_{idex}";
            Uc_dgv[idex].Padding = new Padding(5);
            Uc_dgv[idex].Size = new Size(326, 212);
            Uc_dgv[idex].TabIndex = 0;
                        
            #endregion
        }
        public void AddTabpage(string tbName,int idex)
        {
            tabControlPLC.Controls.Add(tabPage[idex]);

            tabPage[idex].Location = new Point(4, 4);
            tabPage[idex].Name = $"tabPage_{idex}";
            tabPage[idex].Padding = new Padding(3);
            tabPage[idex].Size = new Size(1252, 760);
            tabPage[idex].TabIndex = idex;
            tabPage[idex].Text = tbName;
            tabPage[idex].UseVisualStyleBackColor = true;
            
        }
        public async Task PLCProcessAsync(string plcname, string msg , int[] idexNum , CancellationToken ct)
        {                     
            try
            {
                await Task.Run(() =>
                {
                    int iTabindex = tabControlPLC.SelectedIndex;
                    if (plcname == GetPlcName(iTabindex))
                    {                        
                        SetlblText($"{msg}", lblPlcMsg); 
                    }
                    // ***Set up the CancellationTokenSource to cancel after 2.5 seconds. (You
                    // can adjust the time.)
                    //_TsCancel.CancelAfter(2500);

                    //Parallel.for
                    ParallelOptions po = new ParallelOptions();
                    po.CancellationToken = ct;
                    po.MaxDegreeOfParallelism = Environment.ProcessorCount;

                    string[] s;
                    Parallel.For(0, Uc_dgv[iTabindex].DGVPlc.RowCount, i =>
                    {
                        if (ct.IsCancellationRequested)
                        {
                            // another thread decided to cancel                                
                            po.CancellationToken.ThrowIfCancellationRequested();                                
                        }
                        if (plcname == GetPlcName(iTabindex))
                        {
                            try
                            {
                                if (!string.IsNullOrEmpty(frmMain.gs_RcvPLCData[i + idexNum[1]]))
                                {
                                    if (iTabindex != tabControlPLC.SelectedIndex)
                                        return;

                                    s = frmMain.gs_RcvPLCData[i + idexNum[1]].Split(':');
                                    SetDGVText(iTabindex, i, s[1].Trim());
                                }

                            }
                            catch (Exception)
                            {

                            }
                                    
                        }
                    }); // Parallel.For

                }, ct);
            }
            catch (Exception ex)
            {
                StackTrace trace = new StackTrace(ex, true);
                StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                int lineNumber = stackFrame.GetFileLineNumber();

                I_Sub.ErrorLog(($"({lineNumber}) : {ex.ToString()}"));
            }           
        }
      
        private string GetPlcName(int iTabindex)
        {
            return Uc_dgv[iTabindex].DGVPlc["PlcName", 0].Value.ToString();
        }

        private void SetDGVText(int iTabindex, int i, string text)
        {
            try
            {
                if (iTabindex != tabControlPLC.SelectedIndex)
                    return;
                if (Uc_dgv[iTabindex].DGVPlc.InvokeRequired)
                {
                    StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(SetDGVText);
                    BeginInvoke(new Action(() => Uc_dgv[iTabindex].DGVPlc["PLCVal", i].Value = text));
                    //this.Invoke(d, new object[] { i, text });
                }
                else
                {
                    Uc_dgv[iTabindex].DGVPlc["PLCVal", i].Value = text;
                }
            }
            catch (Exception)
            {
                throw;
            }            
        }
        private void SetlblImg(Image img, Label lbl)
        {
            if (lbl.InvokeRequired)
            {
                ImagelblDelegate d = new ImagelblDelegate(SetlblImg);
                this.BeginInvoke(new Action(() => lbl.Image = img));
                this.BeginInvoke(new Action(() => lbl.Tag = img == IMG_OFF ? 0:1));
            }
            else
            {
                lbl.Image = img;
            }
        }
        private void SetlblText(string text, Label lbl)
        {
            if (lbl.InvokeRequired)
            {
                StringlblDelegate d = new StringlblDelegate(SetlblText);
                this.BeginInvoke(new Action(() => lbl.Text = text));
                //this.Invoke(d, new object[] { i, text });
            }
            else
            {
                lbl.Text = text;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblPlcMsg.Text = "";
        }      
        
    }
}
