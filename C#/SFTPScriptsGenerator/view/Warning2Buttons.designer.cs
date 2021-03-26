namespace FIS.RDP.BPPS.SFTPScriptsGenerator
{
    partial class Warning2Buttons
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
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OverwriteBtn = new System.Windows.Forms.Button();
            this.warninLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CancelBtn
            // 
            this.CancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelBtn.Location = new System.Drawing.Point(130, 46);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(77, 23);
            this.CancelBtn.TabIndex = 9;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // OverwriteBtn
            // 
            this.OverwriteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OverwriteBtn.Location = new System.Drawing.Point(16, 46);
            this.OverwriteBtn.Name = "OverwriteBtn";
            this.OverwriteBtn.Size = new System.Drawing.Size(81, 23);
            this.OverwriteBtn.TabIndex = 8;
            this.OverwriteBtn.Text = "Overwrite";
            this.OverwriteBtn.UseVisualStyleBackColor = true;
            this.OverwriteBtn.Click += new System.EventHandler(this.OverwriteBtn_Click);
            // 
            // warninLbl
            // 
            this.warninLbl.AutoSize = true;
            this.warninLbl.Cursor = System.Windows.Forms.Cursors.Default;
            this.warninLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warninLbl.Location = new System.Drawing.Point(14, 14);
            this.warninLbl.Name = "warninLbl";
            this.warninLbl.Size = new System.Drawing.Size(198, 13);
            this.warninLbl.TabIndex = 7;
            this.warninLbl.Text = "A file of this name already exists. ";
            this.warninLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Warning2Buttons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(235, 81);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OverwriteBtn);
            this.Controls.Add(this.warninLbl);
            this.Name = "Warning2Buttons";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Warning!!!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button OverwriteBtn;
        private System.Windows.Forms.Label warninLbl;
    }
}