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

        public SystemService(ISystemData systemData)
        {
            this._systemData = systemData;
        }

        public SystemTransfer list(SystemTransfer systemTransfer)
        {
            SystemTransfer systemTransferRet = new SystemTransfer();

            try {
                IList<SystemEntity> listRet = _systemData.list();

                if ((listRet != null)  && (listRet.Count > 0)) {
                    systemTransferRet.list = listRet.Select(et => new SystemModel(et)).ToList(); 
                } else {
                    systemTransferRet.addMessage("Nenhum registro encontrado");
                }
            } catch (ArgumentException ex) {
                systemTransferRet.valid = false;
                systemTransferRet.error = true;
                systemTransferRet.addMessage(ex.Message);
            }

            return systemTransferRet;
        }

        public SystemTransfer get(long id)
        {
            SystemTransfer systemTransferRet = new SystemTransfer();

            try {
                SystemEntity systemEntityRet = _systemData.get(id);

                if (systemEntityRet == null) {
                    systemTransferRet.addMessage("Registro não encontrado");
                } else {
                    systemTransferRet.item = new SystemModel(systemEntityRet);
                }
            } catch (ArgumentException ex) {
                systemTransferRet.valid = false;
                systemTransferRet.error = true;
                systemTransferRet.addMessage(ex.Message);
            }

            return systemTransferRet;
        }

        public SystemTransfer insert(SystemTransfer systemTransfer)
        {
            SystemTransfer systemTransferRet = new SystemTransfer();

            try {
                SystemEntity entity = _systemData.insert(systemTransfer.item.toEntity());

                _systemData.save();

                systemTransferRet.item = new SystemModel(entity);
            } catch (ArgumentException ex) {
                systemTransferRet.valid = false;
                systemTransferRet.error = true;
                systemTransferRet.addMessage(ex.Message);
            }

            return systemTransferRet;
        }

        public SystemTransfer update(SystemTransfer systemTransfer)
        {
            SystemTransfer systemTransferRet = new SystemTransfer();

            try {
                SystemEntity entity = _systemData.update(systemTransfer.item.toEntity());

                _systemData.save();

                systemTransferRet.item = new SystemModel(entity);
            } catch (ArgumentException ex) {
                systemTransferRet.valid = false;
                systemTransferRet.error = true;
                systemTransferRet.addMessage(ex.Message);
            }

            return systemTransferRet;
        }

        public SystemTransfer delete(long id)
        {
            SystemTransfer systemTransferRet = new SystemTransfer();

            try {
                SystemEntity entityExist = _systemData.get(id);

                if (entityExist != null) {
                    SystemEntity entity = _systemData.delete(entityExist);

                    _systemData.save();

                    systemTransferRet.item = new SystemModel(entity);
                } else {
                    systemTransferRet.addMessage("Registro não encontrado");
                }
            } catch (ArgumentException ex) {
                systemTransferRet.valid = false;
                systemTransferRet.error = true;
                systemTransferRet.addMessage(ex.Message);
            }

            return systemTransferRet;
        }
    }
}
