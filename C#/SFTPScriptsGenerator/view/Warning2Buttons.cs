using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIS.RDP.BPPS.SFTPScriptsGenerator
{
    public partial class Warning2Buttons : Form
    {
        public string ReturnValue { get; set; } 
        public Warning2Buttons()
        {
            InitializeComponent();
        }

        private void OverwriteBtn_Click(object sender, EventArgs e)
        {
            this.ReturnValue = "Overwrite";
            Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.ReturnValue = "Cancel";
            Close();
        }
    }
}
