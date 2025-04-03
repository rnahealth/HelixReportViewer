using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportAppServer.ClientDoc;
using CrystalDecisions.ReportAppServer.ReportDefModel;

namespace HelixReportViewer
{    
    public partial class MainForm : Form
    {
        public static string dbName = string.Empty;

        List<TreeViewItem> treeViewList = new List<TreeViewItem>();

        public MainForm(string[] args)
        {
            InitializeComponent();

            if (args.Length == 3)
            {
                textBoxDatabase.Text = args[0].Trim();
                textBoxUserName.Text = args[1].Trim();
                textBoxPassword.Text = args[2].Trim();
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Empty;
                dbName = textBoxDatabase.Text.Trim();

                if (authenticateUser(textBoxDatabase.Text.Trim(), textBoxUserName.Text.Trim(), textBoxPassword.Text.Trim()))
                {
                    treeViewReports.Nodes.Clear();

                    Query = "SELECT CG.GROUP_ID, GROUP_NAME, CM.REPORT_ID, REPORT_NAME, REPORT_PATH " +
                            " FROM  CR_REPORTS CR " +
                            " INNER JOIN CR_MENU CM ON CR.REPORT_ID = CM.REPORT_ID " +
                            " INNER JOIN CR_GROUPS CG ON CM.GROUP_ID = CG.GROUP_ID " +
                            " INNER JOIN CR_ACCESSRIGHTS_GROUP CAR ON CAR.GROUP_ID = CG.GROUP_ID " +
                        " WHERE REPORT_ACTIVE = 'Y' AND PRIVILEGE = '1' AND CAR.USER_ID = '" + textBoxUserName.Text.Trim().ToUpper() + "'" +
                        " ORDER BY CM.GROUP_ID, MENU_ORDER ";

                    var CR_REPORTS = OracleDataAccesslayer.GetDataTable(Query).AsEnumerable();

                    string lastGroupID = string.Empty;
                    int lastParentID = -1;

                    foreach (var r in CR_REPORTS)
                    {
                        string groupId = r["GROUP_ID"].ToString().Trim();
                        string groupName = r["GROUP_NAME"].ToString().Trim();
                        string reportName = r["REPORT_NAME"].ToString().Trim();
                        string reportPath = r["REPORT_PATH"].ToString().Trim();

                        if (lastGroupID != groupId)
                        {
                            lastParentID++;
                            TreeNode parentNode = new TreeNode();
                            parentNode.Text = groupName;
                            treeViewReports.Nodes.Add(parentNode);
                            lastGroupID = groupId;
                        }

                        TreeNode childNode = new TreeNode();
                        childNode.Text = reportName;
                        childNode.Tag = reportPath;

                        treeViewReports.Nodes[lastParentID].Nodes.Add(childNode);
                    }

                    treeViewReports.ExpandAll();
                }
                else
                {
                    MessageBox.Show("Invalid login information.");
                }
            }
            catch (Exception ex)
            {
                Logger.Write_In_Log(ex);
                MessageBox.Show("Error.  Check error log for details.");
            }
        }

        private static bool authenticateUser(string dbName, string name, string pswd)
        {
            try
            {
                string password = "";
                string hexpass = "";
                string password2 = "";
                string addInfoTime = "";
                name = name.Trim().ToUpper();
                pswd = pswd.PadRight(8);

                string Query = "SELECT RAWTOHEX(PASSWD) AS HEXPASS, PASSWD, SUBSTR(ADDINFO, 11, 8) ADDINFOTIME FROM EMPL WHERE LOGIN = " +
                    "RPAD('" + name + "',8,chr(0))";

                var EMPL = OracleDataAccesslayer.GetDataTable(Query);

                if (EMPL != null && EMPL.Rows.Count > 0)
                {
                    password = EMPL.Rows[0]["PASSWD"].ToString();
                    hexpass = EMPL.Rows[0]["HEXPASS"].ToString();
                    addInfoTime = EMPL.Rows[0]["ADDINFOTIME"].ToString();
                }
                else
                {
                    return false;
                }

                string encrypted = "";
                string decrypted = "";

                for (int i = 0; i < 8; i++)
                {
                    if (i < password.Length)
                        decrypted += (char)(password[i] - (addInfoTime[i] & 0x0f));
                    else
                        decrypted += ' ';

                    char ch;
                    int value = int.Parse(hexpass.Substring(i * 2, 2), System.Globalization.NumberStyles.HexNumber);
                    string stringValue = Char.ConvertFromUtf32(value);
                    char charValue = (char)value;
                    password2 += charValue;

                    if (i >= pswd.Length)
                    {
                        ch = ' ';
                    }
                    else
                    {
                        ch = Convert.ToChar(pswd.Substring(i, 1));
                    }

                    int ascii = Convert.ToInt16(ch);
                    int key = Convert.ToInt16(Convert.ToChar(addInfoTime.Substring(i, 1)));

                    char encryptedChar = Convert.ToChar(ascii + key - 48);
                    encrypted += encryptedChar.ToString();
                }

                if (encrypted.ToUpper() == password2.ToUpper() || password2.Replace('\0',' ').ToUpper() == encrypted.ToUpper() || decrypted.Trim() == pswd.Trim())
                {
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                Logger.Write_In_Log(e);
                MessageBox.Show("Error Authenticating User.");
                return false;
            }
        }

        private void treeViewReports_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Node.Tag != null && e.Node.Tag.ToString() != "")
                {
                    LoadReport(e.Node.Tag.ToString());
                    
                }
            }
            catch (Exception ex)
            {
                Logger.Write_In_Log(ex);
                MessageBox.Show("Error loading report.  Check error log for details.");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (textBoxPassword.Text.Length != 0 && textBoxUserName.Text.Length != 0 && textBoxDatabase.Text.Length != 0)
            {
                buttonLogin.PerformClick();
            }
        }

