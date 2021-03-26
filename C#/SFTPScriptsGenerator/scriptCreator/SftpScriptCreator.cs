using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIS.RDP.BPPS.SFTPScriptsGenerator 
{
    public class SftpScriptCreator : ScriptCreator
    {
        /// <summary>
        /// 
        /// </summary>
        internal override bool WriteOutputScript()
        {
            StringBuilder sb = new StringBuilder(CszTemplateScriptName);
            File.AppendAllText(CszGeneratedScriptNameWithPath, sb.ToString());

            string ParameterReplaceString = "Switch_To_MOVEIt( '#TPDT#', 'DEFAULT', #RELEASE_TIME#, '#SOURCE_FILE_NAME#', '#DEST_PATH#', '#EXISTING_DEST_FILE#', '#NEW_DEST_FILE#' );\n";
            string stringAfterReplacementDone = string.Empty;
            for (int ii = 0; ii < LstPayeeInfoOriginal.Count; ii++)
            {
                //Replace the template parameters
                StringBuilder sb2 = new StringBuilder(ParameterReplaceString);
                sb2.Replace("#TPDT#", LstPayeeInfoOriginal[ii].cszThirdPtyDisbType);

                if(string.IsNullOrEmpty(LstPayeeInfoOriginal[ii].cszReleaseTime))
                    sb2.Replace("#RELEASE_TIME#", "null");
                else
                    sb2.Replace("#RELEASE_TIME#", LstPayeeInfoOriginal[ii].cszReleaseTime);

                sb2.Replace("#SOURCE_FILE_NAME#", LstPayeeInfoOriginal[ii].cszSourceFileName);
                sb2.Replace("#DEST_PATH#", LstPayeeInfoUpdated[ii].cszDestPath);
                sb2.Replace("#EXISTING_DEST_FILE#", LstPayeeInfoOriginal[ii].cszDestFileName);
                sb2.Replace("#NEW_DEST_FILE#", LstPayeeInfoUpdated[ii].cszDestFileName); //The changed version will be received from LstPayeeInfoUpdated
                stringAfterReplacementDone += sb2.ToString();
            }
            stringAfterReplacementDone += "\nEND;\n/\n";
            File.AppendAllText(CszGeneratedScriptNameWithPath, stringAfterReplacementDone);

            return true;
        }
    }
}
