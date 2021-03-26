using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIS.RDP.BPPS.SFTPScriptsGenerator
{
    public class ScriptCategory
    {
        public const string SFTP_SCRIPT_TYPE = "SFTP Script" ;
        public const string FTP_SCRIPT_TYPE = "Backout Script";
        public const string SFTP_VALIDATION_SCRIPT_TYPE = "SFTP Validation Script";
        public const string FTP_VALIDATION_SCRIPT_TYPE = "Backout Validation Script";
        public const string ALL_4_SCRIPTS = "ALL_4_SCRIPTS";

        public const string SFTP_SCRIPT_TEMPLATE_NAME = "Switch_To_MOVEIt";
        public const string FTP_SCRIPT_TEMPLATE_NAME = "Back_to_Momentum";
        public const string SFTP_VALIDATION_SCRIPT_TEMPLATE_NAME = "Switch_To_MOVEIt_validation";
        public const string FTP_VALIDATION_SCRIPT_TEMPLATE_NAME = "Back_to_Momentum_validation";
        public const string SCRIPT_TEMPLATE_NAME_EXT = ".sql";

        public const string SCRIPT_TEMPLATE_PATH = "resources"; //"C:\\~Mukesh\\@@DoNotDelete\\~Template Creation Utilities\\SFTPScriptsGenerator\\templates"; //"..\\..\\..\\SFTPScriptsGenerator\\templates";
        public const string OUTPUT_SCRIPT_DEFAULT_PATH = "D:\\~Newly Generated Scripts\\~DML";
        public const string OUTPUT_SCRIPT_PATH_NULL_MESSAGE = "Script path can't be null...";
        public const string ENTER_TPDT_HERE_MESSAGE = "Please Enter TPDT here...";

        public const string ENTER_DBSERVER_MESSAGE = "Enter DB Server.";
        public const string ENTER_DBUSER_MESSAGE = "Enter DB User.";
        public const string ENTER_PASSWORD_MESSAGE = "Enter Password.";

        public const string VALIDATE_ALL_DEST_FILES = "Validate All Dest Files";
    }
}
