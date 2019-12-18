using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.IO;
using System.Data.OleDb;
using System.Data.SqlClient;
using SmLibrary.Tools;
using System.Diagnostics;

namespace FrontMeasure
{
    public partial class frmSetting : MetroFramework.Forms.MetroForm
    {
        #region ---------DataType Declear---------------

        //--------Path Setting----------
        private static string gs_ReferDir = MyApp.RootRef;
        
        private string gs_PLCRefPath = gs_ReferDir + "PLCAddress.mdb";
        private string gs_FormSetXmlPath = gs_ReferDir + "FormSetting.xml";
        private string gs_PlcSetXmlPath = gs_ReferDir + "PlcBlockSetting.xml";
            
        //---------Database-------------
        private string Connstr;
        private OleDbConnection connDB;
        private OleDbDataAdapter[] oledbAdapter;
        private OleDbCommandBuilder oledbCmdBuilder;
        private DataSet dsData = new DataSet();

        private DataSet dsDataPlc = new DataSet();
      
        private DataSet sqldsData = new DataSet();
        private UC_DGV[] Uc_dgv;
        private TabPage[] tabPage;

        #endregion

        private IinterRef frm = null;

        public frmSetting(IinterRef frm)
        {
            InitializeComponent();

            this.frm = frm;
        }
        private void frmSetting_Load(object sender, EventArgs e)
        {
            //this.DisableX();
            //this.ControlBox = false;

            Connstr = MyApp.RootMDB(gs_PLCRefPath);
            TabControl1.SelectedIndex = 0;

            ReadSetXml();
            BindingPLCRefFile();
        }
        private void frmSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                int i = 0;
                dsData.AcceptChanges();
                foreach (OleDbDataAdapter item in oledbAdapter)
                {
                    item.Update(dsData.Tables[i]);
                    item.Dispose();
                    i++;
                }                
                connDB.Close();

                frm.Exit_Main();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                StackTrace trace = new StackTrace(ex, true);
                StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                int lineNumber = stackFrame.GetFileLineNumber();

                frm.ErrorLog(($"({lineNumber}) : {ex.ToString()}"));

            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet changes = new DataSet();

