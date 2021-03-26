
using FIS.RDP.BPPS.FileTransferUtil.Interfaces.DataServices;
using FIS.RDP.BPPS.FileTransferUtil.Interfaces.DataServices.Config;

namespace FIS.RDP.BPPS.FileTransferUtil.DataServices
{
    public class DataServicesFactory : IDataServicesFactory
    {
        private readonly string _connectionID = "FILETRANSFERUTIL1";


        public IDataConfigFetcher CreateDataConfigFetcher()
        {
            return new DataConfigFetcher(_connectionID);
        }

        public IDataConfigFetcherEx CreateDataSecureConfigFetcher()
        {
            return new DataSecureConfigFetcher(_connectionID);
        }
    }
}
