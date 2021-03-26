using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIS.RDP.BPPS.SFTPScriptsGenerator
{
    static class ProgramMain
    {
        #region Fields
        private static readonly log4net.ILog _logger = 
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);

        internal enum SFTPScriptCreatorResult
        {
            SUCCESS = 0,
            INVALID_ARGS = 1,
            CONFIG_ERROR = 2,
            FILE_TRANSFER_FAILED = 3,
            APPLICATION_ERROR = 4
        }
        #endregion Fields

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main()
        {
            var dbServer = string.Empty;
            var dbUser = string.Empty;
            var dbPassword = string.Empty;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            PayeeFileInfoDataService payeeFileInfoDataService = new PayeeFileInfoDataService(dbServer, dbUser, dbPassword);
            PayeeFileInfoView payeeFileInfoView = new PayeeFileInfoView();
            DBLoginWindow dbLogInWindow = new DBLoginWindow();
            PayeeFileInfoController controller = new PayeeFileInfoController(payeeFileInfoView, payeeFileInfoDataService, dbLogInWindow);
            Application.Run(controller.DbLogInWindow);
            return (int)SFTPScriptCreatorResult.SUCCESS;
        }
    }


}
