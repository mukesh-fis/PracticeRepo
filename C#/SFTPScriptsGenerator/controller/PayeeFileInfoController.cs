using FIS.RDP.BPPS.SFTPScriptsGenerator.eventHandler;
using SFTPScriptsGenerator.Properties;
using System;
using System.IO;
using System.Windows.Forms;
using System.Globalization;
using System.Net;
using System.Collections.Generic;

namespace FIS.RDP.BPPS.SFTPScriptsGenerator
{
    public class PayeeFileInfoController
    {
        #region Fields
        private PayeeFileInfoView _form;
        private PayeeFileInfoDataService _dataservice;
        private DBLoginWindow _dbLogInWindow;
        #endregion

        #region Public Methods
        public PayeeFileInfoView Form { get => _form; set => _form = value; }
        public PayeeFileInfoDataService Dataservice { get => _dataservice; set => _dataservice = value; }
        public bool ScriptCreated { get; private set; }
        public DBLoginWindow DbLogInWindow { get => _dbLogInWindow; set => _dbLogInWindow = value; }

        public PayeeFileInfoController(PayeeFileInfoView form, PayeeFileInfoDataService dataservice, DBLoginWindow dbLogInWindow) 
        {
            Form = form;
            DbLogInWindow = dbLogInWindow;
            Form.ShowPayeeFileInfo += OnShowPayeeFileInfo;
            Form.CreateScriptClick += OnCreateScriptClick;
            Form.ShowSampleClick += OnShowSampleClick;
            Form.ValidateEntries += OnValidate;
            //Form.DestFileNameorPathChanged += OnDestFileNameorPathChanged;
            DbLogInWindow.LaunchPayeeInfoScreen += OnLaunchPayeeInfoScreen;
            Dataservice = dataservice;
        }

        private void OnDestFileNameorPathChanged(object sender, EventArgDerived args)
        {
            Form.DisableButtons();
        }

        private void OnLaunchPayeeInfoScreen(object sender, EventArgs e)
        {
            if (GetDBPreferences())
            {
                if (CreateDBConnection())
                {
                    DbLogInWindow.Hide();
                    Form.Show();
                    return;
                }
            }

        }

        #endregion

