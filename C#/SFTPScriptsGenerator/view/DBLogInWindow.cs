using SFTPScriptsGenerator.view;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FIS.RDP.BPPS.SFTPScriptsGenerator
{
    public partial class DBLoginWindow : Form
    {
        private TransparentPictureBox spinningControl;

        /// <summary>
        /// Event Handler to notify controller to determine if its okay to launch PayeeInfoView window.
        /// </summary>
        public event EventHandler LaunchPayeeInfoScreen;

        private string _unitDbServer = string.Empty;
        private string _unitDbUser = string.Empty;
        private string _unitDbPwd = string.Empty;
        private string _sysDbServer = string.Empty;
        private string _sysDbUser = string.Empty;
        private string _sysDbPwd = string.Empty;
        /// <summary>
        private string _rdyDbServer = string.Empty;
        private string _rdyDbUser = string.Empty;
        private string _rdyDbPwd = string.Empty;
        private string _prodDbServer = string.Empty;
        private string _prodDbUser = string.Empty;
        private string _prodDbPwd = string.Empty;
        /// Dialog return value
        /// </summary>
        public string ReturnValue { get; set; }

        public SecureString securePwd = new SecureString();

        public string DBServer
        {
            get => this.txtDatabase.Text.ToUpper();
            set => this.txtDatabase.Text = value;
        }

        public string DBUser
        {
            get => this.txtDBUser.Text.ToUpper();
            set => this.txtDBUser.Text = value;
        }

        public string DBPswd
        {
            get => this.txtDBPassword.Text;
            set => this.txtDBPassword.Text = value;
        }
        internal TransparentPictureBox SpinningControl { get => spinningControl; set => spinningControl = value; }

        /// <summary>
        /// 
        /// </summary>
        public DBLoginWindow()
        {
            InitializeComponent();
            GetConfigurationUsingSection();
            rdbUnitTest.Checked = true;
        }
        private void GetConfigurationUsingSection()
        {
            var unitDbSettings = SetDbSettings(ConfigurationManager.GetSection("UnitDbSettings") as NameValueCollection);
            var sysDbSettings = SetDbSettings(ConfigurationManager.GetSection("SysDbSettings") as NameValueCollection);
            var rdyDbSettings = SetDbSettings(ConfigurationManager.GetSection("RdyDbSettings") as NameValueCollection);
            var prodDbSettings = SetDbSettings(ConfigurationManager.GetSection("ProdDbSettings") as NameValueCollection);
            _unitDbServer = unitDbSettings[0];
            _unitDbUser = unitDbSettings[1];
            _unitDbPwd = unitDbSettings[2];
            _sysDbServer = sysDbSettings[0];
            _sysDbUser = sysDbSettings[1];
            _sysDbPwd = sysDbSettings[2];
            _rdyDbServer = rdyDbSettings[0];
            _rdyDbUser = rdyDbSettings[1];
            _rdyDbPwd = rdyDbSettings[2];
            _prodDbServer = prodDbSettings[0];
            _prodDbUser = prodDbSettings[1];
            _prodDbPwd = prodDbSettings[2];
        }
        private string[] SetDbSettings(NameValueCollection dbSettings)
        {
            string[] dbSetting = new string[3];
            if (dbSettings.Count > 0)
            {
                dbSetting[0] = dbSettings.GetValues(0)[0];
                dbSetting[1] = dbSettings.GetValues(1)[0];
                dbSetting[2] = dbSettings.GetValues(2)[0];
            }
            else
            {
                MessageBox.Show("Database Settings are not defined");
            }
            return dbSetting;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdbUnitTest_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbUnitTest.Checked)
            {
                txtDatabase.Text = _unitDbServer;
                txtDBUser.Text = _unitDbUser;
                txtDBPassword.Text = _unitDbPwd;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdbSystemTest_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSystemTest.Checked)
            {
                txtDatabase.Text = _sysDbServer;
                txtDBUser.Text = _sysDbUser;
                txtDBPassword.Text = _sysDbPwd;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdbReadiness_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbReadiness.Checked)
            {
                txtDatabase.Text = _rdyDbServer;
                txtDBUser.Text = _rdyDbUser;
                txtDBPassword.Text = _rdyDbPwd;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdbProduction_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbProduction.Checked)
            {
                txtDatabase.Text = _prodDbServer;
                txtDBUser.Text = _prodDbUser;
                txtDBPassword.Text = _prodDbPwd;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDatabase_TextChanged(object sender, EventArgs e)
        {

            if (rdbUnitTest.Checked)
            {
                _unitDbServer = txtDatabase.Text;
            }
            if (rdbSystemTest.Checked)
            {
                _sysDbServer = txtDatabase.Text;
            }
            if (rdbReadiness.Checked)
            {
                _rdyDbServer = txtDatabase.Text;
            }
            if (rdbProduction.Checked)
            {
                _prodDbServer = txtDatabase.Text;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDBUser_TextChanged(object sender, EventArgs e)
        {
            if (rdbUnitTest.Checked)
            {
                _unitDbUser = txtDBUser.Text;
            }
            if (rdbSystemTest.Checked)
            {
                _sysDbUser = txtDBUser.Text;
            }
            if (rdbReadiness.Checked)
            {
                _rdyDbUser = txtDBUser.Text;
            }
            if (rdbProduction.Checked)
            {
                _prodDbUser = txtDBUser.Text;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDBPassword_TextChanged(object sender, EventArgs e)
        {
            if (rdbUnitTest.Checked)
            {
                _unitDbPwd = txtDBPassword.Text;
            }
            if (rdbSystemTest.Checked)
            {
                _sysDbPwd = txtDBPassword.Text;
            }
            if (rdbReadiness.Checked)
            {
                _rdyDbPwd = txtDBPassword.Text;
            }
            if (rdbProduction.Checked)
            {
                _prodDbPwd = txtDBPassword.Text;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.ReturnValue = "Cancel";
            Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OK_Click(object sender, EventArgs e)
        {
            this.ReturnValue = "OK";

            if (ValidateMandatoryUserInput())
            {
                if (LaunchPayeeInfoScreen != null)
                {
                    lblWarnMessage.Hide();
                    //loadingPictureBox.Show();
                    //loadingPictureBox.Update();
                    LaunchPayeeInfoScreen(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal bool ValidateMandatoryUserInput()
        {
            bool retVal = true;

            if (string.IsNullOrEmpty(DBServer) 
                || string.IsNullOrWhiteSpace(DBServer) 
                || txtDatabase.Text.Trim() == ScriptCategory.ENTER_DBSERVER_MESSAGE)
            {
                retVal =  false;
            }

            if (string.IsNullOrEmpty(DBUser) || string.IsNullOrWhiteSpace(DBUser)
                || txtDBUser.Text.Trim() == ScriptCategory.ENTER_DBUSER_MESSAGE)
            {
                retVal = false;
            }

            if (string.IsNullOrEmpty(DBPswd) || string.IsNullOrWhiteSpace(DBPswd)
                || txtDBPassword.Text.Trim() == ScriptCategory.ENTER_PASSWORD_MESSAGE)
            {
                retVal = false;
            }

            if(!retVal)
            {
                lblWarnMessage.Text = "Please provide DB User Id and password. Also check if the DB Server Name is present in your TNSNames.ora file.";
                lblWarnMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblWarnMessage.Hide();
            }

            return retVal;
        }

        private void DBDialog_Load(object sender, EventArgs e)
        {
            SpinningControl = new TransparentPictureBox();
            SpinningControl.SizeMode = PictureBoxSizeMode.CenterImage; 
            SpinningControl.Enabled = false;
        }
    }
}
