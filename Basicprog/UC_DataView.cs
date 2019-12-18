using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using SmLibrary.Tools;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;

namespace FrontMeasure
{
    public partial class UC_DataView : UserControl
    {
        delegate void DgvDSDelegate(DataSet ds, DataGridView lbl);
        private int _iStartDate;
        private int _iEndDate;
        private IinterRef I_Sub = null;
        private decimal[] _ID = new decimal[2];
        public UC_DataView(IinterRef frm)
        {
            InitializeComponent();
            I_Sub = frm;
        }

        private void UC_DataView_Load(object sender, EventArgs e)
        {
            try
            {
                //다른 쓰레드에서 윈폼 컨트롤 사용가능 (비동기 작업에서 사용)
                Control.CheckForIllegalCrossThreadCalls = false;
                DGVGrd.DoubleBuffered(true);
                CB_TableName.Items.Clear();
                CB_TableName.Items.Add("-Measure-");
                CB_TableName.Items.Add("-MasterData-");
                CB_TableName.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                StackTrace trace = new StackTrace(ex, true);
                StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                int lineNumber = stackFrame.GetFileLineNumber();

                I_Sub.ErrorLog(($"({lineNumber}) : {ex.ToString()}"));
            }

        }
        private void SetDGVDatasource(DataSet ds, DataGridView dgv)
        {
            if (dgv.InvokeRequired)
            {
                DgvDSDelegate d = new DgvDSDelegate(SetDGVDatasource);
                this.BeginInvoke(new System.Action(() => dgv.DataSource = ds.Tables[0]));
                //this.Invoke(d, new object[] { i, text });
            }
            else
            {
                dgv.DataSource = ds.Tables[0];
            }
        }
        public void SearchInitial()
        {
            try
            {
                //상위 데이터 100개 조회 = > 이후 데이터 조회 성능 향상을 위해
                string sql = "Select Top 100 * from TB_MEASURE Order by Seq desc;";

                using (DataSet dsData = new DataSet())
                {
                    if (frmMain.connSql.State != ConnectionState.Open)
                        frmMain.OpenLocalDB();

                    SqlDataAdapter oledbAdapter = new SqlDataAdapter(sql, frmMain.connSql);
                    oledbAdapter.Fill(dsData);

                    //-----------------------------------------------------
                    {
                        //.DoubleBuffered(True)
                        Stopwatch Tchk = new Stopwatch();
                        Tchk.Start();

                        DGVGrd.DataSource = dsData.Tables[0];
                        //SetDGVDatasource(dsData, DGVGrd);
                        DGVGrd.Columns["SEQ"].Visible = false;

                        Tchk.Stop();
                        Debug.Print(Tchk.Elapsed.ToString());
                    }

                    oledbAdapter.Dispose();
                    oledbAdapter = null;
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

        public void GetTableName()
        {
            System.Data.DataTable DBTables = new System.Data.DataTable();
            string sTmpTable;
            string[] sArrTB = new string[1];
            int i;
            int j;

            try
            {
                DBTables = frmMain.connSql.GetSchema("Tables");

                for (i = 0; i < DBTables.Rows.Count; i++)
                {
                    if (DBTables.Rows[i][2].ToString().Substring(0, 2) == "TB")
                    {
                        sTmpTable = DBTables.Rows[i][2].ToString();
                        Array.Resize(ref sArrTB, i + 1);
                        sArrTB[i] = sTmpTable;
                    }
                }
                //Array.Sort(sArrTB)

                if (sArrTB.Length >= 1)
                {
                    for (i = 0; i <= sArrTB.Length - 1; i++)
                    {
                        for (j = 0; j <= sArrTB.Length - 1; j++)
                        {
                            //Dim strt As String = sArrTB(i).Split("_")(1).Substring(2)

                            if (Convert.ToInt32(sArrTB[i].Split('_')[1].Substring(2)) < Convert.ToInt32(sArrTB[j].Split('_')[1].Substring(2)))
                            {
                                sTmpTable = sArrTB[j];
                                sArrTB[j] = sArrTB[i];
                                sArrTB[i] = sTmpTable;
                            }
                        }
                    }
                }
                //CB_TableName.Items.Clear();               
                //CB_TableName.Items.Add("-투입구간-");
                //CB_TableName.Items.Add("-이종검사기-");
                //CB_TableName.Items.Add("-하우징 베어링 압입기-");
                //CB_TableName.Items.Add("-하우징 스냅링 검사기-");
                //CB_TableName.Items.Add("-더스트 커버1 압입기-");
                //CB_TableName.Items.Add("-더스트 커버2 압입기-");
                //CB_TableName.Items.Add("-아세이 압입기-");
                //CB_TableName.Items.Add("-오링 자동 조립기-");
                //CB_TableName.Items.Add("-써클립 자동 조립-");
                //CB_TableName.Items.Add("-수작업 구간-");
                //CB_TableName.Items.Add("-완성비젼-");
                //CB_TableName.Items.Add("-배출구간-");
                //CB_TableName.SelectedIndex = 0;
                //gs_TableName = sArrTB;
            }
            catch (Exception ex)
            {
                StackTrace trace = new StackTrace(ex, true);
                StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                int lineNumber = stackFrame.GetFileLineNumber();

                I_Sub.ErrorLog(($"({lineNumber}) : {ex.ToString()}"));

            }

        }

        private async void btnDataView_Click(object sender, EventArgs e)
        {
            frmWaiting waiting = new frmWaiting();

            if (!Share.CheckOpened(waiting.Name))
            {
                waiting.Show();
                waiting.Focus();
                waiting.TopMost = true;
                waiting.Text = "Excuting DataSearch...";
            }
            _iStartDate = int.Parse(sDate.Value.ToShortDateString().Replace("-", ""));
            _iEndDate = int.Parse(eDate.Value.ToShortDateString().Replace("-", ""));

            btnDataView.Enabled = false;
            btnDataView.Text = "EXcuting";

            DGVGrd.Visible = false;
            Task searchTask = Task.Run(() => SearchAsync());

            await searchTask;

            DGVGrd.Visible = true;
            DGVGrd.Refresh();
            btnDataView.Enabled = true;
            btnDataView.Text = "Search";

            waiting.Close();
            waiting.Dispose();
            waiting = null;

        }
        private async Task SearchAsync()
        {
            await Task.Run(async () =>
            {
                try
                {
                    string sql;
                    if (CB_TableName.SelectedIndex == 0)
                        sql = "Select * from TB_MEASURE " +
                                " Where Work_Date >= " + _iStartDate + " and Work_Date <= " + _iEndDate +
                                " Order by Seq Asc;";
                    else
                        sql = "Select * from TB_WORKMASTER " +
                                " Where Work_Date >= " + _iStartDate + " and Work_Date <= " + _iEndDate +
                                " Order by WORK_DATE ASC,INDEX_NAME ASC,SEQ ASC;";

                    using (DataSet dsData = new DataSet())
                    {
                        if (frmMain.connSql.State != ConnectionState.Open)
                            frmMain.OpenLocalDB();

                        SqlDataAdapter oledbAdapter = new SqlDataAdapter(sql, frmMain.connSql);
                        oledbAdapter.Fill(dsData);

                        //-----------------------------------------------------
                        {
                            //.DoubleBuffered(True)
                            Stopwatch Tchk = new Stopwatch();
                            Tchk.Start();

                            DGVGrd.DataSource = dsData.Tables[0];
                            //SetDGVDatasource(dsData, DGVGrd);
                            DGVGrd.Columns["SEQ"].Visible = false;

                            Tchk.Stop();
                            Debug.Print(Tchk.Elapsed.ToString());
                        }

                        oledbAdapter.Dispose();
                        oledbAdapter = null;
                    }
                }
                catch (Exception ex)
                {
                    StackTrace trace = new StackTrace(ex, true);
                    StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                    int lineNumber = stackFrame.GetFileLineNumber();

                    I_Sub.ErrorLog(($"({lineNumber}) : {ex.ToString()}"));
                }
                finally
                {
                    await Task.Delay(1);
                }

            });
        }

        private async void btnExportExcel_Click(object sender, EventArgs e)
        {
            btnExportExcel.Enabled = false;
            btnExportExcel.Text = "EXcuting";

            frmWaiting waiting = new frmWaiting();

            if (!Share.CheckOpened(waiting.Name))
            {
                waiting.Show();
                waiting.Focus();
                waiting.TopMost = true;
                waiting.Text = "Exporting Excelfile...";
            }

            if (DGVGrd.RowCount > 1)
            {
                SaveFileDialog1.Filter = "Excel Files|*.xlsx";
                SaveFileDialog1.InitialDirectory = MyApp.Path;
                if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string sTmpName;
                    sTmpName = SaveFileDialog1.FileName;

                    DGVGrd.SelectAll();  // DataGridView control
                    DataObject dataObj = DGVGrd.GetClipboardContent();
                    Clipboard.SetDataObject(dataObj, false);
                    DGVGrd.ClearSelection();

                    Task excelTask = Task.Run(() => ExportExcelAsync(sTmpName));
                    
                    await excelTask;
                }
            }
            else
            {
                MessageBox.Show("데이터가 존재 하지 않습니다.", "엑셀저장 에러", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            btnExportExcel.Enabled = true;
            btnExportExcel.Text = "Excel";

            waiting.Close();
            waiting.Dispose();
            waiting = null;
        }
        private async Task ExportExcelAsync(string savename)
        {
            await Task.Run(async () =>
            {

                try
                {
                    Stopwatch Tchk = new Stopwatch();
                    Tchk.Start();

                    System.Reflection.Missing empty = System.Reflection.Missing.Value;

                    // all excel classes and interfaces
                    // are from Microsoft.Office.Interop.Excel namespace
                    ApplicationClass excel = new ApplicationClass();
                    Workbooks wBooks = excel.Workbooks;
                    _Workbook wBook = wBooks.Add(empty);
                    _Worksheet wSheet = (_Worksheet)wBook.Worksheets.get_Item(1);

                    Range range = wSheet.get_Range("A1", empty);
                    wSheet.Paste(range, false);
                    wSheet.Name = CB_TableName.Text;
                    
                    wSheet.Columns.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    wSheet.Columns.VerticalAlignment = XlVAlign.xlVAlignCenter;
                    wSheet.Columns.AutoFit();
                    
                    // Save the workbook and quit Excel.
                    string excelSavePath = savename;
                    wBook.SaveAs(excelSavePath, empty, empty,
                                    empty, empty, empty, XlSaveAsAccessMode.xlNoChange, empty, empty,
                                    empty, empty, empty);
                    wBook.Close(false, empty, empty);
                    excel.Workbooks.Open(savename);
                    excel.Visible = true;
                    excel.DisplayAlerts = true;

                    //excel.Quit();

                    // important so you don't have
                    // excel lurking in memory
                    //range = null;
                    //wSheet = null;
                    //wBook = null;
                    //wBooks = null;
                    //excel = null;
                    releaseObject(range);
                    releaseObject(wSheet);
                    releaseObject(wBook);
                    releaseObject(wBooks);
                    releaseObject(excel);

                    Tchk.Stop();
                    Debug.Print(Tchk.Elapsed.ToString());
                }
                catch (Exception ex)
                {
                    StackTrace trace = new StackTrace(ex, true);
                    StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                    int lineNumber = stackFrame.GetFileLineNumber();

                    I_Sub.ErrorLog(($"({lineNumber}) : {ex.ToString()}"));
                }
                finally
                {
                    await Task.Delay(1);
                }
                                
            });
        }

      

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                StackTrace trace = new StackTrace(ex, true);
                StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                int lineNumber = stackFrame.GetFileLineNumber();

                I_Sub.ErrorLog(($"({lineNumber}) : {ex.ToString()}"));
            }
            finally
            {
                GC.Collect();
            }
        }

        private void DGVGrd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _ID[0] = decimal.Parse(DGVGrd.SelectedRows[0].Cells[1].Value.ToString());
                _ID[1] = decimal.Parse(DGVGrd.SelectedRows[0].Cells[2].Value.ToString());
                //using (L_MEASUREDBEntities db = new L_MEASUREDBEntities())
                //{
                //    TB_MEASURE _MEASURE = db.TB_MEASURE.Find(_ID[0], _ID[1]);
                //    if (_MEASURE != null)
                //    {
                //        lblWorkDate.Text = _MEASURE.Work_Date.ToString();
                //        lblWorkNo.Text = _MEASURE.Work_No.ToString();
                //        lblPart.Text = _MEASURE.Part_Name;
                //        txtFBar.Text = _MEASURE.LDis_Bar;
                //        txtFVal.Text = _MEASURE.LDis_Val;
                //        txtFMin.Text = _MEASURE.LDis_Min;
                //        txtFMax.Text = _MEASURE.LDis_Max;

                //        txtHBar.Text = _MEASURE.Pinion_Bar;
                //        txtHGear.Text = _MEASURE.Pinion_GearNo;
                //        txtHMd.Text = _MEASURE.StandardDis_Val;
                //        txtHVal.Text = _MEASURE.Pinion_Val;
                //        txtHMin.Text = _MEASURE.Pinion_Min;
                //        txtHMax.Text = _MEASURE.Pinion_MAx;

                //        txtSVal.Text = _MEASURE.Shim_Val;
                //        txtSOffset.Text = _MEASURE.Shim_Offset;
                //        txtSChkVal.Text = _MEASURE.Shim_Chk_Val;

                //        txtSGVal.Text = _MEASURE.ShimGen2_Val;
                //        txtSGChkVal.Text = _MEASURE.ShimGen2_Chk_Val;
                //    }
                //}
            }
            catch (Exception ex)
            {
                StackTrace trace = new StackTrace(ex, true);
                StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                int lineNumber = stackFrame.GetFileLineNumber();

                I_Sub.ErrorLog($"({lineNumber}) : {ex.ToString()}");
            }
        }

