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
    public partial class UC_LogView : UserControl
    {
        public static TextBox rcvProcess;
        private static DateTime dDate_Process = DateTime.Now.Date;
        private static DateTime dPreDate_Process = DateTime.Now.Date;
        private static DateTime dDate_Error = DateTime.Now.Date;
        private static DateTime dPreDate_Error = DateTime.Now.Date;
        public static async Task ProcessLog(string msg)
        {
            await Task.Run(() =>
            {
                dPreDate_Process = DateTime.Now.Date;
                if (dDate_Process != dPreDate_Process)
                {
                    dDate_Process = dPreDate_Process;
                    Log Processlog = new Log("Process_", null);
                    Processlog.Write(rcvProcess.Text);
                    Processlog = null;
                    rcvProcess.Clear();
                }
                //_processlog.AppendLine(msg);
                rcvProcess?.AppendText($"{msg}{Environment.NewLine}");
                rcvProcess.MultiTextBoxScrollEnd();
            });
        }
        public static TextBox rcvError;
        public static async Task ErrorLog(string msg)
        {
            await Task.Run(() =>
            {
                dPreDate_Error = DateTime.Now.Date;
                if (dDate_Error != dPreDate_Error)
                {
                    dDate_Error = dPreDate_Error;
                    Log Errolog = new Log("Error_", null);
                    Errolog.Write(rcvError.Text);
                    Errolog = null;
                    rcvError.Clear();
                }

                rcvError?.AppendText($"{msg}{Environment.NewLine}");
                rcvError.MultiTextBoxScrollEnd();
            });
        }
        public UC_LogView()
        {
            InitializeComponent();
        }
        private void UC_LogView_Load(object sender, EventArgs e)
        {
            rcvProcess = txtProcessLog;
            rcvError = txtErrorLog;
        }
        public static void Logview()
        {
            rcvProcess.MultiTextBoxScrollEnd();
            rcvError.MultiTextBoxScrollEnd();
        }
    }
}
