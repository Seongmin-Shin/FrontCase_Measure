using SmLibrary.Tools;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FrontMeasure
{
    public partial class UC_PartSetting : UserControl
    {
        private IinterRef I_Part = null;
        public UC_PartSetting(IinterRef frm)
        {
            InitializeComponent();
            I_Part = frm;
        }

        private void UC_PartSetting_Load(object sender, EventArgs e)
        {
            DGVPart.DoubleBuffered(true);
            DGVPart.Font = new Font("현대하모니 L", 20f, FontStyle.Regular, GraphicsUnit.Point, Convert.ToByte(129));

            using (GEN2_MEASUREDBEntities db = new GEN2_MEASUREDBEntities())
            {
                DGVPart.DataSource = db.TB_FrontSetting.ToList();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearText();
        }
        private void ClearText()
        {
            txtPartName.Text = string.Empty;
            txtAlcCode.Text = string.Empty;
            numStandDis.Value = 0;

            num_G1_Offset.Value = 0;
            num_G1_Min.Value = 0;
            num_G1_Max.Value = 0;
            num_G1_Range.Value = 0;

            num_G2_Offset.Value = 0;
            num_G2_Min.Value = 0;
            num_G2_Max.Value = 0;
            num_G2_Range.Value = 0;

            num_G4_Offset.Value = 0;
            num_G4_Min.Value = 0;
            num_G4_Max.Value = 0;
            num_G4_Range.Value = 0;
        }
        private void DGView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            InfoSetting();
        }
        private void InfoSetting()
        {
            try
            {
                string ID = DGVPart.SelectedRows[0].Cells[0].Value.ToString();
                using (GEN2_MEASUREDBEntities db = new GEN2_MEASUREDBEntities())
                {
                    TB_FrontSetting partcode = db.TB_FrontSetting.Find(ID);
                    if (partcode != null)
                    {
                        txtAlcCode.Text = partcode.ALC_Code;
                        txtPartName.Text = partcode.Part_Name;
                        numStandDis.Value = Convert.ToDecimal(partcode.StandardVal);                      

                        num_G4_Offset.Value = Convert.ToDecimal(partcode.Gain_G4);
                        num_G4_Min.Value = Convert.ToDecimal(partcode.Shim_G4_Min);
                        num_G4_Max.Value = Convert.ToDecimal(partcode.Shim_G4_Max);
                        num_G4_Range.Value = Convert.ToDecimal(partcode.Shim_G4_Range);
                    }
                }
            }
            catch (Exception ex)
            {
                StackTrace trace = new StackTrace(ex, true);
                StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                int lineNumber = stackFrame.GetFileLineNumber();

                I_Part.ErrorLog($"{Share.GetNow_ms()} ({lineNumber}) : {ex.ToString()}");
            }

        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAlcCode.Text.Length != 4)
                {
                    MessageBox.Show("ALC CODE 문자 길이는 4입니다..", "ALC Code 오류", MessageBoxButtons.OK);
                    return;
                }
                using (GEN2_MEASUREDBEntities db = new GEN2_MEASUREDBEntities())
                {
                    TB_FrontSetting partcode = new TB_FrontSetting();
                    partcode.ALC_Code = txtAlcCode.Text;
                    partcode.Part_Name = txtPartName.Text;
                    partcode.StandardVal = Convert.ToDouble(numStandDis.Value);
                    
                    partcode.Gain_G4 = Convert.ToDouble(num_G4_Offset.Value);
                    partcode.Shim_G4_Min = Convert.ToDouble(num_G4_Min.Value);
                    partcode.Shim_G4_Max = Convert.ToDouble(num_G4_Max.Value);
                    partcode.Shim_G4_Range = Convert.ToDouble(num_G4_Range.Value);

                    db.TB_FrontSetting.Add(partcode);

                    int ir = await db.SaveChangesAsync();
                    lblResult.Text = ir.ToString();

                    DGVPart.DataSource = db.TB_FrontSetting.ToList();
                    ClearText();
                }
            }
            catch (Exception ex)
            {
                StackTrace trace = new StackTrace(ex, true);
                StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                int lineNumber = stackFrame.GetFileLineNumber();

                I_Part.ErrorLog($"{Share.GetNow_ms()} ({lineNumber}) : {ex.ToString()}");
            }


        }

        private async void btnFix_Click(object sender, EventArgs e)
        {
            try
            {
                int rowindex = DGVPart.SelectedRows[0].Index;
                string ID = DGVPart.SelectedRows[0].Cells[0].Value.ToString();
                if (txtAlcCode.Text != ID)
                {
                    MessageBox.Show("ALC CODE는 수정 할 수 없습니다. \r\n(추가 및 기존ALC삭제로 변경 가능)", "ALC Code 오류", MessageBoxButtons.OK);
                    return;
                }
                using (GEN2_MEASUREDBEntities db = new GEN2_MEASUREDBEntities())
                {
                    TB_FrontSetting partcode = db.TB_FrontSetting.Find(ID);
                    if (partcode != null)
                    {
                        txtAlcCode.Text = partcode.ALC_Code;
                        partcode.Part_Name = txtPartName.Text;
                        partcode.StandardVal = Convert.ToDouble(numStandDis.Value);

                        partcode.Gain_G4 = Convert.ToDouble(num_G4_Offset.Value);
                        partcode.Shim_G4_Min = Convert.ToDouble(num_G4_Min.Value);
                        partcode.Shim_G4_Max = Convert.ToDouble(num_G4_Max.Value);
                        partcode.Shim_G4_Range = Convert.ToDouble(num_G4_Range.Value);

                        int ir = await db.SaveChangesAsync();
                        lblResult.Text = ir.ToString();

                        DGVPart.DataSource = db.TB_FrontSetting.ToList();

                        if (partcode.ALC_Code == frmMain.G_Data._SETTING.ALC_Code)
                        {
                            frmMain.G_Data._SETTING = partcode;
                        }
                    }
                    DGVPart.Rows[rowindex].Selected = true;
                }
            }
            catch (Exception ex)
            {
                StackTrace trace = new StackTrace(ex, true);
                StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                int lineNumber = stackFrame.GetFileLineNumber();

                I_Part.ErrorLog($"{Share.GetNow_ms()} ({lineNumber}) : {ex.ToString()}");
            }

        }

        private async void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGVPart.RowCount < 1)
                {
                    MessageBox.Show("삭제할 항목이 없습니다.", "삭제오류", MessageBoxButtons.OK);
                    return;
                }
                string ID = DGVPart.SelectedRows[0].Cells[0].Value.ToString();
                using (GEN2_MEASUREDBEntities db = new GEN2_MEASUREDBEntities())
                {
                    TB_FrontSetting partcode = db.TB_FrontSetting.Find(ID);
                    if (partcode != null)
                    {
                        db.TB_FrontSetting.Remove(partcode);

                        int ir = await db.SaveChangesAsync();
                        lblResult.Text = ir.ToString();

                        DGVPart.DataSource = db.TB_FrontSetting.ToList();
                        ClearText();
                    }

                }
            }
            catch (Exception ex)
            {
                StackTrace trace = new StackTrace(ex, true);
                StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                int lineNumber = stackFrame.GetFileLineNumber();

                I_Part.ErrorLog($"{Share.GetNow_ms()} ({lineNumber}) : {ex.ToString()}");
            }

        }
    }
}