        private async void btnFix_Click(object sender, EventArgs e)
        {
            try
            {
                //using (L_MEASUREDBEntities db = new L_MEASUREDBEntities())
                //{
                //    TB_MEASURE _MEASURE = db.TB_MEASURE.Find(_ID[0], _ID[1]);
                //    if (_MEASURE != null)
                //    {
                //        _MEASURE.LDis_Bar = txtFBar.Text;
                //        _MEASURE.LDis_Val = txtFVal.Text;
                //        _MEASURE.LDis_Min = txtFMin.Text;
                //        _MEASURE.LDis_Max = txtFMax.Text;

                //        _MEASURE.Pinion_Bar = txtHBar.Text;
                //        _MEASURE.Pinion_GearNo = txtHGear.Text;
                //        _MEASURE.StandardDis_Val = txtHMd.Text;
                //        _MEASURE.Pinion_Val = txtHVal.Text;
                //        _MEASURE.Pinion_Min = txtHMin.Text;
                //        _MEASURE.Pinion_MAx = txtHMax.Text;

                //        _MEASURE.Shim_Val = txtSVal.Text;
                //        _MEASURE.Shim_Offset = txtSOffset.Text;
                //        _MEASURE.Shim_Chk_Val = txtSChkVal.Text;

                //        _MEASURE.ShimGen2_Val = txtSGVal.Text;
                //        _MEASURE.ShimGen2_Chk_Val = txtSGChkVal.Text;

                //        int ir = await db.SaveChangesAsync();
                //        EventArgs tmp = new EventArgs();
                //        btnDataView_Click(btnDataView, tmp);

                //        lblWorkDate.Text = string.Empty;
                //        lblWorkNo.Text = string.Empty;
                //        lblPart.Text = string.Empty;
                //        txtFBar.Text = string.Empty;
                //        txtFVal.Text = string.Empty;
                //        txtFMin.Text = string.Empty;
                //        txtFMax.Text = string.Empty;

                //        txtHBar.Text = string.Empty;
                //        txtHGear.Text = string.Empty;
                //        txtHMd.Text = string.Empty;
                //        txtHVal.Text = string.Empty;
                //        txtHMin.Text = string.Empty;
                //        txtHMax.Text = string.Empty;

                //        txtSVal.Text = string.Empty;
                //        txtSOffset.Text = string.Empty;
                //        txtSChkVal.Text = string.Empty;

                //        txtSGVal.Text = string.Empty;
                //        txtSGChkVal.Text = string.Empty;
                //        _MEASURE = null;
                //        _ID[0] = -1;
                //        _ID[1] = -1;
                //    }
                //}
            }
            catch (Exception ex)
            {
                StackTrace trace = new StackTrace(ex, true);
                StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                int lineNumber = stackFrame.GetFileLineNumber();

                I_Sub.ErrorLog($"({lineNumber}) : {ex.ToString()}");
            }
        }

