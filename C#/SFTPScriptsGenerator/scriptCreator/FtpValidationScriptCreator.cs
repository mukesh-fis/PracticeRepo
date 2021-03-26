using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIS.RDP.BPPS.SFTPScriptsGenerator
{
    class FtpValidationScriptCreator : ScriptCreator
    {
        internal override bool WriteOutputScript()
        {
            StringBuilder sb = new StringBuilder(CszTemplateScriptName);
            if (LstPayeeInfoOriginal.Count > 0)
            {
                sb.Replace("#TPDT#", LstPayeeInfoOriginal[0].cszThirdPtyDisbType);
                sb.Replace("#NUM#", String.Format("{0, 0}", LstPayeeInfoOriginal.Count));
            }
            File.AppendAllText(CszGeneratedScriptNameWithPath, sb.ToString());

            string header = "SOURCE_PATH".PadRight(38) + "SOURCE_FILE_NAME".PadRight(26) +
                            "DEST_PATH".PadRight(18) + "DEST_FILE_NAME".PadRight(46) +
                            "PUSH_IND".PadRight(12) + "PUSH_CONFIG_SECTION".PadRight(20);


            header += "\n------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n";
            File.AppendAllText(CszGeneratedScriptNameWithPath, header);

            string ParameterReplaceString = "#SOURCE_PATH#           #SOURCE_FILE_NAME#        #DEST_PATH#       #NEW_DEST_FILE#              Y          3                     CONFIG_SFTP_01\n";
            string stringWithPayeeInfo = string.Empty;

            for (int ii = 0; ii < LstPayeeInfoOriginal.Count; ii++)
            {
                //Replace the template parameters
                stringWithPayeeInfo += LstPayeeInfoOriginal[ii].cszSourcePath.PadRight(38);
                stringWithPayeeInfo += LstPayeeInfoOriginal[ii].cszSourceFileName.PadRight(26);
                stringWithPayeeInfo += LstPayeeInfoOriginal[ii].cszDestPath.PadRight(18);
                stringWithPayeeInfo += LstPayeeInfoOriginal[ii].cszDestFileName.PadRight(46);
                stringWithPayeeInfo += LstPayeeInfoOriginal[ii].cszPushInd.PadRight(12);
                stringWithPayeeInfo += "CONFIG_FTP_01".PadRight(20);
                stringWithPayeeInfo += "\n";
            }
            stringWithPayeeInfo += "\n";
            File.AppendAllText(CszGeneratedScriptNameWithPath, stringWithPayeeInfo);

            ParameterReplaceString = "************************************************************************************************************************************************************************************/\n" +
                                  "\nselect PPI.SOURCE_PATH, PPI.SOURCE_FILE_NAME, PPI.DEST_PATH, PPI.DEST_FILE_NAME, PPI.PUSH_IND, PCI.PUSH_CONFIG_SECTION" +
                                  "\nfrom PAYAUTO_PUSHMON_INFO PPI, PAYAUTO_CTM_INFO PCI" +
                                  "\nwhere PPI.PAYAUTO_CTM_INFO_SEQ_NBR = PCI.PAYAUTO_CTM_INFO_SEQ_NBR " +
                                  "\nAND PCI.THIRD_PTY_DISB_TYPE IN('#TPDT#')";

            StringBuilder sb3 = new StringBuilder(ParameterReplaceString);
            if (LstPayeeInfoOriginal.Count > 0)
            {
                sb3.Replace("#TPDT#", LstPayeeInfoOriginal[0].cszThirdPtyDisbType);
            }
            File.AppendAllText(CszGeneratedScriptNameWithPath, sb3.ToString());
            stringWithPayeeInfo = "\n;\n";
            File.AppendAllText(CszGeneratedScriptNameWithPath, stringWithPayeeInfo);

            return true;
        }
    }
}
