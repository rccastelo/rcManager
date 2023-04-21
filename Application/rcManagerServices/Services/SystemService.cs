using rcManagerDatas.Interfaces;
using rcManagerEntities.Entities;
using rcManagerModels.Models;
using rcManagerServices.Interfaces;
using rcManagerTransfers.Transfers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace rcManagerServices.Services
{
    public class SystemService : ISystemService
    {
        private readonly ISystemData _systemData;

        public SystemService(ISystemData systemData) : base()
        {
            this._systemData = systemData;
        }

        public SystemTransfer list(SystemTransfer systemTransfer)
        {
            SystemTransfer systemTransferRet = new SystemTransfer();

            try
            {
                IList<SystemEntity> listRet = _systemData.list();

                systemTransferRet.list = listRet.Select(et => new SystemModel(et)).ToList();
            }
            catch (ArgumentException ex)
            {
                systemTransferRet = new SystemTransfer();
                systemTransferRet.valid = false;
                systemTransferRet.error = true;
                systemTransferRet.addMessage(ex.Message);
            }

            return systemTransferRet;
        }

        public SystemTransfer get(long id)
        {
            SystemTransfer systemTransferRet = new SystemTransfer();

            try
            {
                SystemEntity systemEntityRet = _systemData.get(id);

                if (systemEntityRet == null) {
                    systemTransferRet.addMessage("Nenhum registro encontrado");
                } else {
                    systemTransferRet.item = new SystemModel(systemEntityRet);
                }
            }
            catch (ArgumentException ex)
            {
                systemTransferRet = new SystemTransfer();
                systemTransferRet.valid = false;
                systemTransferRet.error = true;
                systemTransferRet.addMessage(ex.Message);
            }

            return systemTransferRet;
        }

        public SystemTransfer insert(SystemTransfer systemTransfer)
        {
            SystemTransfer systemTransferRet;

            try
            {
                SystemEntity entity = _systemData.insert(systemTransfer.item.toEntity());

                _systemData.save();

                systemTransferRet = new SystemTransfer();
                systemTransferRet.item = new SystemModel(entity);
            }
            catch (ArgumentException ex)
            {
                systemTransferRet = new SystemTransfer();
                systemTransferRet.valid = false;
                systemTransferRet.error = true;
                systemTransferRet.addMessage(ex.Message);
            }

            return systemTransferRet;
        }

        public SystemTransfer update(SystemTransfer systemTransfer)
        {
            throw new System.NotImplementedException();
        }

        public SystemTransfer delete(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}