        private void LoadReport(string reportName)
        {
            try
            {
                string reportPath = @"N:\Reports\" + reportName;

                if (File.Exists(reportPath))
                {
                    CrystalDecisions.CrystalReports.Engine.ReportDocument rd = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    ConnectionInfo connection = new ConnectionInfo();
                    //       TableLogOnInfo tableLogin = new TableLogOnInfo();
                    string username = "rnapgm";
                    string password = "rna_rna_202";

                    rd.Load(reportPath);
                    //    report.SetDatabaseLogon(userName, password, "", dbName);
                    connection = rd.Database.Tables[0].LogOnInfo.ConnectionInfo;
                    connection.ServerName = dbName;
                    connection.DatabaseName = dbName;
                    connection.UserID = username;
                    connection.Password = password;
                    connection.IntegratedSecurity = false;

                    //   report.DataSourceConnections[0] = "rnauser";

                    foreach (Table table in rd.Database.Tables)
                    {
                        TableLogOnInfo tableLogin = table.LogOnInfo;
                        tableLogin.ConnectionInfo = connection;
                        table.ApplyLogOnInfo(tableLogin);

                        if (table.TestConnectivity() == false)
                        {
                            MessageBox.Show("Logon failed - " + table.Name);
                        }
                    }

                    if (radioButtonLandscape.Checked || radioButtonPortrait.Checked)
                    {

                        ISCDReportClientDocument rcd = rd.ReportClientDocument;
                        CrystalDecisions.ReportAppServer.ReportDefModel.PrintOptions opt = rcd.PrintOutputController.GetPrintOptions().Clone();

                        int width = opt.PageContentWidth + opt.PageMargins.Left + opt.PageMargins.Right;
                        int height = opt.PageContentHeight + opt.PageMargins.Top + opt.PageMargins.Bottom;
                        width = 12240;
                        height = 15840;


                        //       MessageBox.Show("Height: " + height.ToString() + ", Width: " + width.ToString());

                        rcd.PrintOutputController.ModifyPrinterName("");

                        if (radioButtonPortrait.Checked)
                        {
                            rcd.PrintOutputController.ModifyPageMargins(360, 360, 360, 360);
                            rcd.PrintOutputController.ModifyUserPaperSize(height, width);
                            rcd.PrintOutputController.ModifyPaperOrientation(CrPaperOrientationEnum.crPaperOrientationPortrait);
                        }
                        else
                        {
                            rcd.PrintOutputController.ModifyPageMargins(360, 360, 360, 360);
                            rcd.PrintOutputController.ModifyUserPaperSize(width, height);
                            rcd.PrintOutputController.ModifyPaperOrientation(CrPaperOrientationEnum.crPaperOrientationLandscape);
                        }
                    }

                    crystalReportViewer1.ReportSource = rd;
                }
                else
                {
                    MessageBox.Show(reportPath + " file missing.");
                }
            }
            catch (Exception ex)
            {
                Logger.Write_In_Log(ex);
                MessageBox.Show("Error loading report.  Check error log for details.");
            }
        }

        private void reloadReport()
        {
            if (treeViewReports.SelectedNode != null)
            {
                string reportName = treeViewReports.SelectedNode.Tag.ToString();
                if (reportName.ToUpper().Contains(".RPT"))
                {
                    DialogResult dialogResult = MessageBox.Show("Refresh current report?", "Optimize Display Changed", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        LoadReport(reportName);
                    }
                }
            }
        }

        private void radioButtonNoOptimize_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNoOptimize.Checked)
            {
                reloadReport();
            }
        }

        private void radioButtonPortrait_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPortrait.Checked)
            {
                reloadReport();
            }
        }

        private void radioButtonLandscape_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLandscape.Checked)
            {
                reloadReport();
            }
        }
    }
}
