using SFTPScriptsGenerator.Properties;
using System;
using System.Collections.Generic;
using System.IO;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIS.RDP.BPPS.SFTPScriptsGenerator
{
    public abstract class ScriptCreator
    {
        internal string CszGeneratedScriptNameWithPath { get; set; }
        internal string CszTemplateScriptName { get; set; }
        internal string CszTemplateScriptPath { get; set; }
        internal string CszGeneratedScriptPath { get; set; }
        internal string CszGeneratedScriptFileName { get; set; }
        public List<PayeeFileInfo> LstPayeeInfoOriginal { get; set; }
        public List<PayeeFileInfo> LstPayeeInfoUpdated { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool CheckIfTemplateScriptExists()
        {
            return File.Exists(CszTemplateScriptName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool CheckIfOutputScriptAlreadyExists()
        {
            return File.Exists(CszGeneratedScriptNameWithPath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal abstract bool WriteOutputScript();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cszTemplateScriptFileName"></param>
        /// <param name="cszOutputScriptPath"></param>
        /// <param name="cszOutputScriptFileName"></param>
        /// <param name="lstOriginal"></param>
        /// <param name="lstUpdated"></param>
        internal void Initialize(string cszTemplateScriptFileName, 
                                 string cszOutputScriptPath,
                                 string cszOutputScriptFileName,
                                 List<PayeeFileInfo> lstOriginal,
                                 List<PayeeFileInfo> lstUpdated)
        {
            CszGeneratedScriptPath = cszOutputScriptPath;
            CszGeneratedScriptFileName = cszOutputScriptFileName;
            CszTemplateScriptName = cszTemplateScriptFileName;
            CszGeneratedScriptNameWithPath = Path.Combine(CszGeneratedScriptPath, CszGeneratedScriptFileName);
            LstPayeeInfoOriginal = lstOriginal;
            LstPayeeInfoUpdated = lstUpdated;
        }
    }
}
