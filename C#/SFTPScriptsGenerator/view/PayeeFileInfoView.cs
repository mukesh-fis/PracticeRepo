using FIS.RDP.BPPS.SFTPScriptsGenerator.eventHandler;
using SFTPScriptsGenerator.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FIS.RDP.BPPS.SFTPScriptsGenerator
{
    public partial class PayeeFileInfoView : Form
    {
        #region Private Data Members

        private const int ResultSetColCount = 7;

        private const int ControlDefaultWidth = 196;

        private const int ControlDefaultHeight = 20;

        private int columnCount;

        private int rowCount;

        private List<PayeeFileInfo> lstPayeeInfo;

        private List<PayeeFileInfo> lstPayeeInfoUpdatedForSFTP;

        private string cszDMLFolderPath;

        private TransparentPictureBox spinningControl;

        private bool validationSuccessful;

        #endregion

        #region Public Methods and Properties

        internal TransparentPictureBox SpinningControl { get => spinningControl; set => spinningControl = value; }

        /// <summary>
        /// Event Handler for GetPayeeFilePushInfo button
        /// </summary>
        public event EventHandler ShowPayeeFileInfo;

        /// <summary>
        /// Event Handler for CreateSFTPScript button
        /// </summary>
        public event MyClickEventHandler CreateScriptClick;

        /// <summary>
        /// Create a delegate for event handler with a string message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// 
        public delegate void MyClickEventHandler(object sender, EventArgDerived args);

        /// <summary>
        /// Event Handler for CreateSFTPScript button
        /// </summary>
        public event MyClickEventHandler ShowSampleClick;

        /// <summary>
        /// Event Handler for CreateSFTPScript button
        /// </summary>
        public event MyClickEventHandler ValidateEntries;

        /// <summary>
        /// Create a delegate for event handler with a string message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// 
        public delegate void ValidateClickEventHandler(object sender, EventArgDerived args);


        /// <summary>
        /// 
        /// </summary>
        public string ThirdPtyDisbType
        {
            get => richTextBoxEnterDisbType.Text.ToUpper();
            set => richTextBoxEnterDisbType.Text = value;
        }

        public bool OverWriteIfFileAlreadyExists
        {
            get => checkBoxOverwrite.Checked;
        }
        /// <summary>
        /// 
        /// </summary>
        public List<PayeeFileInfo> LstPayeeInfoOriginal { get => lstPayeeInfo; set => lstPayeeInfo = value; }

        /// <summary>
        /// 
        /// </summary>
        public List<PayeeFileInfo> LstPayeeInfoUpdated { get => lstPayeeInfoUpdatedForSFTP; set => lstPayeeInfoUpdatedForSFTP = value; }

        /// <summary>
        /// 
        /// </summary>
        public int ColumnCount { get => columnCount; set => columnCount = value; }


        /// <summary>
        /// 
        /// </summary>
        public int RowCount { get => rowCount; set => rowCount = value; }

        /// <summary>
        /// 
        /// </summary>
        public string CszDMLFolderPath { get => cszDMLFolderPath; set => cszDMLFolderPath = value; }
        
        /// <summary>
        /// 
        /// </summary>
        public bool ValidationSuccessful { get => validationSuccessful; set => validationSuccessful = value; }


        /// <summary>
        /// 
        /// </summary>
        public PayeeFileInfoView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public void DrawTable()
        {
            SetTableProperties();
            GenerateTable(ColumnCount, RowCount);
        }

        /// <summary>
        /// 
        /// </summary>
        public void HideTable()
        {
            tableLayoutPanelData.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        public void ShowTable()
        {
            DisableReadOnlyColumns();
            tableLayoutPanelData.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        public void DisableReadOnlyColumns()
        {
            for (int x = 0; x < tableLayoutPanelData.RowCount; x++)
            {
                for (int y = 0; y < tableLayoutPanelData.ColumnCount - 3; y++)
                {
                    var control = tableLayoutPanelData.GetControlFromPosition(y, x);
                    if (control != null)
                        control.Enabled = false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnCount"></param>
        /// <param name="rowCount"></param>
        public void GenerateTable(int columnCount, int rowCount)
        {
            DrawResultSetHeading();
            DrawDataSetTable();
        }

        
        /// <summary>
        /// This will export the updates made to the payee push information to a new list
        /// </summary>
        public List<PayeeFileInfo> ExportUpdatesToList()
        {
            LstPayeeInfoUpdated = new List<PayeeFileInfo>(tableLayoutPanelData.RowCount);

            //Draw the table
            for (int x = 0; x < tableLayoutPanelData.RowCount; x++)
            {
                PayeeFileInfo payeeFileInfo = new PayeeFileInfo();

                for (int y = 0; y < tableLayoutPanelData.ColumnCount; y++)
                {
                    string text = tableLayoutPanelData.GetControlFromPosition(y, x).Text;

                    switch (y)
                    {
                        case 0:  //THIRD_PTY_DISB_TYPE
                            payeeFileInfo.cszThirdPtyDisbType = text;
                            break;

                        case 1:  //RELEASE_TME
                            payeeFileInfo.cszReleaseTime = text;
                            break;

                        case 2: //PUSH_IND
                            payeeFileInfo.cszPushInd = text;
                            break;

                        case 3: //SOURCE_PATH
                            payeeFileInfo.cszSourcePath = text;
                            break;

                        case 4: //SOURCE_FILE_NAME
                            payeeFileInfo.cszSourceFileName = text;
                            break;

                        case 5: //DEST_PATH
                            payeeFileInfo.cszDestPath = text;
                            break;

                        case 6: //DEST_FILE_NAME
                            payeeFileInfo.cszDestFileName = text;
                            break;

                    }

                }

                LstPayeeInfoUpdated.Add(payeeFileInfo);
            }
            return LstPayeeInfoUpdated;
        }

        #endregion

        #region Private Member Methods

        /// <summary>
        /// 
        /// </summary>
        private void DrawResultSetHeading()
        {
            //Clear out the existing controls, we are generating a new table layout
            tableLayoutPanelHeading.Controls.Clear();

            //Clear out the existing row and column styles
            tableLayoutPanelHeading.ColumnStyles.Clear();
            tableLayoutPanelHeading.RowStyles.Clear();

            //Set Column and Row for the table to be generated
            tableLayoutPanelHeading.ColumnCount = ++columnCount;
            tableLayoutPanelHeading.RowCount = 1;

            //Draw the table
            for (int x = 0, y = 0; y < tableLayoutPanelHeading.ColumnCount; y++)
            {
                tableLayoutPanelHeading.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
                Label lbl = new Label();
                lbl.Location = new System.Drawing.Point(x + 5, y + 5);
                lbl.Size = GetSize(y, 60);
                lbl.Text = GetHeadingVal(y);
                lbl.Font = new Font(lbl.Font.FontFamily, 7);
                tableLayoutPanelHeading.Controls.Add(lbl, y, x);
            }
        }

        /// <summary>
        /// This will draw the table with result set fetched from DB
        /// </summary>
        private void DrawDataSetTable()
        {
            //Clear out the existing controls, we are generating a new table layout
            tableLayoutPanelData.Controls.Clear();

            //Clear out the existing row and column styles
            tableLayoutPanelData.ColumnStyles.Clear();
            tableLayoutPanelData.RowStyles.Clear();

            //Do this to reduce flickering of table layout panel
            Type tp = tableLayoutPanelData.GetType().BaseType;
            System.Reflection.PropertyInfo pi =
                tp.GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance
                | System.Reflection.BindingFlags.NonPublic);
            
            //pi.SetValue(tableLayoutPanelData, true, null);

            //Now we will generate the data set, setting up the row and column counts first
            tableLayoutPanelData.ColumnCount = columnCount; //added one to add button at the end
            tableLayoutPanelData.RowCount = rowCount;

            //Draw the table
            for (int x = 0; x < tableLayoutPanelData.RowCount; x++)
            {
                for (int y = 0; y < tableLayoutPanelData.ColumnCount; y++)
                {
                    tableLayoutPanelData.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
                    if (y < tableLayoutPanelData.ColumnCount - 1)
                    {
                        TextBox textBox1 = new TextBox();
                        textBox1.Location = new System.Drawing.Point(x + 5, y + 5);
                        textBox1.Size = GetSize(y);
                        textBox1.Text = GetVal(x, y);
                        textBox1.Name = x.ToString() + "_" + y.ToString();
                        textBox1.Font = new Font(textBox1.Font.FontFamily, 7);
                        textBox1.TextChanged += new EventHandler(DestFileNameorPathChanged);
                        tableLayoutPanelData.Controls.Add(textBox1, y, x);
                    }
                    //btn1.Location = new System.Drawing.Point(x + 5, y + 5);
                    else if (y == tableLayoutPanelData.ColumnCount - 1)
                    {
                        Button btn1 = new Button();
                        btn1.Size = GetSize(y);
                        btn1.Font = new Font(btn1.Font.FontFamily, 7);
                        btn1.Text = "Verify";
                        btn1.Name = x.ToString() + "_" + y.ToString();
                        //EventArgDerived ed = new EventArgDerived(btn1.Name);
                        btn1.Click += new EventHandler(this.buttonShowSample_Click);
                        tableLayoutPanelData.Controls.Add(btn1, y, x);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private string GetHeadingVal(int currColumn)
        {
            string retVal = "";

            switch (currColumn % tableLayoutPanelHeading.ColumnCount)
            {
                case 0:
                    retVal = "TPDT";
                    break;

                case 1:
                    retVal = "RELEASE TME";
                    break;

                case 2:
                    retVal = "PUSH IND";
                    break;

                case 3:
                    retVal = "SOURCE PATH";
                    break;

                case 4:
                    retVal = "SOURCE FILE NAME";
                    break;

                case 5:
                    retVal = "DEST PATH";
                    break;

                case 6:
                    retVal = "DEST FILE NAME";
                    break;

                case 7:
                    retVal = "VALIDATE";
                    break;

                default:
                    break;

            }

            return retVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currColumn"></param>
        /// <param name="defaultHeight"></param>
        /// <param name="defaultWidth"></param>
        /// <returns></returns>
        private Size GetSize(int currColumn, int defaultHeight = ControlDefaultHeight, int defaultWidth = ControlDefaultWidth)
        {
            Size sz = new Size(-1, -1); //Default size

            //if (currColumn < 0 || currColumn > ColumnCount)
                //throw new Exception("Invalid col value received. currColumn = " + currColumn);

            switch (currColumn)
            {
                case 0:  //THIRD_PTY_DISB_TYPE
                    sz = new Size(defaultWidth / 2, defaultHeight);
                    break;

                case 1:  //RELEASE_TME
                    sz = new Size(defaultWidth / 3, defaultHeight);
                    break;

                case 2: //PUSH_IND
                    sz = new Size(defaultWidth / 5, defaultHeight);
                    break;

                case 3: //SOURCE_PATH
                    sz = new Size(defaultWidth , defaultHeight);
                    break;

                case 4: //SOURCE_FILE_NAME
                    sz = new Size(defaultWidth / 2, defaultHeight);
                    break;

                case 5: //DEST_PATH
                    sz = new Size(defaultWidth *2 / 3 , defaultHeight);
                    break;

                case 6: //DEST_FILE_NAME
                    sz = new Size(defaultWidth, defaultHeight);
                    break;

                case 7: //button size
                    sz = new Size(defaultWidth / 3, defaultHeight);
                    break;

                default:
                    break;

            }
            return sz;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currRow"></param>
        /// <param name="currColumn"></param>
        /// <returns></returns>
        private string GetVal(int currRow, int currColumn)
        {
            string retVal = "";

            if (currRow < 0 || currRow > tableLayoutPanelData.RowCount - 1)
                throw new Exception("Invalid row value received. currRow = " + currRow);

            if (currColumn < 0 || currColumn > tableLayoutPanelData.ColumnCount - 1)
                throw new Exception("Invalid col value received. currColumn = " + currColumn);


            switch (currColumn % tableLayoutPanelData.ColumnCount)
            {
                case 0:
                    retVal =  LstPayeeInfoOriginal[currRow].cszThirdPtyDisbType.Trim();
                    if (retVal == "") retVal = "null";
                    break;

                case 1:
                    retVal = LstPayeeInfoOriginal[currRow].cszReleaseTime.Trim();
                    if (retVal == "") retVal = "null";
                    break;

                case 2:
                    retVal = LstPayeeInfoOriginal[currRow].cszPushInd.Trim();
                    if (retVal == "") retVal = "null";
                    break;

                case 3:
                    retVal = LstPayeeInfoOriginal[currRow].cszSourcePath.Trim();
                    if (retVal == "") retVal = "null";
                    break;

                case 4:
                    retVal = LstPayeeInfoOriginal[currRow].cszSourceFileName.Trim();
                    if (retVal == "") retVal = "null";
                    break;

                case 5:
                    retVal = LstPayeeInfoOriginal[currRow].cszDestPath.Trim();
                    if (retVal == "") retVal = "null";
                    break;

                case 6:
                    retVal = LstPayeeInfoOriginal[currRow].cszDestFileName.Trim();
                    if (retVal == "") retVal = "null";
                    break;

                default:
                    break;

            }
            
            return retVal; 
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetTableProperties()
        {
            ColumnCount = ResultSetColCount;
            RowCount = LstPayeeInfoOriginal.Count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGetPushInfo_Click(object sender, EventArgs e)
        {
            DisableButtons();

            if (string.IsNullOrEmpty(this.richTextBoxEnterDisbType.Text.Trim()) ||
                ScriptCategory.ENTER_TPDT_HERE_MESSAGE == this.richTextBoxEnterDisbType.Text.Trim())
            {
                this.richTextBoxEnterDisbType.Text = ScriptCategory.ENTER_TPDT_HERE_MESSAGE;
                this.richTextBoxEnterDisbType.ForeColor = System.Drawing.Color.Red;
                return;
            }

            else  if (ShowPayeeFileInfo != null)
            {
                this.richTextBoxEnterDisbType.ForeColor = System.Drawing.Color.Black;
                ShowPayeeFileInfo(this, EventArgs.Empty);
                this.buttonValidate.Enabled = true;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<string> GetDestFileList()
        {
            List<string> destFileList = new List<string>();
            for (int row = 0; row < tableLayoutPanelData.RowCount; row++)
            {
                string DestFileTextBoxName = row.ToString() + "_" + "6";
                var control = tableLayoutPanelData.Controls.Find(DestFileTextBoxName, true);
                string destFileName = ((TextBox)control[0]).Text;

                if (control != null && control.Length > 0)
                {
                    destFileList.Add(((TextBox)control[0]).Text);
                }
            }
            return destFileList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void buttonValidate_Click(object sender, EventArgs e)
        {
            EventArgDerived ed = new EventArgDerived(ScriptCategory.VALIDATE_ALL_DEST_FILES);

            if (ValidateEntries != null)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    ValidateEntries(sender, ed);
                });
            }

            if (ValidationSuccessful)
            {
                this.buttonGenerateScripts.Enabled = true;
                this.buttonShowFolder.Enabled = true;
                this.buttonApplyToDB.Enabled = true;
                this.buttonBackout.Enabled = false;
            }
            else
            {
                DisableButtons();
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 

        private bool ScriptCreateButtonClickValidationPassed()
        {
            CszDMLFolderPath = this.txtBoxDMLScriptLocation.Text;
            if (string.IsNullOrEmpty(CszDMLFolderPath))
            {
                this.txtBoxDMLScriptLocation.Text = ScriptCategory.OUTPUT_SCRIPT_PATH_NULL_MESSAGE;
                this.txtBoxDMLScriptLocation.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            if (ScriptCategory.OUTPUT_SCRIPT_PATH_NULL_MESSAGE == this.txtBoxDMLScriptLocation.Text.Trim())
            {
                return false;
            }
			
			if (!Directory.Exists(CszDMLFolderPath))
            {
                Directory.CreateDirectory(CszDMLFolderPath);
            }

            return true;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richTextBoxEnterDisbType_TextChanged(object sender, EventArgs e)
        {
            //ThirdPtyDisbType = this.richTextBoxEnterDisbType.Text;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richTextBoxEnterDisbType_Click(object sender, EventArgs e)
        {
            this.richTextBoxEnterDisbType.Text = "";
        }

  
        /// <summary>
        /// Form Load Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PayeeFileInfoView_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.WindowState = FormWindowState.Normal;
            this.richTextBoxEnterDisbType.Font = new Font(richTextBoxEnterDisbType.Font.FontFamily, 8);
            this.labelEnterDisbType.Font = new Font(this.labelEnterDisbType.Font.FontFamily, 8);
            this.buttonClose.Font = new Font(this.buttonClose.Font.FontFamily, 8);
            this.buttonGetPushInfo.Font = new Font(this.buttonGetPushInfo.Font.FontFamily, 8);
            this.txtBoxDMLScriptLocation.Text = ScriptCategory.OUTPUT_SCRIPT_DEFAULT_PATH;
            CszDMLFolderPath = this.txtBoxDMLScriptLocation.Text;
            this.buttonValidate.Enabled = false;
            this.SpinningControl = new TransparentPictureBox();
            SpinningControl.Enabled = false;
            DisableButtons();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
            Application.ExitThread();
        }



        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void buttonShowSample_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                string[] words = btn.Name.Split('_');
                if (words.Length >= 2)
                {
                    int row = Int32.Parse(words[0]);
                    int col = Int32.Parse(words[1]);

                    string DestFileTextBoxName = row.ToString() + "_" + "6";
                    var control = tableLayoutPanelData.Controls.Find(DestFileTextBoxName, true);

                    if (control != null && control.Length > 0)
                    {
                        EventArgDerived ed = new EventArgDerived(((TextBox)control[0]).Text);

                        this.Invoke((MethodInvoker)delegate
                        {
                            ShowSampleClick(sender, ed);
                        });
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DestFileNameorPathChanged(object sender, EventArgs e)
        {
            DisableButtons();
        }

        /// <summary>
        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CreateSFTPScripts(object sender, EventArgs e)
        {
            if (ScriptCreateButtonClickValidationPassed())
            {
                var control = tableLayoutPanelData.GetControlFromPosition(0, 0);
                if (control != null)
                {
                    EventArgDerived ed = new EventArgDerived(ScriptCategory.SFTP_SCRIPT_TYPE);

                    this.Invoke((MethodInvoker)delegate
                    {
                        CreateScriptClick(sender, ed);
                    });
                }
            }
        }

        //This will generate all 4 scripts together in one click
        public void CreateAll4Scripts(object sender, EventArgs e)
        {
            if (ScriptCreateButtonClickValidationPassed())
            {
                var control = tableLayoutPanelData.GetControlFromPosition(0, 0);
                if (control != null)
                {
                    EventArgDerived ed = new EventArgDerived(ScriptCategory.ALL_4_SCRIPTS);

                    this.Invoke((MethodInvoker)delegate
                    {
                        CreateScriptClick(sender, ed);
                    });
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateBackoutScript(object sender, EventArgs e)
        {
            if (ScriptCreateButtonClickValidationPassed())
            {
                var control = tableLayoutPanelData.GetControlFromPosition(0, 0);

                if (control != null)
                {
                    EventArgDerived ed = new EventArgDerived(ScriptCategory.FTP_SCRIPT_TYPE);

                    this.Invoke((MethodInvoker)delegate
                    {
                        CreateScriptClick(sender, ed);
                    });
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateSFTPValidationScript(object sender, EventArgs e)
        {
            if (ScriptCreateButtonClickValidationPassed())
            {
                var control = tableLayoutPanelData.GetControlFromPosition(0, 0);

                if (control != null)
                {
                    EventArgDerived ed = new EventArgDerived(ScriptCategory.SFTP_VALIDATION_SCRIPT_TYPE);

                    this.Invoke((MethodInvoker)delegate
                    {
                        CreateScriptClick(sender, ed);
                    });
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateBackoutValidationScript(object sender, EventArgs e)
        {
            if (ScriptCreateButtonClickValidationPassed())
            {
                var control = tableLayoutPanelData.GetControlFromPosition(0, 0);

                if (control != null)
                {
                    EventArgDerived ed = new EventArgDerived(ScriptCategory.FTP_VALIDATION_SCRIPT_TYPE);

                    this.Invoke((MethodInvoker)delegate
                    {
                        CreateScriptClick(sender, ed);
                    });
                }
            }
        }


       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeLocationBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            fbd.Description = "Select the directory where you want to save the DML file(s).";
            fbd.ShowNewFolderButton = true;
            fbd.SelectedPath = @"D:\\~Newly Generated Scripts\\~DML";

            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                CszDMLFolderPath = fbd.SelectedPath;
                this.txtBoxDMLScriptLocation.Text = CszDMLFolderPath;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMLScriptLocationTxtBx_TextChanged(object sender, EventArgs e)
        {
            CszDMLFolderPath = this.txtBoxDMLScriptLocation.Text;
        }

        #endregion

        private void buttonApply_Click(object sender, EventArgs e)
        {

            this.buttonBackout.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public void DisableButtons()
        {
            this.buttonGenerateScripts.Enabled = false;
            this.buttonShowFolder.Enabled = false;
            this.buttonApplyToDB.Enabled = false;
            this.buttonBackout.Enabled = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGenerateScripts_Click(object sender, EventArgs e)
        {
            try
            {
                CreateSFTPScripts(sender, e);
                CreateBackoutScript(sender, e);
                CreateSFTPValidationScript(sender, e);
                CreateBackoutValidationScript(sender, e);
                MessageBox.Show(" Scripts Created Successfully");
            }
            catch(Exception ex)
            {
                return; 
            }
            

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonShowFolder_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(cszDMLFolderPath);
            }
            catch (Win32Exception win32Exception)
            {
                //The system cannot find the file specified...
               MessageBox.Show(win32Exception.Message);
                return;
            }
        }

        private void checkBoxOverwrite_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
