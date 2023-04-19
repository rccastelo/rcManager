using rcManagerDatas.Interfaces;
using rcManagerServices.Interfaces;
using rcManagerTransfer.Interfaces;
using rcManagerTransfer.Transfers;

namespace rcManagerServices.Services
{
    public class SystemService : ISystemService
    {
        private readonly ISystemData systemData;

        public SystemService(ISystemData systemData) : base()
        {
            this.systemData = systemData;
        }

        public SystemTransfer list(ISystemTransfer systemTransfer)
        {
            SystemTransfer systemTransferRet = systemData.list(systemTransfer);

            return systemTransferRet;
        }
    }
}