                changes = dsDataPlc.GetChanges();
                if (changes != null)
                {
                    //dsDataPlc.Tables("PLC").AcceptChanges()
                    //dsDataPlc.Tables("Blocks").AcceptChanges()
                    //'dsDataPlc.AcceptChanges() 

                    dsDataPlc.WriteXml(gs_PlcSetXmlPath, XmlWriteMode.IgnoreSchema);
                    MessageBox.Show("PLC 설정 값이 변경 되었습니다.", "Saved PLC Address", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                StackTrace trace = new StackTrace(ex, true);
                StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                int lineNumber = stackFrame.GetFileLineNumber();

                frm.ErrorLog(($"({lineNumber}) : {ex.ToString()}"));
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
            Uc_dgv[idex].DGVPlc.ReadOnly = false;
            Uc_dgv[idex].DGVPlc.AllowUserToAddRows = true;
            Uc_dgv[idex].DGVPlc.AllowUserToDeleteRows = true;
            Uc_dgv[idex].DGVPlc.EditingControlShowing += DataGridView1_EditingControlShowing;
            #endregion
        }
        public void AddTabpage(string tbName, int idex)
        {
            tabControl2.Controls.Add(tabPage[idex]);

            tabPage[idex].Location = new Point(4, 4);
            tabPage[idex].Name = $"tabPage_{idex}";
            tabPage[idex].Padding = new Padding(3);
            tabPage[idex].Size = new Size(1252, 760);
            tabPage[idex].TabIndex = idex;
            tabPage[idex].Text = tbName;
            tabPage[idex].UseVisualStyleBackColor = true;
        }
        private void BindingPLCRefFile()
        {
            string sql;

            if (File.Exists(gs_PLCRefPath))
            {
                connDB = new OleDbConnection(Connstr);
                connDB.Open();
                int iArrcnt = 0;
                foreach (string tbName in Share.GetMDBTable(connDB))
                {
                    sql = $"Select *from {tbName} " + "Order by PlcName ASC,BlockNum ASC,IndexNo ASC";
                    try
                    {
                        Array.Resize(ref tabPage, iArrcnt + 1);
                        Array.Resize(ref Uc_dgv, iArrcnt + 1);
                        Array.Resize(ref oledbAdapter, iArrcnt + 1);

                        tabPage[iArrcnt] = new TabPage();
                        AddTabpage(tbName, iArrcnt);

                        Uc_dgv[iArrcnt] = new UC_DGV();
                        AddDGV(iArrcnt);

                        oledbAdapter[iArrcnt] = new OleDbDataAdapter(sql, connDB);
                        oledbAdapter[iArrcnt].Fill(dsData,tbName);

                        //dsData.(strFolerPath & "\PLCAddress.mdb")
                        DataTableCollection tables = dsData.Tables;
                        DataView DetailsView = new DataView(tables[tbName]);

                        //DataGridView1.AutoGenerateColumns = False
                        Uc_dgv[iArrcnt].DGVPlc.DataSource = DetailsView;
                        iArrcnt++;
                                                
                    }
                    catch (Exception ex)
                    {
                        StackTrace trace = new StackTrace(ex, true);
                        StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                        int lineNumber = stackFrame.GetFileLineNumber();

                        frm.ErrorLog(($"({lineNumber}) : {ex.ToString()}"));
                    }
                }

            }
        }
        private void ReadSetXml()
        {
            try
            {
                DataTableCollection DATables;
                DataView[] DVView = new DataView[2];

                dsDataPlc.ReadXml(gs_PlcSetXmlPath);
                dsDataPlc.Tables[0].TableName = "PLC";
                dsDataPlc.Tables[1].TableName = "Blocks";

                DATables = dsDataPlc.Tables;
                DVView[0] = new DataView(DATables["PLC"]);
                DVView[1] = new DataView(DATables["Blocks"]);

                DGV_PlcPart.DataSource = DVView[0];
                DGV_BlockPart.DataSource = DVView[1];
            }
            catch(Exception ex)
            {
                StackTrace trace = new StackTrace(ex, true);
                StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                int lineNumber = stackFrame.GetFileLineNumber();

                frm.ErrorLog(($"({lineNumber}) : {ex.ToString()}"));
            }            
        }     
        private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            string titleText = dgv.Columns[dgv.CurrentCell.ColumnIndex].HeaderText;

            if (titleText.Equals("DataType"))
            {
                TextBox autoText = e.Control as TextBox;
                if (autoText != null)
                {
                    autoText.AutoCompleteMode = AutoCompleteMode.Suggest;
                    autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
                    addItems(titleText, DataCollection);
                    autoText.AutoCompleteCustomSource = DataCollection;
                }
            }
            else if (titleText.Equals("PlcName"))
            {
                TextBox autoText = e.Control as TextBox;
                if (autoText != null)
                {
                    autoText.AutoCompleteMode = AutoCompleteMode.Suggest;
                    autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
                    addItems(titleText, DataCollection);
                    autoText.AutoCompleteCustomSource = DataCollection;
                }
            }
        }
        
        public void addItems(string Title, AutoCompleteStringCollection col)
        {
            try
            {
                if (Title.Equals("DataType"))
                {
                    col.Clear();
                    col.Add("ASCII");
                    col.Add("DEC");
                }
                else if (Title.Equals("PlcName"))
                {
                    string strRcv;
                    col.Clear();

                    for (int i = 0; i <= DGV_PlcPart.RowCount - 1; i++)
                    {
                        strRcv = DGV_PlcPart["NAME", i].Value.ToString();
                        col.Add(strRcv);
                    }
                }
            }
            catch (Exception)
            {

            }
            
        }
        private void btnViewSet_Click(object sender, EventArgs e)
        {
            Process.Start(gs_PlcSetXmlPath);
        }
        private void SaveAddress_Click(object sender, EventArgs e)
        {
            try
            {
                int iTmp;
                DataSet changes = new DataSet();
                int i = 0;
                foreach (var item in oledbAdapter)
                {
                    oledbCmdBuilder = new OleDbCommandBuilder(item);
                    changes = dsData.GetChanges();
                    if (changes != null)
                    {
                        iTmp = item.Update(dsData.Tables[i]);
                        i++;
                    }
                }
                //dsData.AcceptChanges()
                MessageBox.Show("PLC Address 설정 값이 변경 되었습니다.", "Saved PLC Address", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                StackTrace trace = new StackTrace(ex, true);
                StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                int lineNumber = stackFrame.GetFileLineNumber();

                frm.ErrorLog(($"({lineNumber}) : {ex.ToString()}"));
            }
        }
    }
        
}
