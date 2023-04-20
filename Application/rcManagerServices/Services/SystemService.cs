using rcManagerDatas.Interfaces;
using rcManagerEntities.Entities;
using rcManagerServices.Interfaces;
using rcManagerTransfers.Transfers;
using System.Collections.Generic;

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
            IList<SystemEntity> lista = systemData.list();

            SystemTransfer systemTransferRet = new SystemTransfer();

            systemTransferRet.list = lista;

            return systemTransferRet;
        }
    }
}
