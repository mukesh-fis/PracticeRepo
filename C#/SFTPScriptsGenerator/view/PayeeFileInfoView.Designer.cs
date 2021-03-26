namespace FIS.RDP.BPPS.SFTPScriptsGenerator
{
    partial class PayeeFileInfoView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonGetPushInfo = new System.Windows.Forms.Button();
            this.richTextBoxEnterDisbType = new System.Windows.Forms.RichTextBox();
            this.labelEnterDisbType = new System.Windows.Forms.Label();
            this.tableLayoutPanelData = new System.Windows.Forms.TableLayoutPanel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.tableLayoutPanelHeading = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDML = new System.Windows.Forms.Label();
            this.txtBoxDMLScriptLocation = new System.Windows.Forms.TextBox();
            this.buttonChangeLocation = new System.Windows.Forms.Button();
            this.lblWarnErr = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonShowFolder = new System.Windows.Forms.Button();
            this.buttonBackout = new System.Windows.Forms.Button();
            this.buttonGenerateScripts = new System.Windows.Forms.Button();
            this.buttonApplyToDB = new System.Windows.Forms.Button();
            this.buttonValidate = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.checkBoxOverwrite = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonGetPushInfo
            // 
            this.buttonGetPushInfo.BackColor = System.Drawing.SystemColors.Control;
            this.buttonGetPushInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGetPushInfo.ForeColor = System.Drawing.SystemColors.InfoText;
            this.buttonGetPushInfo.Location = new System.Drawing.Point(365, 18);
            this.buttonGetPushInfo.Name = "buttonGetPushInfo";
            this.buttonGetPushInfo.Size = new System.Drawing.Size(133, 27);
            this.buttonGetPushInfo.TabIndex = 0;
            this.buttonGetPushInfo.Text = "Get Payee File Push Info";
            this.buttonGetPushInfo.UseVisualStyleBackColor = false;
            this.buttonGetPushInfo.Click += new System.EventHandler(this.buttonGetPushInfo_Click);
            // 
            // richTextBoxEnterDisbType
            // 
            this.richTextBoxEnterDisbType.Location = new System.Drawing.Point(181, 18);
            this.richTextBoxEnterDisbType.Name = "richTextBoxEnterDisbType";
            this.richTextBoxEnterDisbType.Size = new System.Drawing.Size(169, 24);
            this.richTextBoxEnterDisbType.TabIndex = 1;
            this.richTextBoxEnterDisbType.Text = "";
            this.richTextBoxEnterDisbType.Click += new System.EventHandler(this.richTextBoxEnterDisbType_Click);
            this.richTextBoxEnterDisbType.TextChanged += new System.EventHandler(this.richTextBoxEnterDisbType_TextChanged);
            // 
            // labelEnterDisbType
            // 
            this.labelEnterDisbType.AutoSize = true;
            this.labelEnterDisbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEnterDisbType.Location = new System.Drawing.Point(22, 24);
            this.labelEnterDisbType.Name = "labelEnterDisbType";
            this.labelEnterDisbType.Size = new System.Drawing.Size(153, 13);
            this.labelEnterDisbType.TabIndex = 2;
            this.labelEnterDisbType.Text = "Enter Disbursement Type:";
            // 
            // tableLayoutPanelData
            // 
            this.tableLayoutPanelData.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tableLayoutPanelData.ColumnCount = 2;
            this.tableLayoutPanelData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelData.Location = new System.Drawing.Point(10, 90);
            this.tableLayoutPanelData.Name = "tableLayoutPanelData";
            this.tableLayoutPanelData.RowCount = 2;
            this.tableLayoutPanelData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelData.Size = new System.Drawing.Size(958, 291);
            this.tableLayoutPanelData.TabIndex = 3;
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.ForeColor = System.Drawing.Color.Red;
            this.buttonClose.Location = new System.Drawing.Point(19, 354);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(147, 27);
            this.buttonClose.TabIndex = 45;
            this.buttonClose.Text = "Exit";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tableLayoutPanelHeading
            // 
            this.tableLayoutPanelHeading.ColumnCount = 2;
            this.tableLayoutPanelHeading.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelHeading.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelHeading.Location = new System.Drawing.Point(10, 17);
            this.tableLayoutPanelHeading.Name = "tableLayoutPanelHeading";
            this.tableLayoutPanelHeading.RowCount = 2;
            this.tableLayoutPanelHeading.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelHeading.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelHeading.Size = new System.Drawing.Size(958, 63);
            this.tableLayoutPanelHeading.TabIndex = 46;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buttonGetPushInfo);
            this.panel1.Controls.Add(this.richTextBoxEnterDisbType);
            this.panel1.Controls.Add(this.labelEnterDisbType);
            this.panel1.Location = new System.Drawing.Point(14, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(515, 59);
            this.panel1.TabIndex = 47;
            // 
            // lblDML
            // 
            this.lblDML.AutoSize = true;
            this.lblDML.BackColor = System.Drawing.Color.Transparent;
            this.lblDML.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblDML.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblDML.ForeColor = System.Drawing.Color.Black;
            this.lblDML.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDML.Location = new System.Drawing.Point(11, 24);
            this.lblDML.Name = "lblDML";
            this.lblDML.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDML.Size = new System.Drawing.Size(74, 13);
            this.lblDML.TabIndex = 49;
            this.lblDML.Text = "Script Path:";
            // 
            // txtBoxDMLScriptLocation
            // 
            this.txtBoxDMLScriptLocation.BackColor = System.Drawing.SystemColors.Window;
            this.txtBoxDMLScriptLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxDMLScriptLocation.Location = new System.Drawing.Point(91, 18);
            this.txtBoxDMLScriptLocation.Multiline = true;
            this.txtBoxDMLScriptLocation.Name = "txtBoxDMLScriptLocation";
            this.txtBoxDMLScriptLocation.Size = new System.Drawing.Size(285, 25);
            this.txtBoxDMLScriptLocation.TabIndex = 50;
            this.txtBoxDMLScriptLocation.TextChanged += new System.EventHandler(this.DMLScriptLocationTxtBx_TextChanged);
            // 
            // buttonChangeLocation
            // 
            this.buttonChangeLocation.BackColor = System.Drawing.SystemColors.Control;
            this.buttonChangeLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChangeLocation.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonChangeLocation.Location = new System.Drawing.Point(382, 17);
            this.buttonChangeLocation.Name = "buttonChangeLocation";
            this.buttonChangeLocation.Size = new System.Drawing.Size(69, 29);
            this.buttonChangeLocation.TabIndex = 51;
            this.buttonChangeLocation.Tag = "";
            this.buttonChangeLocation.Text = "Browse";
            this.buttonChangeLocation.UseVisualStyleBackColor = false;
            this.buttonChangeLocation.Click += new System.EventHandler(this.ChangeLocationBtn_Click);
            // 
            // lblWarnErr
            // 
            this.lblWarnErr.AutoSize = true;
            this.lblWarnErr.Location = new System.Drawing.Point(334, 79);
            this.lblWarnErr.Name = "lblWarnErr";
            this.lblWarnErr.Size = new System.Drawing.Size(0, 13);
            this.lblWarnErr.TabIndex = 52;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.buttonShowFolder);
            this.panel3.Controls.Add(this.buttonBackout);
            this.panel3.Controls.Add(this.buttonClose);
            this.panel3.Controls.Add(this.buttonGenerateScripts);
            this.panel3.Controls.Add(this.buttonApplyToDB);
            this.panel3.Controls.Add(this.buttonValidate);
            this.panel3.Location = new System.Drawing.Point(991, 95);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(180, 405);
            this.panel3.TabIndex = 53;
            // 
            // buttonShowFolder
            // 
            this.buttonShowFolder.BackColor = System.Drawing.SystemColors.Control;
            this.buttonShowFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowFolder.ForeColor = System.Drawing.SystemColors.InfoText;
            this.buttonShowFolder.Location = new System.Drawing.Point(19, 156);
            this.buttonShowFolder.Name = "buttonShowFolder";
            this.buttonShowFolder.Size = new System.Drawing.Size(147, 32);
            this.buttonShowFolder.TabIndex = 5;
            this.buttonShowFolder.Text = "Show Scripts in Folder";
            this.buttonShowFolder.UseVisualStyleBackColor = false;
            this.buttonShowFolder.Click += new System.EventHandler(this.buttonShowFolder_Click);
            // 
            // buttonBackout
            // 
            this.buttonBackout.BackColor = System.Drawing.SystemColors.Control;
            this.buttonBackout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBackout.ForeColor = System.Drawing.SystemColors.InfoText;
            this.buttonBackout.Location = new System.Drawing.Point(19, 288);
            this.buttonBackout.Name = "buttonBackout";
            this.buttonBackout.Size = new System.Drawing.Size(147, 32);
            this.buttonBackout.TabIndex = 4;
            this.buttonBackout.Text = "Backout DB Changes";
            this.buttonBackout.UseVisualStyleBackColor = false;
            // 
            // buttonGenerateScripts
            // 
            this.buttonGenerateScripts.BackColor = System.Drawing.SystemColors.Control;
            this.buttonGenerateScripts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGenerateScripts.ForeColor = System.Drawing.SystemColors.InfoText;
            this.buttonGenerateScripts.Location = new System.Drawing.Point(19, 90);
            this.buttonGenerateScripts.Name = "buttonGenerateScripts";
            this.buttonGenerateScripts.Size = new System.Drawing.Size(147, 32);
            this.buttonGenerateScripts.TabIndex = 3;
            this.buttonGenerateScripts.Text = "Generate Scripts";
            this.buttonGenerateScripts.UseVisualStyleBackColor = false;
            this.buttonGenerateScripts.Click += new System.EventHandler(this.buttonGenerateScripts_Click);
            // 
            // buttonApplyToDB
            // 
            this.buttonApplyToDB.BackColor = System.Drawing.SystemColors.Control;
            this.buttonApplyToDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonApplyToDB.ForeColor = System.Drawing.SystemColors.InfoText;
            this.buttonApplyToDB.Location = new System.Drawing.Point(19, 222);
            this.buttonApplyToDB.Name = "buttonApplyToDB";
            this.buttonApplyToDB.Size = new System.Drawing.Size(147, 32);
            this.buttonApplyToDB.TabIndex = 2;
            this.buttonApplyToDB.Text = "Apply changes to DB";
            this.buttonApplyToDB.UseVisualStyleBackColor = false;
            this.buttonApplyToDB.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // buttonValidate
            // 
            this.buttonValidate.BackColor = System.Drawing.SystemColors.Control;
            this.buttonValidate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonValidate.ForeColor = System.Drawing.SystemColors.InfoText;
            this.buttonValidate.Location = new System.Drawing.Point(19, 24);
            this.buttonValidate.Name = "buttonValidate";
            this.buttonValidate.Size = new System.Drawing.Size(147, 32);
            this.buttonValidate.TabIndex = 1;
            this.buttonValidate.Text = "Validate Input";
            this.buttonValidate.UseVisualStyleBackColor = false;
            this.buttonValidate.Click += new System.EventHandler(this.buttonValidate_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.checkBoxOverwrite);
            this.panel2.Controls.Add(this.lblDML);
            this.panel2.Controls.Add(this.txtBoxDMLScriptLocation);
            this.panel2.Controls.Add(this.buttonChangeLocation);
            this.panel2.Location = new System.Drawing.Point(545, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(626, 59);
            this.panel2.TabIndex = 54;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.tableLayoutPanelHeading);
            this.panel4.Controls.Add(this.tableLayoutPanelData);
            this.panel4.Location = new System.Drawing.Point(12, 95);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(973, 405);
            this.panel4.TabIndex = 55;
            // 
            // checkBoxOverwrite
            // 
            this.checkBoxOverwrite.AutoSize = true;
            this.checkBoxOverwrite.Location = new System.Drawing.Point(482, 24);
            this.checkBoxOverwrite.Name = "checkBoxOverwrite";
            this.checkBoxOverwrite.Size = new System.Drawing.Size(130, 17);
            this.checkBoxOverwrite.TabIndex = 52;
            this.checkBoxOverwrite.Text = "Overwrite if file exists?";
            this.checkBoxOverwrite.UseVisualStyleBackColor = true;
            this.checkBoxOverwrite.CheckedChanged += new System.EventHandler(this.checkBoxOverwrite_CheckedChanged);
            // 
            // PayeeFileInfoView
            // 
            this.AcceptButton = this.buttonGetPushInfo;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(1190, 533);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblWarnErr);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "PayeeFileInfoView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SFTPScriptCreator";
            this.Load += new System.EventHandler(this.PayeeFileInfoView_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGetPushInfo;
        private System.Windows.Forms.RichTextBox richTextBoxEnterDisbType;
        private System.Windows.Forms.Label labelEnterDisbType;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelData;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelHeading;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDML;
        private System.Windows.Forms.TextBox txtBoxDMLScriptLocation;
        private System.Windows.Forms.Button buttonChangeLocation;
        private System.Windows.Forms.Label lblWarnErr;
        private DBLoginWindow dbDialog;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonValidate;
        private System.Windows.Forms.Button buttonApplyToDB;
        private System.Windows.Forms.Button buttonShowFolder;
        private System.Windows.Forms.Button buttonBackout;
        private System.Windows.Forms.Button buttonGenerateScripts;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox checkBoxOverwrite;
    }
}

