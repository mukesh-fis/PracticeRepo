using System;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace FIS.RDP.BPPS.SFTPScriptsGenerator
{
    public class PayeeFileInfoDataService : IDisposable
    {
        #region Fields
        /// <summary>
        /// holds db server name
        /// </summary>
        private string _dbServer;
        /// <summary>
        /// holds db user id
        /// </summary>
        private string _dbUser;
        /// <summary>
        /// hold db password
        /// </summary>
        private string _dbPassword;
        /// <summary>
        /// reference to oracle conenction
        /// </summary>
        private OracleConnection _oracleConn;
        /// <summary>
        /// if the connection is opened or not
        /// </summary>
        private bool _isConnectionOpen;

        #endregion

        #region Properties
        public string DbServer { get => _dbServer; set => _dbServer = value; }
        public string DbUser { get => _dbUser; set => _dbUser = value; }
        public string DbPassword { get => _dbPassword; set => _dbPassword = value; }

        //public OracleConnection OracleConn { get => _oracleConn; set => _oracleConn = value; }

        public bool IsConnectionOpen { get => _isConnectionOpen; set => _isConnectionOpen = value; }

        #endregion

        #region Constructor
        public PayeeFileInfoDataService(string dbServer, string dbUser, string dbPassword)
        {
            _dbServer = dbServer;
            _dbUser = dbUser;
            _dbPassword = dbPassword;
            _isConnectionOpen = false;
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// This method returns the OracleDBType corresponding to the type of give c# object
        /// </summary>
        /// <param name="obj">C# object whose type is to be changed to OracleDbType</param>
        /// <returns>OracleDbType</returns>
        private OracleDbType GetOracleDbType(object obj)
        {
            OracleDbType oracleDBType = OracleDbType.NVarchar2;
            Type targetType = obj.GetType();

            try
            {
                oracleDBType = (OracleDbType)Enum.Parse(typeof(OracleDbType), targetType.Name);
            }
            catch
            {
                //If C# object Type is not compatible to OracleDBtype
                switch (targetType.Name.ToUpper())
                {
                    case "STRING": oracleDBType = OracleDbType.NVarchar2; break;
                    case "BOOLEAN": oracleDBType = OracleDbType.Byte; break;
                    case "DATETIME": oracleDBType = OracleDbType.Date; break;
                }
            }
            return oracleDBType;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// This method is to create and open oracle connection to given database
        /// </summary>
        /// <returns></returns>
        public bool Connect()
        {
            try
            {
                StringBuilder connectionString = new StringBuilder("User ID=" + DbUser + ";Password=" + DbPassword + ";Data Source=" + DbServer + "");
                string conn = connectionString.ToString();
                _oracleConn = new OracleConnection(conn);               
                _oracleConn.Open();
                _isConnectionOpen = true;
            }
            catch
            {
                //log and rethrow
                throw;
            }
            return true;
        }

        /// <summary>
        /// Executes the given sql query and returns the data as a 
        /// List<PayeeFileInfo> representing each row.
        /// </summary>
        /// <param name="query"></param>
        /// <returns>List of Dictionary records where values are mapped to field names</returns>
        public List<PayeeFileInfo> GetFilePushInfoForTPDT(string cszDisbTypeToProcess)
        {
            //Gethering information for the given payee
            string query = " SELECT DISTINCT PCI.THIRD_PTY_DISB_TYPE, " +
                            "       PCI.RELEASE_TME, " +
                            "       PPI.PUSH_IND, " +
                            "       PPI.SOURCE_PATH, " +
                            "       PPI.SOURCE_FILE_NAME, " +
                            "       PPI.DEST_PATH, " +
                            "       PPI.DEST_FILE_NAME " +
                            " FROM   PAYAUTO_CTM_INFO pci, PAYAUTO_PUSHMON_INFO ppi " +
                            " WHERE pci.Third_Pty_Disb_Type IN ( '" + cszDisbTypeToProcess + "' ) " +
                            " AND pci.PAYAUTO_CTM_INFO_SEQ_NBR = ppi.PAYAUTO_CTM_INFO_SEQ_NBR ";

            OracleCommand command = _oracleConn.CreateCommand();
            command.CommandText = query;

            OracleDataReader reader = command.ExecuteReader();

            List<PayeeFileInfo> data = new List<PayeeFileInfo>();

           // data = DataReaderMapToList<PayeeFileInfo>(reader);

            while (reader.Read())
            {
                PayeeFileInfo PayeeFileInfo = new PayeeFileInfo();

                PayeeFileInfo.cszThirdPtyDisbType = Convert.ToString(reader["THIRD_PTY_DISB_TYPE"]);  //reader.GetString(0)
                PayeeFileInfo.cszReleaseTime = Convert.ToString(reader["RELEASE_TME"]);
                PayeeFileInfo.cszPushInd = Convert.ToString(reader["PUSH_IND"]);
                PayeeFileInfo.cszSourcePath = Convert.ToString(reader["SOURCE_PATH"]);
                PayeeFileInfo.cszSourceFileName = Convert.ToString(reader["SOURCE_FILE_NAME"]);
                PayeeFileInfo.cszDestPath = Convert.ToString(reader["DEST_PATH"]); //reader.GetString(4); //
                PayeeFileInfo.cszDestFileName = Convert.ToString(reader["DEST_FILE_NAME"]);

                data.Add(PayeeFileInfo);
            }
            return data;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static List<T> DataReaderMapToList<T>(IDataReader dr)
        {
            List<T> list = new List<T>();
            T obj = default(T);
            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (!object.Equals(dr[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, dr[prop.Name], null);
                    }
                }
                list.Add(obj);
            }
            return list;
        }

        /// <summary>
        /// Dispose is called when memory is to be freed which was occupied by the reference of this class.
        /// </summary>
        public void Dispose()
        {
            _oracleConn.Close();
            _oracleConn.Dispose();
        }
        #endregion
    }
}