        #region Private Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnShowPayeeFileInfo(object sender, EventArgs e)
        {
                if (CreateDBConnection())
                {
                    //Form.HideTable();

                    var info = Dataservice.GetFilePushInfoForTPDT(_form.ThirdPtyDisbType);

                    if (info.Count == 0)
                    {
                        MessageBox.Show("Incorrect third_pty_disb_type.");
                        return;
                    }

                    Form.LstPayeeInfoOriginal = info;
                    Form.DrawTable();
                    Form.ShowTable();
                }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCreateScriptClick(object sender, EventArgDerived e)
        {
            try
            {
                //Get the updated information enetered by the user
                Form.ExportUpdatesToList();

                //get an appropriate instance based on the script type
                ScriptCreator sc = GetScriptCreator(e.Message);

                ScriptCreated = false;

                if (sc != null)
                {
                    if (sc.CheckIfOutputScriptAlreadyExists())
                    {
                        if (!OverwriteAlreadyExistingFile(ref sc))
                            return;
                    }

                    ScriptCreated = sc.WriteOutputScript();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
                throw;
            }
            finally
            {
                //if(ScriptCreated)
                    //MessageBox.Show(e.Message + " Created.");  
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnShowSampleClick(object sender, EventArgDerived args)
        {
            String ParsedName = ParseFileName(args.Message);
            string toShow = "Generated file name will look something similar to what is shown below:\n\n" + ParsedName;
            toShow += "\n\nYou may correct the format if this is not what you expect. ";
            toShow += "\n Please also check if the Destination path is what you expect.";

            if (!string.IsNullOrEmpty(ParsedName))
            {
                MessageBox.Show(toShow, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnValidate(object sender, EventArgDerived args)
        {
            switch(args.Message)
            {
                case ScriptCategory.VALIDATE_ALL_DEST_FILES:

                    List<string> destFileList = Form.GetDestFileList();
                    bool validationFailed = false;
                    string incorrectFilenames = string.Empty;
                    Form.ValidationSuccessful = true;
                    foreach (var item in destFileList)
                    {
                        String ParsedName = ParseFileName(item, ScriptCategory.VALIDATE_ALL_DEST_FILES);
                        if (string.IsNullOrEmpty(ParsedName))
                        {
                            incorrectFilenames += item + "\n";
                            validationFailed = true;
                        }
                    }

                    if (validationFailed)
                    {
                        string toShow = "Invalid Format detected. Please correct these files:\n\n" + incorrectFilenames;
                        MessageBox.Show(toShow, "FormatError", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Form.ValidationSuccessful = false;
                        return;
                    }
                    break;
            }
            

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="payeeID"></param>
        /// <returns></returns>
        public string ParseFileName(string input,
                                    string validationType = "",
                                    string payeeID = "123" 
                                    )
        {
            {
                string output = "";
                try
                {
                    string[] stringParts = input.Split('#');

                    bool parameterFound = false;
                    foreach (string stringPart in stringParts)
                    {
                        if (stringPart == "")
                        {
                            if (parameterFound)
                            {
                                output += "#";
                            }
                            else
                            {
                                parameterFound = true;
                            }
                        }
                        else if (parameterFound)
                        {
                            // Parameter Could have two parts separated by pipe (|)
                            // First Part tells the name of the parameter
                            // Second Part tells the format to be used for the given parameter
                            string[] strPart = stringPart.Split('|');
                            switch (strPart[0].ToUpper())
                            {
                                case "HOSTNAME":
                                    output += Dns.GetHostName();
                                    parameterFound = false;
                                    break;

                                case "PAYEE_ID":
                                    output += payeeID;
                                    parameterFound = false;
                                    break;

                                case "DATE":
                                    string dateFormat = string.Empty;
                                    if (strPart.Length == 2)
                                    {
                                        dateFormat = strPart[1];
                                    }
                                    if (String.IsNullOrEmpty(dateFormat) || (strPart.Length != 2))
                                    {
                                        throw new InvalidOperationException(String.Format("Invalid Date format[{0}] passed in file name\n\n [{1}] ", stringPart, input));
                                    }
                                    output += DateTime.Now.ToString(dateFormat);
                                    parameterFound = false;
                                    break;

                                case "JULIAN_DAY":
                                    JulianCalendar calendar = new JulianCalendar();
                                    DateTime dateInJulian = calendar.ToDateTime(DateTime.Today.Year,
                                                                                DateTime.Today.Month,
                                                                                DateTime.Today.Day,
                                                                                DateTime.Today.Hour,
                                                                                DateTime.Today.Minute,
                                                                                DateTime.Today.Second,
                                                                                DateTime.Today.Millisecond);

                                    int julianDay = calendar.GetDayOfYear(dateInJulian);
                                    output += Convert.ToString(julianDay);
                                    parameterFound = false;
                                    break;

                                default:
                                    output += "#" + stringPart;
                                    break;
                            }
                        }
                        else
                        {
                            output += stringPart;
                            parameterFound = true;
                        }
                    }
                }
                catch (Exception)
                {
                    if (validationType != ScriptCategory.VALIDATE_ALL_DEST_FILES)
                    {
                        string toShow = "Invalid Format detected in filename - \n" + input + " \n\nPlease provide correct format. ";
                        MessageBox.Show(toShow, "FormatError", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return "";
                }
                return output;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sc"></param>
        private bool OverwriteAlreadyExistingFile(ref ScriptCreator sc)
        {

            if (Form.OverWriteIfFileAlreadyExists)
            {
                File.Delete(sc.CszGeneratedScriptNameWithPath);
                return true;
            }
            else
            { 
                Warning2Buttons frm = new Warning2Buttons();

                frm.ShowDialog();

                //Check the return value of the above dialog
                if (frm.ReturnValue == "Cancel")
                    return false;
                else
                {
                    File.Delete(sc.CszGeneratedScriptNameWithPath);
                    return true;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private ScriptCreator GetScriptCreator(string scriptCategory)
        {
            ScriptCreator sc = null;

            switch (scriptCategory)
            {
                case ScriptCategory.SFTP_SCRIPT_TYPE:
                    sc = new SftpScriptCreator();
                    sc.Initialize(
                                  Resources.Switch_To_MOVEIt,
                                  Form.CszDMLFolderPath, 
                                  ScriptCategory.SFTP_SCRIPT_TEMPLATE_NAME + "_" + Form.ThirdPtyDisbType + ScriptCategory.SCRIPT_TEMPLATE_NAME_EXT,
                                  Form.LstPayeeInfoOriginal,
                                  Form.LstPayeeInfoUpdated
                                  );
                    break;

                case ScriptCategory.FTP_SCRIPT_TYPE:
                    sc = new FtpScriptCreator();
                    sc.Initialize(
                                  Resources.Back_to_Momentum,
                                  Form.CszDMLFolderPath,
                                  ScriptCategory.FTP_SCRIPT_TEMPLATE_NAME + "_" + Form.ThirdPtyDisbType + ScriptCategory.SCRIPT_TEMPLATE_NAME_EXT,
                                  Form.LstPayeeInfoOriginal,
                                  Form.LstPayeeInfoUpdated
                                  );
                    break;

                case ScriptCategory.SFTP_VALIDATION_SCRIPT_TYPE:
                    sc = new SftpValidationScriptCreator();
                    sc.Initialize(
                                  Resources.Switch_To_MOVEIt_validation,
                                  Form.CszDMLFolderPath,
                                  ScriptCategory.SFTP_VALIDATION_SCRIPT_TEMPLATE_NAME + "_" + Form.ThirdPtyDisbType + ScriptCategory.SCRIPT_TEMPLATE_NAME_EXT,
                                  Form.LstPayeeInfoOriginal,
                                  Form.LstPayeeInfoUpdated
                                  );
                    break;

                case ScriptCategory.FTP_VALIDATION_SCRIPT_TYPE:
                    sc = new FtpValidationScriptCreator();
                    sc.Initialize(
                                  Resources.Back_to_Momentum_validation,
                                  Form.CszDMLFolderPath,
                                  ScriptCategory.FTP_VALIDATION_SCRIPT_TEMPLATE_NAME + "_" + Form.ThirdPtyDisbType + ScriptCategory.SCRIPT_TEMPLATE_NAME_EXT,
                                  Form.LstPayeeInfoOriginal,
                                  Form.LstPayeeInfoUpdated
                                  );
                    break;
            }
            return sc;
        }

        /// <summary>
        /// Ask the user to select the correct DB instance
        /// </summary>
        private bool GetDBPreferences()
        {
            Dataservice.DbServer = DbLogInWindow.DBServer;

            Dataservice.DbUser = DbLogInWindow.DBUser;

            Dataservice.DbPassword = DbLogInWindow.DBPswd;      

            return true;
        }

        /// <summary>
        /// Create DB Connection
        /// </summary>
        /// <returns></returns>
        private bool CreateDBConnection()
        {
            try
            {
                // Set cursor as App Starting
                Cursor.Current = Cursors.AppStarting;

                Dataservice.Connect();

                // Set cursor as default arrow
                Cursor.Current = Cursors.Default;
                
            }
            catch (Exception ex)
            {
                // Set cursor as default arrow
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Error occurred while connecting the data base. Exception" + ex.Message, "PayeeFileInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        #endregion
    }
}
