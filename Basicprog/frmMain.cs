using SmLibrary.Net;
using SmLibrary.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace FrontMeasure
{
    public interface IinterRef
    {
        void Exit_Main();
        void PLCDispose();
        void PLCSetting();
        void WritePlcData(string plcKey, string PLCAddress, string writeData, PlcEnetTask.DataType plcSendType, bool firstIn = false);
        void ProcessLog(string msg, bool homewrite = false);
        void ErrorLog(string Msg);
    }

    public partial class frmMain : Form, IinterRef
    {
        private UC_Home uC_Home1;
        private UC_PlcDataState uC_PlcDataState1;
        private UC_LogView uC_LogView1;
        private UC_DataView uC_DataView1;
        private UC_PartSetting uC_PartSetting;

        private static string _ReferDir = MyApp.RootRef;
        private static string _INIPath = _ReferDir + "Set.INI";
        private static string _PLCRefPath = _ReferDir + "PLCAddress.mdb";
        private static string _FormSetXmlPath = _ReferDir + "FormSetting.xml";
        private static string _PlcSetXmlPath = _ReferDir + "PlcBlockSetting.xml";

        private bool _bSavelog;
        public bool gb_ExitFlag;

        //---------Database-------------
        public static string Connstrsql = MyApp.RootSqlLocal("L_MEASUREDB");
        public static SqlConnection connSql = new SqlConnection(Connstrsql);
        public const string TB_MeasureName = "TB_MEASURE";
        public const string TB_SettingName = "TB_SETTING";
        /// <summary>
        /// plc 관련 필드
        /// </summary>
        #region [--- Struct PlcRef ---]       
        public class PlcShimRef
        {
            public PlcShimRef()
            {
                iflag = -1;
            }
            public int icmd;
            public int iflag;
            public string sChkVal;
            public string sRFID;
            public string Barcode
            {
                get
                {
                    if (!string.IsNullOrEmpty(sRFID) && sRFID.Length > 50)
                        return sRFID.Substring(0, 20);
                    else
                    {
                        return "";
                    }
                }
            }
            public string AlcCode
            {
                get
                {
                    if (!string.IsNullOrEmpty(Barcode) && sRFID.Length >= 10)
                        return Barcode.Substring(0, 4);
                    else
                    {
                        return "";
                    }
                }
            }
            public string sPartflag;
            public string PartName
            {
                get
                {
                    if (!string.IsNullOrEmpty(sRFID) && sRFID.Length > 50)
                        return sRFID.Substring(20, 20);
                    else
                    {
                        return "";
                    }
                }
            }
            public int preWorkDate;
            public int WorkDate
            {
                get
                {
                    if (!string.IsNullOrEmpty(sRFID) && sRFID.Length > 50)
                        return int.Parse(sRFID.Substring(40, 8));
                    else
                    {
                        return -1;
                    }
                }
            }
            public int WorkNo
            {
                get
                {
                    if (!string.IsNullOrEmpty(sRFID) && sRFID.Length > 50)
                        return int.Parse(sRFID.Substring(48, 4));
                    else
                    {
                        return -1;
                    }
                }
            }
        }
        public struct ShimSetting
        {
            public int ShimPosition;
            public float Gain;
            public float Min;
            public float Max;
            public float Range;
            public string PartName;
            public string AlcCode;
            public string StandardVal;
        }
        public class PlcReference
        {
            public PlcReference()
            {
                iflag = -1;
            }
            public int icmd;
            public int iflag;
            public double Value1;
            public double Min1;
            public double Max1;
            public double Value2;
            public double Min2;
            public double Max2;
            public double StandardDis;
            public string sRFID;
            public string sGearRFID;
            public string sIMRFID;
            public string Barcode
            {
                get
                {
                    if (!string.IsNullOrEmpty(sRFID) && sRFID.Length > 50)
                        return sRFID.Substring(0, 20).Trim();
                    else
                    {
                        return "";
                    }
                }
            }
            public string AlcCode
            {
                get
                {
                    if (!string.IsNullOrEmpty(Barcode) && sRFID.Length >= 10)
                        return Barcode.Substring(0, 4);
                    else
                    {
                        return "";
                    }
                }
            }
            public string GearNo
            {
                get
                {
                    if (!string.IsNullOrEmpty(sGearRFID) && sGearRFID.Length > 60)
                        return sRFID.Substring(52, 10).Trim();
                    else
                    {
                        return "";
                    }
                }
            }
            public string PartName
            {
                get
                {
                    if (!string.IsNullOrEmpty(sRFID) && sRFID.Length > 50)
                        return sRFID.Substring(20, 20).Trim();
                    else
                    {
                        return "";
                    }
                }
            }
            public int WorkDate
            {
                get
                {
                    if (!string.IsNullOrEmpty(sRFID) && sRFID.Length > 50)
                        return int.Parse(sRFID.Substring(40, 8));
                    else
                    {
                        return -1;
                    }
                }
            }
            public int WorkNo
            {
                get
                {
                    if (!string.IsNullOrEmpty(sRFID) && sRFID.Length > 50)
                        return int.Parse(sRFID.Substring(48, 4));
                    else
                    {
                        return -1;
                    }
                }
            }
            public string GearNoFront
            {
                get
                {
                    if (!string.IsNullOrEmpty(sGearRFID) && sGearRFID.Length > 50)
                        return sGearRFID.Substring(0, 20).Trim();
                    else
                    {
                        return "";
                    }
                }
            }
            public string GearNo4WD
            {
                get
                {
                    if (!string.IsNullOrEmpty(sGearRFID) && sGearRFID.Length > 50)
                        return sGearRFID.Substring(0, 20).Trim();
                    else
                    {
                        return "";
                    }
                }
            }
            public string GearAlcCode
            {
                get
                {
                    if (!string.IsNullOrEmpty(sGearRFID) && sGearRFID.Length >= 10)
                        return sGearRFID.Substring(0, 4);
                    else
                    {
                        return "";
                    }
                }
            }
            public int GearWorkDate
            {
                get
                {
                    if (!string.IsNullOrEmpty(sGearRFID) && sGearRFID.Length > 50)
                        return int.Parse(sGearRFID.Substring(40, 8));
                    else
                    {
                        return -1;
                    }
                }
            }
            public int GearWorkNo
            {
                get
                {
                    if (!string.IsNullOrEmpty(sGearRFID) && sGearRFID.Length > 50)
                        return int.Parse(sGearRFID.Substring(48, 4));
                    else
                    {
                        return -1;
                    }
                }
            }
            public string IMBar
            {
                get
                {
                    if (!string.IsNullOrEmpty(sIMRFID) && sIMRFID.Length > 50)
                        return sIMRFID.Substring(0, 20).Trim();
                    else
                    {
                        return "";
                    }
                }
            }
            public string IMAlcCode
            {
                get
                {
                    if (!string.IsNullOrEmpty(sIMRFID) && sIMRFID.Length >= 10)
                        return sIMRFID.Substring(0, 4);
                    else
                    {
                        return "";
                    }
                }
            }
            public int IMWorkDate
            {
                get
                {
                    if (!string.IsNullOrEmpty(sIMRFID) && sIMRFID.Length > 50)
                        return int.Parse(sIMRFID.Substring(40, 8));
                    else
                    {
                        return -1;
                    }
                }
            }
            public int IMWorkNo
            {
                get
                {
                    if (!string.IsNullOrEmpty(sIMRFID) && sIMRFID.Length > 50)
                        return int.Parse(sIMRFID.Substring(48, 4));
                    else
                    {
                        return -1;
                    }
                }
            }
            //Master Ref
            public string sMaster1;
            public string sOffset1;
            public string sApplyOffset1;
            public string sMaster2;
            public string sOffset2;
            public string sApplyOffset2;
            public int iMasterCnt;
        }
        public class GData
        {
            public GData()
            {
                PLC = new Dictionary<string, PlcReference>();
                PLC.Add(cProc4WDG, new PlcReference());
                PLC.Add(cProcFG, new PlcReference());
                PLC.Add(cProcFC, new PlcReference());
                PLC.Add(cProcFCShim, new PlcReference());
                PLC.Add(cProcIM4WD, new PlcReference());
                PLC.Add(cProcIMFront, new PlcReference());
                PLC.Add(cProcIMShim, new PlcReference());
            }
            //private PlcReference Gear4WD = new PlcReference();
            //private PlcReference GearFront = new PlcReference();
            //private PlcReference CaseFront = new PlcReference();
            //private PlcReference CaseIM = new PlcReference();

            public TB_GearFront _GearFront = new TB_GearFront();
            public TB_FrontCase _FrontCase = new TB_FrontCase();
            public TB_WORKMASTER _WORKMASTER = new TB_WORKMASTER();
            public TB_FrontShim _MEASURE = new TB_FrontShim();

            public TB_FrontSetting _SETTING = new TB_FrontSetting();

            public Dictionary<string, PlcReference> PLC;
        }
        #endregion

        private event Action<string[]> EventGearLine;
        private event Action<string[]> EventFrontLine;
        private event Action<string[]> EventIMCaseLine;

        public static ShimSetting SetInfo;
        public static GData G_Data = new GData();

        private string[,] _PLCName;
        private string[] _MultiAddress;
        private string[] _MultiByteCnt;
        private string[] _MultiType;
        private string[] _MultiBlock;
        private int _RcvArrayCnt;
        //Other Form Rcv
        public static string[] gs_RcvPLCData;

        public Dictionary<string, PlcEnetTask> MainPLC;
        public static Dictionary<string, string[]> DcReadData;
        private DataView dtView_PLC;
        private ulong[] _lcnt;

        public CancellationTokenSource gk_TsCancel = new CancellationTokenSource();
        public bool gb_ParaModifyFlag = false;

        private readonly Image IMG_OFF = Properties.Resources.Off;
        private readonly Image IMG_ON = Properties.Resources.On;
        private readonly Image IMG_Close = Properties.Resources.Close;
        private System.Timers.Timer timer;

        public const string cProc4WDG = "Gear4WD";
        public const string cProcFG = "FrontGear";
        public const string cProcFC = "FrontCase";
        public const string cProcFCShim = "FrontShim";
        public const string cProcIM4WD = "IM4WD";
        public const string cProcIMFront = "IMFront";
        public const string cProcIMShim = "IMShim";

        public const string cPLCGear = "01_GearLine";
        public const string cPLCFront = "02_FrontLine";
        public const string cPLCIMCase = "03_IMCaseLine";

        private const string cWrite_G4_Cmd = "D1000";
        private const string cWrite_G4_ShimNo = "D1000";
        private const string cWrite_G2_Cmd = "D1000";
        private const string cWrite_G2_ShimNo = "D1000";
        private const string cWrite_4WD_Cmd = "D1000";
        private const string cWrite_4WD_ShimNo = "D1000";

        private const string WRITE_PLC_HIPISFLAG = "D5300";
        private const string WRITE_PLC_HIPISDATA = "D5310";
        #region ################### form Setting ###################

        public frmMain()
        {
            InitializeComponent();
        }
        private void LoadingForm()
        {
            Application.Run(new frmWaiting());
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            timer = new System.Timers.Timer
            {
                Interval = 1000
            };
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            ToolBarSplite.TextAlign = ContentAlignment.MiddleCenter;
            ToolBarSplite.Spring = true;

            #region ################### Add UserControls ###################
            // 
            // uC_Home1
            // 
            uC_Home1 = new UC_Home(this as IinterRef);

            uC_Home1.BackColor = Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(38)))), ((int)(((byte)(56)))));
            uC_Home1.Font = new Font("현대하모니 M", 9F);
            uC_Home1.Location = new Point(22, 278);
            uC_Home1.Name = "uC_Home1";
            uC_Home1.Padding = new Padding(5);
            uC_Home1.Size = new Size(331, 228);
            uC_Home1.TabIndex = 3;
            // 
            // uC_LogView1
            // 
            uC_LogView1 = new UC_LogView();

            uC_LogView1.BackColor = Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(38)))), ((int)(((byte)(56)))));
            uC_LogView1.Font = new Font("현대하모니 M", 9F);
            uC_LogView1.Location = new Point(739, 27);
            uC_LogView1.Name = "uC_LogView1";
            uC_LogView1.Padding = new Padding(10);
            uC_LogView1.Size = new Size(332, 225);
            uC_LogView1.TabIndex = 2;
            // 
            // uC_DataView1
            // 
            uC_DataView1 = new UC_DataView(this as IinterRef);

            uC_DataView1.Font = new Font("현대하모니 M", 9F);
            uC_DataView1.Location = new Point(385, 31);
            uC_DataView1.Name = "uC_DataView1";
            uC_DataView1.Padding = new Padding(5);
            uC_DataView1.Size = new Size(324, 222);
            uC_DataView1.TabIndex = 1;
            // 
            // uC_PlcDataState1
            // 
            uC_PlcDataState1 = new UC_PlcDataState(this as IinterRef);

            uC_PlcDataState1.BackColor = Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(38)))), ((int)(((byte)(56)))));
            uC_PlcDataState1.Font = new Font("현대하모니 M", 9F);
            uC_PlcDataState1.Location = new Point(22, 24);
            uC_PlcDataState1.Name = "uC_PlcDataState1";
            uC_PlcDataState1.Padding = new Padding(10);
            uC_PlcDataState1.Size = new Size(331, 229);
            uC_PlcDataState1.TabIndex = 0;
            // uC_PartSetting
            // 
            uC_PartSetting = new UC_PartSetting(this as IinterRef);

            uC_PartSetting.BackColor = Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(38)))), ((int)(((byte)(56)))));
            uC_PartSetting.Font = new Font("현대하모니 M", 9F);
            uC_PartSetting.Location = new Point(22, 24);
            uC_PartSetting.Name = "uC_PartSetting";
            uC_PartSetting.Padding = new Padding(10);
            uC_PartSetting.Size = new Size(331, 229);
            uC_PartSetting.TabIndex = 5;

            //Main Panel에 추가~!
            PMain.Controls.Add(uC_Home1);
            PMain.Controls.Add(uC_LogView1);
            PMain.Controls.Add(uC_DataView1);
            PMain.Controls.Add(uC_PlcDataState1);
            PMain.Controls.Add(uC_PartSetting);

            uC_PlcDataState1.Dock = DockStyle.Fill;
            uC_DataView1.Dock = DockStyle.Fill;
            uC_LogView1.Dock = DockStyle.Fill;
            uC_Home1.Dock = DockStyle.Fill;
            uC_PartSetting.Dock = DockStyle.Fill;
            #endregion

            ProcessLog(("프로그램 초기 로딩중...."));
            ErrorLog(($"프로그램 초기 로딩중...."));

            if (Share.chkRunprocess())
            {
                MessageBox.Show("이미 프로그램이 실행 중입니다.", "프로그램 중복 실행", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }

            //로그파일 저장 유무 확인
            INIFIle tmpINI = new INIFIle(_INIPath);
            _bSavelog = Convert.ToBoolean(tmpINI.GetString("Setting", "Savelog", "true"));

            Thread th = new Thread(new ThreadStart(LoadingForm));
            th.Start();

            FormUIInitial();
            ProcessLog(($"화면 구성 완료...."));

            //Home Initial
            //uC_Home1.uC_Measure.HomeInitial(DateTime.Now.ToShortDateString().Replace("-",""));

            //SPlcRef.preWorkDate = int.Parse(DateTime.Now.ToShortDateString().Replace("-", ""));
            //데이터 조회 초기화 top 100
            //uC_DataView1.SearchInitial();

            //Thread.Sleep(200);

            //ProcessLog(($"PLC 관련 설정중...."));
            //PLCSetting();

            th.Abort();
            this.TopMost = true;
            this.TopMost = false;
        }
        private void FormUIInitial()
        {
            Control.CheckForIllegalCrossThreadCalls = false;

            XmlFormSet FormSet = new XmlFormSet(_FormSetXmlPath);
            XmlFormSet.FormData sRcvFormSet;

            sRcvFormSet = FormSet.GetFormSet(this);
            if (this.StartPosition != FormStartPosition.CenterScreen)
            {
                this.Left = sRcvFormSet.LocationX;
                this.Top = sRcvFormSet.LocationY;
            }
            else
            {
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            if (sRcvFormSet.Maximum != true)
            {
                this.Width = sRcvFormSet.SizeWidth;
                this.Height = sRcvFormSet.SizeHeight;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }

            lblTitle.Text = ($" {sRcvFormSet.Title}");

            //DataGridview 추가시 더블버퍼 사용~!!
            //DGVPlc.DoubleBuffered(true);                

            Thread.Sleep(200);

            uC_PlcDataState1.Visible = false;
            uC_DataView1.Visible = false;
            uC_LogView1.Visible = false;
            uC_Home1.Visible = true;
            uC_Home1.BringToFront();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            frmSetting frmset = new frmSetting(this as IinterRef);

            if (!Share.CheckOpened(frmset.Name))
            {
                frmset.Show();
                frmset.Focus();
            }
        }
        #endregion

        #region ################# Database SQL #################
        public static bool OpenLocalDB(bool InitialFlag = false)
        {
            try
            {
                connSql.Open();
                return true;
            }
            catch (Exception ex)
            {
                if (InitialFlag == false)
                {
                    DBOpenError(ex);
                }
                return false;
            }
        }
        private static void DBOpenError(Exception ex)
        {
            DialogResult ResultError;
            ResultError = MessageBox.Show("[ServerConnError]" + ex.Message + "\r\n" + "프로그램을 종료 후 서버 연결 상태를 확인하세요.", "서버연결 오류/프로그램 종료", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (ResultError == DialogResult.Yes)
            {
                connSql.Close();
                Thread.Sleep(1000);
                Environment.Exit(0);
                Application.Exit();
            }
        }
        private string GetPartName(string alccode)
        {
            using (GEN2_MEASUREDBEntities db = new GEN2_MEASUREDBEntities())
            {
                TB_FrontSetting tmpSet = G_Data._SETTING;
                if (alccode != tmpSet.ALC_Code)
                    tmpSet = db.TB_FrontSetting.Find(alccode);
                return tmpSet.Part_Name;
            }
        }
        private async Task DataSaveGearFront()
        {
            try
            {
                //int saveTime = int.Parse(DateTime.Now.ToString("HHmmss"));
                using (GEN2_MEASUREDBEntities db = new GEN2_MEASUREDBEntities())
                {
                    List<TB_GearFront> tmp = await db.TB_GearFront.SqlQuery($"Select * from TB_GearFront Where Work_Date = {G_Data.PLC[cProcFG].GearWorkDate}" +
                                                        $" and Work_No <> {G_Data.PLC[cProcFG].GearWorkNo} and GearNo_Front = {Share.gAQ(G_Data.PLC[cProcFG].GearNoFront)}").ToListAsync();
                    if (tmp.Count > 0)
                    {
                        ErrorLog($"Same Data Exist - {tmp[0].Work_Date}:{tmp[0].GearNo_4WD}-{tmp[0].Work_No}");
                        return;
                    }
                    TB_GearFront _GearFront = new TB_GearFront
                    {
                        Insert_Time = DateTime.Now,
                        Work_Date = G_Data.PLC[cProcFG].GearWorkDate,
                        Work_No = G_Data.PLC[cProcFG].GearWorkNo,
                        GearNo_Front = G_Data.PLC[cProcFG].GearNoFront,
                        GearNo_4WD = G_Data.PLC[cProcFG].GearNo4WD,
                        Part_Name = GetPartName(G_Data.PLC[cProcFG].GearAlcCode),
                        FGear_G4_Val = G_Data.PLC[cProcFG].Value1,
                        FGear_G4_Min = G_Data.PLC[cProcFG].Min1,
                        FGear_G4_Max = G_Data.PLC[cProcFG].Max1,
                        FGear_G2_Val = G_Data.PLC[cProcFG].Value2,
                        FGear_G2_Min = G_Data.PLC[cProcFG].Min2,
                        FGear_G2_Max = G_Data.PLC[cProcFG].Max2
                    };
                    G_Data._GearFront = _GearFront;
                    db.TB_GearFront.Add(_GearFront);
                    
                    Task.Run(() => uC_Home1.ShowMeasure(G_Data, WorkStep.FrontGear));

                    int ir = await db.SaveChangesAsync();
                                        
                }
            }
            catch (Exception ex)
            {
                StackTrace trace = new StackTrace(ex, true);
                StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                int lineNumber = stackFrame.GetFileLineNumber();

                ErrorLog(($"({lineNumber})[DataSaveGearFront] : {ex.ToString()}"));
            }
        }
        private async Task DataSaveCaseFront()
        {
            try
            {
                //int saveTime = int.Parse(DateTime.Now.ToString("HHmmss"));
                using (GEN2_MEASUREDBEntities db = new GEN2_MEASUREDBEntities())
                {
                    TB_FrontCase _FrontCase = new TB_FrontCase()
                    {
                        Insert_Time = DateTime.Now,
                        Work_Date = G_Data.PLC[cProcFC].WorkDate,
                        Work_No = G_Data.PLC[cProcFC].WorkNo,
                        FrontCase_Bar = G_Data.PLC[cProcFC].Barcode,
                        Part_Name = G_Data.PLC[cProcFC].PartName,
                        FCase_G4_Val = G_Data.PLC[cProcFC].Value1,
                        FCase_G4_Min = G_Data.PLC[cProcFC].Min1,
                        FCase_G4_Max = G_Data.PLC[cProcFC].Max1,
                        FCase_4WD_Val = G_Data.PLC[cProcFC].Value2,
                        FCase_4WD_Min = G_Data.PLC[cProcFC].Min2,
                        FCase_4WD_Max = G_Data.PLC[cProcFC].Max2
                    };
                    G_Data._FrontCase = _FrontCase;
                    db.TB_FrontCase.Add(_FrontCase);
                    int ir = await db.SaveChangesAsync();

                    Task.Run(() => uC_Home1.ShowMeasure(G_Data, WorkStep.FrontCase));

                    if (G_Data.PLC[cProcFC].AlcCode != G_Data._SETTING.ALC_Code)
                        G_Data._SETTING = db.TB_FrontSetting.Find(G_Data.PLC[cProcFC].AlcCode);

                    List<TB_GearFront> tmpFg = await db.TB_GearFront.SqlQuery($"Select * from TB_GearFront Where Work_Date = {_FrontCase.Work_Date} " +
                                                                                            $" and GearNo_Front = {Share.gAQ(G_Data.PLC[cProcFC].GearNo)} " +
                                                                                            $" Order by Insert_Time Desc").ToListAsync();
                    if (tmpFg.Count == 0)
                    {
                        ErrorLog($"No Exist FrontGear Data FGearCount:{tmpFg.Count}");
                        return;
                    }
                    TB_FrontShim tmpM = db.TB_FrontShim.Find(_FrontCase.Work_Date, _FrontCase.FrontCase_Bar);
                    bool bInData = false;
                    if (tmpM == null)
                    {//데이터 추가
                        bInData = true;
                        tmpM = new TB_FrontShim();
                        tmpM.FrontCase_Bar = _FrontCase.FrontCase_Bar;
                        tmpM.Work_Date = _FrontCase.Work_Date;
                        tmpM.Work_No = G_Data.PLC[cProcFC].WorkNo;
                        tmpM.Part_Name = _FrontCase.Part_Name;
                        tmpM.GearNo_Front = tmpFg[0].GearNo_Front;
                    }
                    tmpM.FCase_G4_Val = _FrontCase.FCase_G4_Val;
                    tmpM.FGear_G4_Val = tmpFg[0].FGear_G4_Val;
                    tmpM.FGear_G2_Val = tmpFg[0].FGear_G2_Val;
                    tmpM.StandardDis_Val = G_Data._SETTING.StandardVal;
                    tmpM.ShimG4_Val = tmpM.FCase_G4_Val + tmpM.StandardDis_Val - tmpM.FGear_G4_Val;
                    tmpM.ShimG4_Offset = G_Data._SETTING.Gain_G4;

                    if (bInData) db.TB_FrontShim.Add(tmpM);

                    ir = await db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                StackTrace trace = new StackTrace(ex, true);
                StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                int lineNumber = stackFrame.GetFileLineNumber();

                ErrorLog(($"({lineNumber})[DataSaveCaseFront] : {ex.ToString()}"));
            }
        }

        private async Task FindFrontShim()
        {
            try
            {
                //int saveTime = int.Parse(DateTime.Now.ToString("HHmmss"));
                using (GEN2_MEASUREDBEntities db = new GEN2_MEASUREDBEntities())
                {
                    if (G_Data.PLC[cProcFCShim].AlcCode != G_Data._SETTING.ALC_Code)
                        G_Data._SETTING = await db.TB_FrontSetting.FindAsync(G_Data.PLC[cProcFCShim].AlcCode);

                    TB_FrontShim tmpM = await db.TB_FrontShim.FindAsync(G_Data.PLC[cProcFCShim].WorkDate, G_Data.PLC[cProcFCShim].Barcode);

                    if (tmpM == null)
                    {//데이터 추가
                        ErrorLog($"FindFrontShim측정 공정 데이터 누락~!!! - {G_Data.PLC[cProcFCShim].WorkDate}:{G_Data.PLC[cProcFCShim].Barcode}");
                        return;
                    }

                    int iShimNo = 0;
                    int iShimCnt = Convert.ToInt32((G_Data._SETTING.Shim_G4_Max - G_Data._SETTING.Shim_G4_Min) / G_Data._SETTING.Shim_G4_Range + 1);
                    double dShimVal = (double)tmpM.ShimG4_Val;
                    double dShimSel = (double)G_Data._SETTING.Shim_G4_Min;
                    if (dShimVal >= G_Data._SETTING.Shim_G4_Min && dShimVal < (double)(G_Data._SETTING.Shim_G4_Max + G_Data._SETTING.Shim_G4_Range))
                    {
                        for (iShimNo = 1; iShimNo <= iShimCnt; iShimNo++)
                        {
                            if (dShimVal >= dShimSel && dShimVal < (double)(dShimSel + G_Data._SETTING.Shim_G4_Range))
                            {
                                //Shim Number & ShimVal
                                //iShimNo.ToString();
                                //($"{dShimSel:F3}");
                                Task.Run(() => uC_Home1.ShowShim(G_Data.PLC[cProcFCShim], iShimNo, dShimSel));
                                WritePlcData(cPLCFront, cWrite_G4_ShimNo, iShimNo.ToString(), PlcEnetTask.DataType.DEC);
                                WritePlcData(cPLCFront, cWrite_G4_Cmd, "1", PlcEnetTask.DataType.DEC);

                                ProcessLog(($"[findG4Shim Drive Value] : {dShimVal}"));

                                break; // TODO: might not be correct. Was : Exit For
                            }
                            dShimSel += (double)G_Data._SETTING.Shim_G4_Range;
                        }
                    }
                    else
                    {
                        WritePlcData(cPLCFront, cWrite_G4_Cmd, "9", PlcEnetTask.DataType.DEC);
                        ProcessLog(($"[findG4Shim Value Error] : {dShimVal} , ShimGrade를 벗어 났습니다."));
                    }
                }
            }
            catch (Exception ex)
            {
                StackTrace trace = new StackTrace(ex, true);
                StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                int lineNumber = stackFrame.GetFileLineNumber();

                ErrorLog(($"({lineNumber})[FindFrontShim] : {ex.ToString()}"));
            }
        }
        private async Task DataSaveMaster(PlcReference refplc, string indexstate, string menust = "Measure")
        {
            try
            {
                using (GEN2_MEASUREDBEntities db = new GEN2_MEASUREDBEntities())
                {
                    string sIndexName = $"{indexstate}_{(indexstate.Contains("Gear") ? "G4" : "4WD")}";
                    int iWorkDate = int.Parse(DateTime.Now.ToShortDateString().Replace("-", ""));
                    int iWorkNo = refplc.iMasterCnt;
                    string sBar = ($"{sIndexName}_{Share.StrPad(iWorkNo.ToString(), 4, "0", true)}");

                    TB_WORKMASTER _WORKMASTER = new TB_WORKMASTER();
                    _WORKMASTER.Index_Name = sIndexName;
                    _WORKMASTER.Work_Date = iWorkDate;
                    _WORKMASTER.Part_Name = refplc.PartName;

                    _WORKMASTER.Master_No = sBar;
                    _WORKMASTER.Master = refplc.sMaster1;
                    _WORKMASTER.Measure = refplc.Value1.ToString();
                    if (menust.Equals("Apply")) //else  Measure
                    {
                        _WORKMASTER.Pre_Offset = refplc.sOffset1;
                        _WORKMASTER.Apply_Offset = refplc.sApplyOffset1;
                        _WORKMASTER.Difference = (double.Parse(refplc.sMaster1) - refplc.Value1).ToString("0.000");
                        _WORKMASTER.Cal_Offset = (double.Parse(refplc.sOffset1) - double.Parse(_WORKMASTER.Difference)).ToString("0.000");
                    }

                    db.TB_WORKMASTER.Add(_WORKMASTER);
                                       
                    sIndexName = $"{indexstate}_{(indexstate.Contains("Gear") ? "G2" : "G4")}";
                    sBar = ($"{sIndexName}_{Share.StrPad(iWorkNo.ToString(), 4, "0", true)}");
                    _WORKMASTER.Index_Name = sIndexName;
                    _WORKMASTER.Master_No = sBar;
                    _WORKMASTER.Master = refplc.sMaster2;
                    _WORKMASTER.Measure = refplc.Value2.ToString();
                    if (menust.Equals("Apply"))
                    {
                        _WORKMASTER.Pre_Offset = refplc.sOffset2;
                        _WORKMASTER.Apply_Offset = refplc.sApplyOffset2;
                        _WORKMASTER.Difference = (double.Parse(refplc.sMaster2) - refplc.Value2).ToString("0.000");
                        _WORKMASTER.Cal_Offset = (double.Parse(refplc.sOffset2) - double.Parse(_WORKMASTER.Difference)).ToString("0.000");
                    }
                    db.TB_WORKMASTER.Add(_WORKMASTER);
                    
                    G_Data._WORKMASTER = _WORKMASTER;

                    Task.Run(() => uC_Home1.uC_Measure.UpdateData(G_Data, (indexstate.Contains("Gear") ? WorkStep.FrontGear : WorkStep.FrontCase)));

                    await db.SaveChangesAsync();
                    
                }
            }
            catch (Exception ex)
            {
                StackTrace trace = new StackTrace(ex, true);
                StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                int lineNumber = stackFrame.GetFileLineNumber();

                ErrorLog(($"({lineNumber})[DataSaveMaster] : {ex.ToString()}"));
            }
        }

        private void UploadHipis(PlcReference refplc, string shimval)
        {
            float fShim_Val;
            int iIndex;
            int iShimCnt;
            float fShimSelect_Val;

            string[] sReturn = new string[2];

            try
            {

                //------------Shim ---------------------------------------------
                fShim_Val = Convert.ToSingle(shimval);
                iShimCnt = Convert.ToInt32((SetInfo.Max - SetInfo.Min) / SetInfo.Range + 1);
                if (fShim_Val >= SetInfo.Min && fShim_Val < SetInfo.Max + SetInfo.Range)
                {
                    fShimSelect_Val = SetInfo.Min;
                    for (iIndex = 1; iIndex <= iShimCnt; iIndex++)
                    {
                        if (fShim_Val >= fShimSelect_Val && fShim_Val < (float)(fShimSelect_Val + SetInfo.Range))
                        {
                            ProcessLog(($"[findCalcuShim Value] : {fShim_Val}"));
                            break; // TODO: might not be correct. Was : Exit For
                        }
                        fShimSelect_Val += SetInfo.Range;
                    }

                    StringBuilder sHipisData = new StringBuilder();
                    sHipisData.Append(Share.StrPad($"{refplc.Barcode}", 40));
                    sHipisData.Append("  ");
                    sHipisData.Append("OK");

                    sHipisData.Append(Share.StrPad($"{fShimSelect_Val:F3}", 8));
                    sHipisData.Append(Share.StrPad($"{fShimSelect_Val + SetInfo.Range:F3}", 8));
                    sHipisData.Append(Share.StrPad($"{fShimSelect_Val:F3}", 8));
                    sHipisData.Append("OK");

                    //WritePlcData(0, WRITE_PLC_HIPISDATA, sHipisData.ToString(), PlcEnetTask.DataType.ASCII, true);
                    //WritePlcData(0, WRITE_PLC_HIPISFLAG, "1", PlcEnetTask.DataType.DEC);

                    if (frmMain.connSql.State != ConnectionState.Open)
                        frmMain.OpenLocalDB();
                    string sql = " UPDATE " + frmMain.TB_MeasureName + " SET Shim_Chk_Val = " + Share.gAQ(fShimSelect_Val.ToString("0.000")) +
                                    " WHERE WORK_DATE = " + refplc.WorkDate + " And WORK_NO = " + refplc.WorkNo;
                    if (SetInfo.ShimPosition == 1)
                        sql = " UPDATE " + frmMain.TB_MeasureName + " SET ShimGen2_Chk_Val = " + Share.gAQ(fShimSelect_Val.ToString("0.000")) +
                                    " WHERE WORK_DATE = " + refplc.WorkDate + " And WORK_NO = " + refplc.WorkNo;
                    SqlCommand cmd = new SqlCommand(sql, frmMain.connSql);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                else
                {
                    ProcessLog(($"[findCalcuShim Value Error] : {fShim_Val} , ShimGrade를 벗어 났습니다."));
                }

            }
            catch (Exception ex)
            {
                StackTrace trace = new StackTrace(ex, true);
                StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                int lineNumber = stackFrame.GetFileLineNumber();

                ErrorLog(($"{Share.GetNow_ms()} ({lineNumber})[MainfindShim Error] : {ex.ToString()}"));
            }

        }

        #endregion

        #region ##################### Plc Setting #####################
        private void BindingPLCRefFile(string PLCNAME)
        {
            string sql;
            int ArrayCnt;
            if (Directory.Exists(_ReferDir) == false)
            {
                Directory.CreateDirectory(_ReferDir);
            }

            if (File.Exists(_PLCRefPath))
            {
                sql = "Select DataType,StartAddress,ByteLenth,BlockNum from PLCAddress " +
                    "where PlcName = " + Share.gAQ(PLCNAME) + "Order by PlcName ASC,BlockNum ASC,IndexNo ASC";
                string Connstr = MyApp.RootMDB(_PLCRefPath);

                try
                {
                    using (OleDbConnection connDB = new OleDbConnection(Connstr))
                    {
                        DataSet dsData = new DataSet();
                        connDB.Open();
                        OleDbDataAdapter oledbAdapter = new OleDbDataAdapter(sql, connDB);
                        oledbAdapter.Fill(dsData, PLCNAME);

                        DataTableCollection tables = dsData.Tables;
                        DataView tmpView = new DataView(tables[PLCNAME]);

                        ArrayCnt = tmpView.Table.Rows.Count;
                        _RcvArrayCnt += ArrayCnt;
                        Array.Resize(ref gs_RcvPLCData, _RcvArrayCnt);

                        Array.Resize(ref _MultiAddress, (ArrayCnt));
                        Array.Resize(ref _MultiByteCnt, (ArrayCnt));
                        Array.Resize(ref _MultiType, (ArrayCnt));
                        Array.Resize(ref _MultiBlock, (ArrayCnt));

                        for (int i = 0; i <= ArrayCnt - 1; i++)
                        {
                            _MultiType[i] = tmpView[i]["DataType"].ToString();
                            _MultiAddress[i] = tmpView[i]["StartAddress"].ToString();
                            _MultiByteCnt[i] = tmpView[i]["ByteLenth"].ToString();
                            _MultiBlock[i] = tmpView[i]["BlockNum"].ToString();
                        }
                        dsData.Dispose();
                        tmpView.Dispose();

                        oledbAdapter.Dispose();
                    }

                }
                catch (Exception ex)
                {
                    StackTrace trace = new StackTrace(ex, true);
                    StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                    int lineNumber = stackFrame.GetFileLineNumber();

                    ErrorLog(($"({lineNumber}) : {ex.ToString()}"));

                }

            }
        }
        public void PLCDispose()
        {
            try
            {
                int i = 0;
                foreach (KeyValuePair<string, PlcEnetTask> item in MainPLC)
                {
                    item.Value.PLCEnable = false;
                    item.Value.TaskRun = false;
                    Thread.Sleep(200);
                    DelectlblPLCState(i);
                    Thread.Sleep(200);
                    item.Value.CloseSocket_PLC();
                    //item = null;
                    i++;
                }
                MainPLC = null;
                //for (int i = 0; i < MainPLC.Count; i++)
                //{
                //    //MainPLC[i].tmrChkPLC.Stop();
                //    MainPLC[i].PLCEnable = false;
                //    MainPLC[i].TaskRun = false;
                //    Thread.Sleep(200);

                //    DelectlblPLCState(i);
                //    //MainPLC[i].thrPLCLoop.Abort();
                //    Thread.Sleep(300);
                //    MainPLC[i].CloseSocket_PLC();
                //    MainPLC[i] = null;
                //}
                Thread.Sleep(200);
            }
            catch (Exception ex)
            {
                StackTrace trace = new StackTrace(ex, true);
                StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                int lineNumber = stackFrame.GetFileLineNumber();

                ErrorLog(($"({lineNumber}) : {ex.ToString()}"));
            }

        }
        public void PLCSetting()
        {
            XmlPLCSet XmlPlc = new XmlPLCSet(_PlcSetXmlPath);
            string[] sPlcName = XmlPlc.GetSectionn();
            XmlPLCSet.PlcStru RcvData = new XmlPLCSet.PlcStru();
            XmlPLCSet.BlockStru[] RcvBlockData;
            int i = 0;

            try
            {
                DataTable ttable = new DataTable("PLC");
                ttable.Columns.Add("PLCName", typeof(string));
                ttable.Columns.Add("PLCSection", typeof(string));
                ttable.Columns.Add("BlockNum", typeof(string));
                ttable.Columns.Add("BlockIndex", typeof(int));
                dtView_PLC = null;
                dtView_PLC = new DataView(ttable);

                _PLCName = new string[2, 2];
                MainPLC = null;
                MainPLC = new Dictionary<string, PlcEnetTask>();
                DcReadData = null;
                DcReadData = new Dictionary<string, string[]>();

                foreach (string StrTmp in sPlcName)
                {
                    RcvData = XmlPlc.GetPlcSet(StrTmp);
                    BindingPLCRefFile(RcvData.Name);
                    //Array.Resize(ref MainPLC, i + 1);
                    _PLCName = (string[,])Share.ResizeArray(_PLCName, new int[] { 2, i + 1 });

                    //PLCName Insert
                    _PLCName[0, i] = RcvData.Name;
                    _PLCName[1, i] = gs_RcvPLCData.Length.ToString();
                    //ArrySize                                           

                    if (RcvData.MultiReadOnOff)
                    {

                        //MainPLC[i] = new PlcEnetTh(RcvData.Name, _MultiAddress, _MultiByteCnt, _MultiType, RcvData.Type);
                        MainPLC.Add(RcvData.Name, new PlcEnetTask(RcvData.Name, RcvData.Ip, RcvData.Port, _MultiAddress, _MultiByteCnt, _MultiType, RcvData.Type));
                    }
                    else
                    {
                        //Block Read
                        RcvBlockData = XmlPlc.GetBlockAll(RcvData.Section);
                        int n = 0;
                        string[] sStartAddress = new string[RcvBlockData.Length];
                        string[] sReadWordcnt = new string[RcvBlockData.Length];
                        string[] sBlocknum = new string[RcvBlockData.Length];

                        foreach (XmlPLCSet.BlockStru tmpblock in RcvBlockData)
                        {

                            sStartAddress[n] = tmpblock.StartAddress;
                            sReadWordcnt[n] = tmpblock.ReadingWords.ToString();
                            sBlocknum[n] = tmpblock.Num;
                            n += 1;
                            ttable.Rows.Add(RcvData.Name, tmpblock.Section, tmpblock.Num, FindIndexPLCMap(RcvData.Name, tmpblock.Num));
                            //BindingPLCRefFileMultiBlock(RcvData.Name, tmpblock.Num);
                        }
                        //MainPLC[i] = new PlcEnetTh(RcvData.Name, sStartAddress, sReadWordcnt,
                        //                   _MultiBlock, _MultiAddress, _MultiByteCnt, _MultiType, RcvData.Type, 100);
                        MainPLC.Add(RcvData.Name, new PlcEnetTask(RcvData.Name, RcvData.Ip, RcvData.Port, sStartAddress, sReadWordcnt,
                                           _MultiBlock, _MultiAddress, _MultiByteCnt, _MultiType, RcvData.Type, RcvBlockData[0].DelayTime));

                    }

                    if (RcvData.Type.Equals("SIEMENS"))
                    {
                        //MainPLC[RcvData.Name].OnRcvSiemens += SiemensPLCEventHandle;
                        //MainPLC[RcvData.Name].OnErrorRecive += SiemensPLCEventError;
                    }
                    else
                    {
                        MainPLC[RcvData.Name].OnRecive += PLCEventHandle;
                        MainPLC[RcvData.Name].OnErrorRecive += PLCEventError;
                    }

                    MainPLC[RcvData.Name].lblPLCState = AddlblPLCState(i, ref StusBar);
                    MainPLC[RcvData.Name].lblPLCState.ToolTipText = $"{RcvData.Ip}:{RcvData.Port}";

                    MainPLC[RcvData.Name].OpenSocket_PLC(RcvData.Ip, RcvData.Port);

                    i++;
                }
                Array.Resize(ref _lcnt, dtView_PLC.Count);         //gs_RcvPLCData Array Setting

                int itmp;
                for (i = _PLCName.Length / 2 - 1; i >= 1; i += -1)
                {
                    itmp = Convert.ToInt32(_PLCName[1, i - 1]);
                    _PLCName[1, i - 1] = _PLCName[1, i];
                    _PLCName[1, i] = itmp.ToString();
                }
                _PLCName[1, 0] = "0";
                XmlPlc = null;

                EventGearLine += GearProcess;
                EventFrontLine += FrontProcess;
                EventIMCaseLine += IMCaseProcess;
            }
            catch (Exception ex)
            {
                StackTrace trace = new StackTrace(ex, true);
                StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                int lineNumber = stackFrame.GetFileLineNumber();

                ErrorLog(($"({lineNumber}) : {ex.ToString()}"));
            }

        }

        private void DelectlblPLCState(int Index)
        {
            StusBar.Items.RemoveAt(StusBar.Items.Count - 1);
        }
        private ToolStripStatusLabel AddlblPLCState(int Index, ref StatusStrip stbar)
        {
            ToolStripStatusLabel lblState = new ToolStripStatusLabel
            {
                ImageAlign = ContentAlignment.MiddleCenter,
                Name = "lblPlcState" + Index.ToString(),
                Size = new Size(73, 17),
                TextAlign = ContentAlignment.MiddleCenter
            };
            stbar.Items.Add(lblState);
            //lblState.Spring = true;

            return lblState;
        }
        private int FindIndexPLCMap(string PLCNAME, string BlockNum)
        {
            string sql;
            int iReturn = -1;

            if (Directory.Exists(_ReferDir) == false)
            {
                Directory.CreateDirectory(_ReferDir);
            }

            if (File.Exists(_PLCRefPath))
            {
                sql = "Select * from PLCAddress " + "Order by PlcName ASC,BlockNum ASC,IndexNo ASC";
                string Connstr = MyApp.RootMDB(_PLCRefPath);

                try
                {
                    using (OleDbConnection connDB = new OleDbConnection(Connstr))
                    {
                        DataSet dsDT = new DataSet();
                        connDB.Open();
                        OleDbDataAdapter oledbAdp = new OleDbDataAdapter(sql, connDB);
                        oledbAdp.Fill(dsDT, PLCNAME);

                        DataTableCollection tables = dsDT.Tables;
                        DataView tmpView = new DataView(tables[PLCNAME]);
                        string[] s = new string[2];
                        s[0] = PLCNAME;
                        s[1] = BlockNum;

                        tmpView.Sort = "PlcName,BlockNum";
                        iReturn = tmpView.Find(s);

                        oledbAdp.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    iReturn = -1;
                    MessageBox.Show("[FindIndexPLCMap Error]" + ex.Message);
                    StackTrace trace = new StackTrace(ex, true);
                    StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                    int lineNumber = stackFrame.GetFileLineNumber();

                    ErrorLog(($"({lineNumber}) : {ex.ToString()}"));
                }
            }

            return iReturn;
        }
        private void PLCEventError(string PLCName, string Description, Share.ConLvl ConstLevel)
        {
            if (ConstLevel != Share.ConLvl.Low)
            {
                ErrorLog(($"({PLCName}) : {Description}"));
            }
        }
        private void PLCEventHandle(string PLCName, PlcEnetTask.PLCReadType ReadType, string[] rcvData, string BlockNum, string RcvTime)
        {
            int[] iIndexNum = new int[2];
            try
            {
                iIndexNum = GetPLCIndex(PLCName, BlockNum);
                if (_lcnt[iIndexNum[0]] == long.MaxValue - 1)
                    _lcnt[iIndexNum[0]] = 0;
                _lcnt[iIndexNum[0]]++;

                //MultiRead
                if (ReadType == PlcEnetTask.PLCReadType.MultiRead)
                {
                    for (int i = 0; i <= _PLCName.Length / 2; i++)
                    {
                        if (PLCName.ToUpper().Equals(_PLCName[0, i]))
                        {
                            iIndexNum[1] = Convert.ToInt32(_PLCName[1, i]);
                            rcvData.CopyTo(gs_RcvPLCData, iIndexNum[1]);
                        }
                    }
                    //MultiBlockRead
                }
                else
                {
                    for (int i = 0; i < _PLCName.Length / 2; i++)
                    {
                        if (PLCName.ToUpper().Equals(_PLCName[0, i]))
                        {
                            //Array.Copy(rcvData, 0, gs_RcvPLCData, iIndexNum, rcvData.Length);
                            rcvData.CopyTo(gs_RcvPLCData, iIndexNum[1]);
                        }
                    }
                }
                if (PLCName.ToUpper().Equals("01_GearLine") && BlockNum.Equals("01")) Task.Run(() => EventGearLine?.Invoke(rcvData));
                if (PLCName.ToUpper().Equals("02_FrontLine") && BlockNum.Equals("01")) Task.Run(() => EventFrontLine?.Invoke(rcvData));
                if (PLCName.ToUpper().Equals("03_IMCaseLine") && BlockNum.Equals("01")) Task.Run(() => EventIMCaseLine?.Invoke(rcvData));

                //Call Async Data spread                   
                if (gb_ExitFlag == false && uC_PlcDataState1.Visible)
                {
                    string msg = $"Name: {PLCName}_{BlockNum}, RcvTime: {RcvTime}, RD_Cnt: {_lcnt[iIndexNum[0]]}";
                    iIndexNum = GetPLCIndex(PLCName, "01");
                    Task.Run(() => uC_PlcDataState1.PLCProcessAsync(PLCName, msg, iIndexNum, gk_TsCancel.Token));
                }
            }
            catch (Exception ex)
            {
                StackTrace trace = new StackTrace(ex, true);
                StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                int lineNumber = stackFrame.GetFileLineNumber();

                ErrorLog(($"({lineNumber}) : {ex.ToString()}"));
            }
        }
        private void GearProcess(string[] rcvData)
        {
            try
            {
                #region ===========DataPasing============
                string[] s;

                s = rcvData[0].Split(':');
                G_Data.PLC[cProcFG].icmd = int.Parse(s[1]);

                s = rcvData[12].Split(':');
                if (s[1].All(char.IsNumber)) G_Data.PLC[cProcFG].Value1 = (double)(int.Parse(s[1]) * 0.001d);
                s = rcvData[12].Split(':');
                if (s[1].All(char.IsNumber)) G_Data.PLC[cProcFG].sMaster1 = (int.Parse(s[1]) * 0.001d).ToString("0.000");
                s = rcvData[12].Split(':');
                if (s[1].All(char.IsNumber)) G_Data.PLC[cProcFG].sOffset1 = (int.Parse(s[1]) * 0.001d).ToString("0.000");
                s = rcvData[12].Split(':');
                if (s[1].All(char.IsNumber)) G_Data.PLC[cProcFG].sApplyOffset1 = (int.Parse(s[1]) * 0.001d).ToString("0.000");
                s = rcvData[12].Split(':');
                if (s[1].All(char.IsNumber)) G_Data.PLC[cProcFG].Min1 = (double)(int.Parse(s[1]) * 0.001d);
                s = rcvData[12].Split(':');
                if (s[1].All(char.IsNumber)) G_Data.PLC[cProcFG].Max1 = (double)(int.Parse(s[1]) * 0.001d);

                s = rcvData[12].Split(':');
                if (s[1].All(char.IsNumber)) G_Data.PLC[cProcFG].Value2 = (double)(int.Parse(s[1]) * 0.001d);
                s = rcvData[12].Split(':');
                if (s[1].All(char.IsNumber)) G_Data.PLC[cProcFG].sMaster2 = (int.Parse(s[1]) * 0.001d).ToString("0.000");
                s = rcvData[12].Split(':');
                if (s[1].All(char.IsNumber)) G_Data.PLC[cProcFG].sOffset2 = (int.Parse(s[1]) * 0.001d).ToString("0.000");
                s = rcvData[12].Split(':');
                if (s[1].All(char.IsNumber)) G_Data.PLC[cProcFG].sApplyOffset2 = (int.Parse(s[1]) * 0.001d).ToString("0.000");
                s = rcvData[12].Split(':');
                if (s[1].All(char.IsNumber)) G_Data.PLC[cProcFG].Min2 = (double)(int.Parse(s[1]) * 0.001d);
                s = rcvData[12].Split(':');
                if (s[1].All(char.IsNumber)) G_Data.PLC[cProcFG].Max2 = (double)(int.Parse(s[1]) * 0.001d);

                s = rcvData[15].Split(':');
                G_Data.PLC[cProcFG].sGearRFID = s[1].Trim().Trim('\0');

                #endregion

                if (G_Data.PLC[cProcFG].icmd != G_Data.PLC[cProcFG].iflag)
                {
                    if (G_Data.PLC[cProcFG].icmd == 1 && G_Data.PLC[cProcFG].iflag == 0)
                    {
                        G_Data.PLC[cProcFG].iMasterCnt = 0;
                        //Data Save & Update DataGridview
                        Task.Run(() => DataSaveGearFront());
                    }
                    else if (G_Data.PLC[cProcFG].icmd == 4)
                    {
                        G_Data.PLC[cProcFG].iMasterCnt++;
                        Task.Run(() => DataSaveMaster(G_Data.PLC[cProcFG], "FrontGear"));
                        ProcessLog(($"[FrontGear] : 워크마스터 측정...."));
                    }
                    else if (G_Data.PLC[cProcFG].icmd == 5)
                    {                        
                        Task.Run(() => DataSaveMaster(G_Data.PLC[cProcFG], "FrontGear","Apply"));
                        ProcessLog(($"[FrontGear] : 워크마스터 측정 적용...."));
                        G_Data.PLC[cProcFG].iMasterCnt = 0;
                    }
                    else if (G_Data.PLC[cProcFG].icmd == 0)
                    {
                        //Clear
                        Task.Run(() => uC_Home1.uC_Measure.ClearGearFrontText());
                    }
                    G_Data.PLC[cProcFG].iflag = G_Data.PLC[cProcFG].icmd;
                }
            }
            catch (Exception ex)
            {
                StackTrace trace = new StackTrace(ex, true);
                StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                int lineNumber = stackFrame.GetFileLineNumber();

                ErrorLog(($"[GearProcess]({lineNumber}) : {ex.ToString()}"));
            }
        }
        private void FrontProcess(string[] rcvData)
        {
            //Frontcase DataSave & FrontShim Calcu
            //Shim Process 
            #region ===========DataPasing============
            string[] s;

            s = rcvData[0].Split(':');
            G_Data.PLC[cProcFC].icmd = int.Parse(s[1]);

            s = rcvData[12].Split(':');
            if (s[1].All(char.IsNumber)) G_Data.PLC[cProcFC].Value1 = (double)(int.Parse(s[1]) * 0.001d);
            s = rcvData[12].Split(':');
            if (s[1].All(char.IsNumber)) G_Data.PLC[cProcFC].sMaster1 = (int.Parse(s[1]) * 0.001d).ToString("0.000");
            s = rcvData[12].Split(':');
            if (s[1].All(char.IsNumber)) G_Data.PLC[cProcFC].sOffset1 = (int.Parse(s[1]) * 0.001d).ToString("0.000");
            s = rcvData[12].Split(':');
            if (s[1].All(char.IsNumber)) G_Data.PLC[cProcFC].sApplyOffset1 = (int.Parse(s[1]) * 0.001d).ToString("0.000");
            s = rcvData[12].Split(':');
            if (s[1].All(char.IsNumber)) G_Data.PLC[cProcFC].Min1 = (double)(int.Parse(s[1]) * 0.001d);
            s = rcvData[12].Split(':');
            if (s[1].All(char.IsNumber)) G_Data.PLC[cProcFC].Max1 = (double)(int.Parse(s[1]) * 0.001d);

            s = rcvData[12].Split(':');
            if (s[1].All(char.IsNumber)) G_Data.PLC[cProcFC].Value2 = (double)(int.Parse(s[1]) * 0.001d);
            s = rcvData[12].Split(':');
            if (s[1].All(char.IsNumber)) G_Data.PLC[cProcFC].sMaster2 = (int.Parse(s[1]) * 0.001d).ToString("0.000");
            s = rcvData[12].Split(':');
            if (s[1].All(char.IsNumber)) G_Data.PLC[cProcFC].sOffset2 = (int.Parse(s[1]) * 0.001d).ToString("0.000");
            s = rcvData[12].Split(':');
            if (s[1].All(char.IsNumber)) G_Data.PLC[cProcFC].sApplyOffset2 = (int.Parse(s[1]) * 0.001d).ToString("0.000");
            s = rcvData[12].Split(':');
            if (s[1].All(char.IsNumber)) G_Data.PLC[cProcFC].Min2 = (double)(int.Parse(s[1]) * 0.001d);
            s = rcvData[12].Split(':');
            if (s[1].All(char.IsNumber)) G_Data.PLC[cProcFC].Max2 = (double)(int.Parse(s[1]) * 0.001d);

            s = rcvData[15].Split(':');
            G_Data.PLC[cProcFC].sRFID = s[1].Trim().Trim('\0');

            #endregion

            if (G_Data.PLC[cProcFC].icmd != G_Data.PLC[cProcFC].iflag)
            {
                if (G_Data.PLC[cProcFC].icmd == 1 && G_Data.PLC[cProcFC].iflag == 0)
                {
                    G_Data.PLC[cProcFC].iMasterCnt = 0;
                    //Data Save & Update DataGridview
                    Task.Run(() => DataSaveCaseFront());
                }
                else if (G_Data.PLC[cProcFC].icmd == 4)
                {
                    G_Data.PLC[cProcFC].iMasterCnt++;
                    Task.Run(() => DataSaveMaster(G_Data.PLC[cProcFC], "FrontCase"));                    
                }
                else if (G_Data.PLC[cProcFC].icmd == 5)
                {
                    Task.Run(() => DataSaveMaster(G_Data.PLC[cProcFC], "FrontCase", "Apply"));                    
                    G_Data.PLC[cProcFC].iMasterCnt = 0;
                }
                else if (G_Data.PLC[cProcFC].icmd == 0)
                {
                    //Clear
                    Task.Run(() => uC_Home1.uC_Measure.ClearFrontCaseText());
                }
                G_Data.PLC[cProcFC].iflag = G_Data.PLC[cProcFC].icmd;
            }

            #region ===========DataPasing============
            s = rcvData[0].Split(':');
            G_Data.PLC[cProcFCShim].icmd = int.Parse(s[1]);

            s = rcvData[12].Split(':');
            if (s[1].All(char.IsNumber)) G_Data.PLC[cProcFCShim].Value1 = (double)(int.Parse(s[1]) * 0.001d);
            s = rcvData[12].Split(':');
            if (s[1].All(char.IsNumber)) G_Data.PLC[cProcFCShim].sMaster1 = (int.Parse(s[1]) * 0.001d).ToString("0.000");
            s = rcvData[12].Split(':');
            if (s[1].All(char.IsNumber)) G_Data.PLC[cProcFCShim].sOffset1 = (int.Parse(s[1]) * 0.001d).ToString("0.000");
            s = rcvData[12].Split(':');
            if (s[1].All(char.IsNumber)) G_Data.PLC[cProcFCShim].sApplyOffset1 = (int.Parse(s[1]) * 0.001d).ToString("0.000");
            s = rcvData[12].Split(':');
            if (s[1].All(char.IsNumber)) G_Data.PLC[cProcFCShim].Min1 = (double)(int.Parse(s[1]) * 0.001d);
            s = rcvData[12].Split(':');
            if (s[1].All(char.IsNumber)) G_Data.PLC[cProcFCShim].Max1 = (double)(int.Parse(s[1]) * 0.001d);

            s = rcvData[12].Split(':');
            if (s[1].All(char.IsNumber)) G_Data.PLC[cProcFCShim].Value2 = (double)(int.Parse(s[1]) * 0.001d);
            s = rcvData[12].Split(':');
            if (s[1].All(char.IsNumber)) G_Data.PLC[cProcFCShim].sMaster2 = (int.Parse(s[1]) * 0.001d).ToString("0.000");
            s = rcvData[12].Split(':');
            if (s[1].All(char.IsNumber)) G_Data.PLC[cProcFCShim].sOffset2 = (int.Parse(s[1]) * 0.001d).ToString("0.000");
            s = rcvData[12].Split(':');
            if (s[1].All(char.IsNumber)) G_Data.PLC[cProcFCShim].sApplyOffset2 = (int.Parse(s[1]) * 0.001d).ToString("0.000");
            s = rcvData[12].Split(':');
            if (s[1].All(char.IsNumber)) G_Data.PLC[cProcFCShim].Min2 = (double)(int.Parse(s[1]) * 0.001d);
            s = rcvData[12].Split(':');
            if (s[1].All(char.IsNumber)) G_Data.PLC[cProcFCShim].Max2 = (double)(int.Parse(s[1]) * 0.001d);

            s = rcvData[15].Split(':');
            G_Data.PLC[cProcFCShim].sRFID = s[1].Trim().Trim('\0');

            #endregion

            if (G_Data.PLC[cProcFCShim].icmd != G_Data.PLC[cProcFCShim].iflag)
            {
                //Shim Value Display
                if (G_Data.PLC[cProcFCShim].icmd == 1)
                {                    
                    Task.Run(() => FindFrontShim());
                }
                else if (G_Data.PLC[cProcFCShim].icmd == 2)
                {                 
                    Task.Run(() => uC_Home1.uC_Measure.ShowShimChk(G_Data.PLC[cProcFCShim], G_Data.PLC[cProcFCShim].Value1));
                }             
                else if (G_Data.PLC[cProcFCShim].icmd == 0)
                {
                    //Clear
                    Task.Run(() => uC_Home1.uC_Measure.ClearShimG4Text());
                }
                G_Data.PLC[cProcFCShim].iflag = G_Data.PLC[cProcFCShim].icmd;
            }
        }
        private void IMCaseProcess(string[] rcvData)
        {
            //Im Case Datasave & IMShim Calcu
            //Shim Process
        }
        private int[] GetPLCIndex(string PLCName, string BlockNum)
        {
            int[] iReturn = new int[2];

            try
            {
                dtView_PLC.Sort = "PLCSection,BlockNum";
                string[] s = new string[2];
                s[0] = PLCName;
                s[1] = BlockNum;
                int iFindindex = -1;
                //int iFindindex = dtView_PLC.Find(s);
                for (int r = 0; r < dtView_PLC.Table.Rows.Count; r++)
                {
                    if (PLCName == dtView_PLC[r]["PLCName"].ToString())
                    {
                        if (BlockNum == dtView_PLC[r]["BlockNum"].ToString())
                        {
                            iFindindex = r;
                            break;
                        }
                    }
                }
                iReturn[0] = iFindindex;
                iReturn[1] = (int)dtView_PLC[iFindindex]["BlockIndex"];

            }
            catch (Exception ex)
            {
                StackTrace trace = new StackTrace(ex, true);
                StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                int lineNumber = stackFrame.GetFileLineNumber();

                ErrorLog(($"({lineNumber}) : {ex.ToString()}"));
            }

            return iReturn;
        }

        public void WritePlcData(string plcKey, string PLCAddress, string writeData, PlcEnetTask.DataType plcSendType, bool firstIn = false)
        {
            MainPLC[plcKey].WriteData(PLCAddress, writeData, plcSendType, firstIn);
            ProcessLog($"[Write PLC](Type:{plcSendType}) : {PLCAddress} - {writeData}");
        }
        #endregion

        #region ############ 프로그램 종료 ##############

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("프로그램을 종료 하시겠습니까?", "프로그램 종료", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                Exit_Main();
            }
        }
        public async void Exit_Main()
        {
            this.Visible = false;
            frmWaiting waiting = new frmWaiting();

            if (!Share.CheckOpened(waiting.Name))
            {
                waiting.Show();
                waiting.Focus();
                waiting.TopMost = true;
                waiting.Text = "Excuting Exit...";
            }

            Task exitTask = Task.Run(() => ExitAsync());

            await exitTask;

            waiting.Close();
            waiting.Dispose();
            waiting = null;

            Application.Exit();
        }

        private async Task ExitAsync()
        {
            await Task.Run(async () =>
            {
                timer.Stop();
                gk_TsCancel.Cancel();
                gb_ExitFlag = true;

                connSql.Close();
                connSql.Dispose();

                await Task.Delay(300);

                gk_TsCancel = null;

                PLCDispose();

                if (_bSavelog)
                {
                    Log Processlog = new Log("Process_", null);
                    Processlog.Write(UC_LogView.rcvProcess.Text);
                    Processlog = null;
                }

                Log Errolog = new Log("Error_", null);
                Errolog.Write(UC_LogView.rcvError.Text);
                Errolog = null;

                await Task.Delay(1000);

            });
        }
        #endregion

        #region #################### MenuButton Click ####################

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            Button sendbtn = sender as Button;

            sendbtn.BackColor = Color.FromArgb(0, 122, 204);
            sendbtn.ForeColor = Color.Black;

            switch (sendbtn.Tag)
            {
                case "1": //Home Click
                    uC_Home1.Visible = true;
                    uC_Home1.BringToFront();

                    uC_DataView1.Visible = false;
                    uC_DataView1.SendToBack();
                    uC_PlcDataState1.Visible = false;
                    uC_PlcDataState1.SendToBack();
                    uC_LogView1.Visible = false;
                    uC_LogView1.SendToBack();
                    uC_PartSetting.Visible = false;
                    uC_PartSetting.SendToBack();
                    //ProcessLog(($" Home 버튼 클릭...."));

                    btnSerch.BackColor = Color.FromArgb(28, 28, 28);
                    btnSerch.ForeColor = Color.WhiteSmoke;
                    btnPlcData.BackColor = Color.FromArgb(28, 28, 28);
                    btnPlcData.ForeColor = Color.WhiteSmoke;
                    btnLog.BackColor = Color.FromArgb(28, 28, 28);
                    btnLog.ForeColor = Color.WhiteSmoke;
                    btnCodeSet.BackColor = Color.FromArgb(28, 28, 28);
                    btnCodeSet.ForeColor = Color.WhiteSmoke;
                    break;
                case "2": //DataSearch Click
                    uC_DataView1.Visible = true;
                    uC_DataView1.BringToFront();

                    uC_Home1.Visible = false;
                    uC_Home1.SendToBack();
                    uC_PlcDataState1.Visible = false;
                    uC_PlcDataState1.SendToBack();
                    uC_LogView1.Visible = false;
                    uC_LogView1.SendToBack();
                    uC_PartSetting.Visible = false;
                    uC_PartSetting.SendToBack();
                    //ProcessLog(($"데이터 조회 버튼 클릭...."));

                    btnHome.BackColor = Color.FromArgb(28, 28, 28);
                    btnHome.ForeColor = Color.WhiteSmoke;
                    btnPlcData.BackColor = Color.FromArgb(28, 28, 28);
                    btnPlcData.ForeColor = Color.WhiteSmoke;
                    btnLog.BackColor = Color.FromArgb(28, 28, 28);
                    btnLog.ForeColor = Color.WhiteSmoke;
                    btnCodeSet.BackColor = Color.FromArgb(28, 28, 28);
                    btnCodeSet.ForeColor = Color.WhiteSmoke;
                    break;
                case "3": //PlcData View Click
                    uC_PlcDataState1.Visible = true;
                    uC_PlcDataState1.BringToFront();

                    uC_DataView1.Visible = false;
                    uC_DataView1.SendToBack();
                    uC_Home1.Visible = false;
                    uC_Home1.SendToBack();
                    uC_LogView1.Visible = false;
                    uC_LogView1.SendToBack();
                    uC_PartSetting.Visible = false;
                    uC_PartSetting.SendToBack();
                    //ProcessLog(($"PLC Data 버튼 클릭...."));

                    btnHome.BackColor = Color.FromArgb(28, 28, 28);
                    btnHome.ForeColor = Color.WhiteSmoke;
                    btnSerch.BackColor = Color.FromArgb(28, 28, 28);
                    btnSerch.ForeColor = Color.WhiteSmoke;
                    btnLog.BackColor = Color.FromArgb(28, 28, 28);
                    btnLog.ForeColor = Color.WhiteSmoke;
                    btnCodeSet.BackColor = Color.FromArgb(28, 28, 28);
                    btnCodeSet.ForeColor = Color.WhiteSmoke;
                    break;
                case "4": //Log View Click
                    uC_LogView1.Visible = true;
                    uC_LogView1.BringToFront();

                    uC_DataView1.Visible = false;
                    uC_DataView1.SendToBack();
                    uC_Home1.Visible = false;
                    uC_Home1.SendToBack();
                    uC_PlcDataState1.Visible = false;
                    uC_PlcDataState1.SendToBack();
                    uC_PartSetting.Visible = false;
                    uC_PartSetting.SendToBack();
                    //ProcessLog(($"로그 버튼 클릭...."));

                    btnHome.BackColor = Color.FromArgb(28, 28, 28);
                    btnHome.ForeColor = Color.WhiteSmoke;
                    btnSerch.BackColor = Color.FromArgb(28, 28, 28);
                    btnSerch.ForeColor = Color.WhiteSmoke;
                    btnPlcData.BackColor = Color.FromArgb(28, 28, 28);
                    btnPlcData.ForeColor = Color.WhiteSmoke;
                    btnCodeSet.BackColor = Color.FromArgb(28, 28, 28);
                    btnCodeSet.ForeColor = Color.WhiteSmoke;

                    UC_LogView.Logview();
                    break;
                case "5": //Part Setting View Click
                    uC_PartSetting.Visible = true;
                    uC_PartSetting.BringToFront();

                    uC_DataView1.Visible = false;
                    uC_DataView1.SendToBack();
                    uC_Home1.Visible = false;
                    uC_Home1.SendToBack();
                    uC_PlcDataState1.Visible = false;
                    uC_PlcDataState1.SendToBack();
                    uC_LogView1.Visible = false;
                    uC_LogView1.SendToBack();
                    //ProcessLog(($"로그 버튼 클릭...."));

                    btnHome.BackColor = Color.FromArgb(28, 28, 28);
                    btnHome.ForeColor = Color.WhiteSmoke;
                    btnSerch.BackColor = Color.FromArgb(28, 28, 28);
                    btnSerch.ForeColor = Color.WhiteSmoke;
                    btnPlcData.BackColor = Color.FromArgb(28, 28, 28);
                    btnPlcData.ForeColor = Color.WhiteSmoke;
                    btnLog.BackColor = Color.FromArgb(28, 28, 28);
                    btnLog.ForeColor = Color.WhiteSmoke;
                    break;
                default:
                    break;
            }

        }
        #endregion

        public void ProcessLog(string msg, bool homewrite = false)
        {
            Task.Run(() => UC_LogView.ProcessLog($"{Share.GetNow_ms()} : {msg}"));
            if (homewrite) Task.Run(() => uC_Home1.uC_Measure.Noticeview($"{msg}"));
        }
        public void ErrorLog(string msg)
        {
            Task.Run(() => UC_LogView.ErrorLog($"{Share.GetNow_ms()} : {msg}"));
        }
        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            btnSetting.Visible = !btnSetting.Visible;
        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (gb_ExitFlag) timer.Stop();

            BeginInvoke((Action)(() =>
            {
                try
                {
                    ToolBarDate.Text = DateTime.Now.ToLongDateString();
                    ToolBarTime.Text = DateTime.Now.ToString("T");

                    foreach (var item in MainPLC)
                    {
                        if (item.Value.lblPLCState.ForeColor == Color.Red)
                        {
                            lbl_PlcReady.Image = IMG_Close;
                            lbl_PlcReady.Text = "PLC OFF";
                            break;
                        }
                        else
                        {
                            lbl_PlcReady.Image = IMG_ON;
                            lbl_PlcReady.Text = "PLC ON";
                        }

                    }
                }
                catch { }
            }));
        }

    }
}