        private async void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                //using (L_MEASUREDBEntities db = new L_MEASUREDBEntities())
                //{
                //    TB_MEASURE _MEASURE = db.TB_MEASURE.Find(_ID[0], _ID[1]);
                //    if (_MEASURE != null)
                //    {
                //        db.TB_MEASURE.Remove(_MEASURE);

                //        int ir = await db.SaveChangesAsync();
                //        EventArgs tmp = new EventArgs();
                //        btnDataView_Click(btnDataView, tmp);

                //        lblWorkDate.Text = string.Empty;
                //        lblWorkNo.Text = string.Empty;
                //        lblPart.Text = string.Empty;
                //        txtFBar.Text = string.Empty;
                //        txtFVal.Text = string.Empty;
                //        txtFMin.Text = string.Empty;
                //        txtFMax.Text = string.Empty;

                //        txtHBar.Text = string.Empty;
                //        txtHGear.Text = string.Empty;
                //        txtHMd.Text = string.Empty;
                //        txtHVal.Text = string.Empty;
                //        txtHMin.Text = string.Empty;
                //        txtHMax.Text = string.Empty;

                //        txtSVal.Text = string.Empty;
                //        txtSOffset.Text = string.Empty;
                //        txtSChkVal.Text = string.Empty;

                //        txtSGVal.Text = string.Empty;
                //        txtSGChkVal.Text = string.Empty;
                //        _ID[0] = -1;
                //        _ID[1] = -1;
                //    }
                //}
            }
            catch (Exception ex)
            {
                StackTrace trace = new StackTrace(ex, true);
                StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                int lineNumber = stackFrame.GetFileLineNumber();

                I_Sub.ErrorLog($"({lineNumber}) : {ex.ToString()}");
            }
        }
    
    }
}
