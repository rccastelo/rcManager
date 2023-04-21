using rcManagerDatas.Interfaces;
using rcManagerEntities.Entities;
using rcManagerModels;
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
            IList<SystemEntity> listRet = systemData.list();

            SystemTransfer systemTransferRet = new SystemTransfer();

            systemTransferRet.list = listRet;

            return systemTransferRet;
        }

        public SystemTransfer get(SystemTransfer systemTransfer)
        {
            SystemModel systemModel = new SystemModel(systemTransfer.entity);

            SystemEntity systemEntityRet = systemData.get(systemModel.id);

            SystemTransfer systemTransferRet = new SystemTransfer();

            systemTransferRet.entity = systemEntityRet;

            return systemTransferRet;
        }
    }
}
