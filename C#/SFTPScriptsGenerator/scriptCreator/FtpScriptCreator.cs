using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIS.RDP.BPPS.SFTPScriptsGenerator
{
    class FtpScriptCreator : ScriptCreator
    {

        internal override bool WriteOutputScript()
        {
            StringBuilder sb = new StringBuilder(CszTemplateScriptName);
            File.AppendAllText(CszGeneratedScriptNameWithPath, sb.ToString());

            string ParameterReplaceString = "Back_to_Momentum( '#TPDT#', 'DEFAULT', '#SOURCE_FILE_NAME#', 'upload', '#EXISTING_DEST_FILE#', '#NEW_DEST_FILE#' );\n";
            string stringAfterReplacementDone = string.Empty;
            for (int ii = 0; ii < LstPayeeInfoOriginal.Count; ii++)
            {
                //Replace the template parameters
                StringBuilder sb2 = new StringBuilder(ParameterReplaceString);
                sb2.Replace("#TPDT#", LstPayeeInfoOriginal[ii].cszThirdPtyDisbType);
                sb2.Replace("#SOURCE_FILE_NAME#", LstPayeeInfoOriginal[ii].cszSourceFileName);
                sb2.Replace("#DEST_PATH#", LstPayeeInfoOriginal[ii].cszDestPath);
                sb2.Replace("#EXISTING_DEST_FILE#", LstPayeeInfoUpdated[ii].cszDestFileName);
                sb2.Replace("#NEW_DEST_FILE#", LstPayeeInfoOriginal[ii].cszDestFileName); //The changed version will be received from LstPayeeInfoUpdated
                stringAfterReplacementDone += sb2.ToString();
            }
            stringAfterReplacementDone += "\nEND;\n/\n";
            File.AppendAllText(CszGeneratedScriptNameWithPath, stringAfterReplacementDone);

            return true;
        }
    }

}
