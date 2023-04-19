using rcManagerDatas.Interfaces;
using rcManagerServices.Interfaces;
using rcManagerTransfers.Transfers;

namespace rcManagerServices.Services
{
    public class SystemService : ISystemService
    {
        private readonly ISystemData systemData;

        public SystemService(ISystemData systemData) : base()
        {
            this.systemData = systemData;
        }

        public SystemTransfer list(SystemTransfer systemTransfer)
        {
            SystemTransfer systemTransferRet = systemData.list(systemTransfer);

            return systemTransferRet;
        }
    }
}
