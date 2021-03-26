namespace FIS.RDP.BPPS.SFTPScriptsGenerator
{
    partial class DBLoginWindow
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
            this.grpDatabase = new System.Windows.Forms.GroupBox();
            this.rdbUnitTest = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDBPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtDBUser = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.lblDBServer = new System.Windows.Forms.Label();
            this.rdbProduction = new System.Windows.Forms.RadioButton();
            this.rdbReadiness = new System.Windows.Forms.RadioButton();
            this.rdbSystemTest = new System.Windows.Forms.RadioButton();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.lblWarnMessage = new System.Windows.Forms.Label();
            this.grpDatabase.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpDatabase
            // 
            this.grpDatabase.Controls.Add(this.rdbUnitTest);
            this.grpDatabase.Controls.Add(this.groupBox1);
            this.grpDatabase.Controls.Add(this.txtDBPassword);
            this.grpDatabase.Controls.Add(this.lblPassword);
            this.grpDatabase.Controls.Add(this.txtDBUser);
            this.grpDatabase.Controls.Add(this.lblUser);
            this.grpDatabase.Controls.Add(this.txtDatabase);
            this.grpDatabase.Controls.Add(this.lblDBServer);
            this.grpDatabase.Controls.Add(this.rdbProduction);
            this.grpDatabase.Controls.Add(this.rdbReadiness);
            this.grpDatabase.Controls.Add(this.rdbSystemTest);
            this.grpDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDatabase.Location = new System.Drawing.Point(1, 3);
            this.grpDatabase.Name = "grpDatabase";
            this.grpDatabase.Size = new System.Drawing.Size(721, 104);
            this.grpDatabase.TabIndex = 1;
            this.grpDatabase.TabStop = false;
            this.grpDatabase.Text = "Please Select Database";
            // 
            // rdbUnitTest
            // 
            this.rdbUnitTest.AutoSize = true;
            this.rdbUnitTest.Location = new System.Drawing.Point(45, 21);
            this.rdbUnitTest.Name = "rdbUnitTest";
            this.rdbUnitTest.Size = new System.Drawing.Size(79, 20);
            this.rdbUnitTest.TabIndex = 1;
            this.rdbUnitTest.Text = "Unit Test";
            this.rdbUnitTest.UseVisualStyleBackColor = true;
            this.rdbUnitTest.CheckedChanged += new System.EventHandler(this.rdbUnitTest_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(16, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(574, 12);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // txtDBPassword
            // 
            this.txtDBPassword.Location = new System.Drawing.Point(573, 68);
            this.txtDBPassword.Name = "txtDBPassword";
            this.txtDBPassword.PasswordChar = '*';
            this.txtDBPassword.Size = new System.Drawing.Size(125, 22);
            this.txtDBPassword.TabIndex = 7;
            this.txtDBPassword.TextChanged += new System.EventHandler(this.txtDBPassword_TextChanged);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(505, 71);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(68, 16);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "Password";
            // 
            // txtDBUser
            // 
            this.txtDBUser.Location = new System.Drawing.Point(310, 68);
            this.txtDBUser.Name = "txtDBUser";
            this.txtDBUser.Size = new System.Drawing.Size(189, 22);
            this.txtDBUser.TabIndex = 6;
            this.txtDBUser.TextChanged += new System.EventHandler(this.txtDBUser_TextChanged);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(274, 71);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(37, 16);
            this.lblUser.TabIndex = 5;
            this.lblUser.Text = "User";
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(76, 68);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(186, 22);
            this.txtDatabase.TabIndex = 5;
            this.txtDatabase.TextChanged += new System.EventHandler(this.txtDatabase_TextChanged);
            // 
            // lblDBServer
            // 
            this.lblDBServer.AutoSize = true;
            this.lblDBServer.Location = new System.Drawing.Point(6, 68);
            this.lblDBServer.Name = "lblDBServer";
            this.lblDBServer.Size = new System.Drawing.Size(70, 16);
            this.lblDBServer.TabIndex = 3;
            this.lblDBServer.Text = "DB Server";
            // 
            // rdbProduction
            // 
            this.rdbProduction.AutoSize = true;
            this.rdbProduction.Location = new System.Drawing.Point(596, 21);
            this.rdbProduction.Name = "rdbProduction";
            this.rdbProduction.Size = new System.Drawing.Size(90, 20);
            this.rdbProduction.TabIndex = 4;
            this.rdbProduction.TabStop = true;
            this.rdbProduction.Text = "Production";
            this.rdbProduction.UseVisualStyleBackColor = true;
            this.rdbProduction.CheckedChanged += new System.EventHandler(this.rdbProduction_CheckedChanged);
            // 
            // rdbReadiness
            // 
            this.rdbReadiness.AutoSize = true;
            this.rdbReadiness.Location = new System.Drawing.Point(412, 21);
            this.rdbReadiness.Name = "rdbReadiness";
            this.rdbReadiness.Size = new System.Drawing.Size(92, 20);
            this.rdbReadiness.TabIndex = 3;
            this.rdbReadiness.TabStop = true;
            this.rdbReadiness.Text = "Readiness";
            this.rdbReadiness.UseVisualStyleBackColor = true;
            this.rdbReadiness.CheckedChanged += new System.EventHandler(this.rdbReadiness_CheckedChanged);
            // 
            // rdbSystemTest
            // 
            this.rdbSystemTest.AutoSize = true;
            this.rdbSystemTest.Location = new System.Drawing.Point(210, 21);
            this.rdbSystemTest.Name = "rdbSystemTest";
            this.rdbSystemTest.Size = new System.Drawing.Size(101, 20);
            this.rdbSystemTest.TabIndex = 2;
            this.rdbSystemTest.Text = "System Test";
            this.rdbSystemTest.UseVisualStyleBackColor = true;
            this.rdbSystemTest.CheckedChanged += new System.EventHandler(this.rdbSystemTest_CheckedChanged);
            // 
            // CloseBtn
            // 
            this.CloseBtn.BackColor = System.Drawing.SystemColors.Control;
            this.CloseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseBtn.ForeColor = System.Drawing.Color.Maroon;
            this.CloseBtn.Location = new System.Drawing.Point(368, 151);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(146, 37);
            this.CloseBtn.TabIndex = 9;
            this.CloseBtn.Text = "Cancel";
            this.CloseBtn.UseVisualStyleBackColor = false;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // OK
            // 
            this.OK.BackColor = System.Drawing.SystemColors.Control;
            this.OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OK.ForeColor = System.Drawing.Color.Maroon;
            this.OK.Location = new System.Drawing.Point(185, 151);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(160, 37);
            this.OK.TabIndex = 8;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = false;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // lblWarnMessage
            // 
            this.lblWarnMessage.AutoSize = true;
            this.lblWarnMessage.Location = new System.Drawing.Point(77, 110);
            this.lblWarnMessage.Name = "lblWarnMessage";
            this.lblWarnMessage.Size = new System.Drawing.Size(0, 13);
            this.lblWarnMessage.TabIndex = 10;
            // 
            // DBLoginWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(744, 191);
            this.Controls.Add(this.lblWarnMessage);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.grpDatabase);
            this.Name = "DBLoginWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DBLogInWindow";
            this.Load += new System.EventHandler(this.DBDialog_Load);
            this.grpDatabase.ResumeLayout(false);
            this.grpDatabase.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDatabase;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDBPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtDBUser;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Label lblDBServer;
        private System.Windows.Forms.RadioButton rdbProduction;
        private System.Windows.Forms.RadioButton rdbReadiness;
        private System.Windows.Forms.RadioButton rdbSystemTest;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.RadioButton rdbUnitTest;
        private System.Windows.Forms.Label lblWarnMessage;
    }
}