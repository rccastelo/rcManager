using rcManagerSystemApplication.Interfaces;
using rcManagerSystemDomain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace rcManagerSystemApplication.Application
{
    public class SystemService : ISystemService
    {
        private readonly ISystemData _systemData;

        public SystemService(ISystemData systemData)
        {
            this._systemData = systemData;
        }

        public SystemTransfer List(SystemTransfer systemTransfer)
        {
            SystemTransfer systemTransferRet = new SystemTransfer();

            try {
                IList<SystemEntity> listRet = _systemData.List();

                if ((listRet != null)  && (listRet.Count > 0)) {
                    systemTransferRet.List = listRet.Select(et => new SystemModel(et)).ToList(); 
                } else {
                    systemTransferRet.AddMessage("Nenhum registro encontrado");
                }
            } catch (ArgumentException ex) {
                systemTransferRet.Valid = false;
                systemTransferRet.Error = true;
                systemTransferRet.AddMessage(ex.Message);
            }

            return systemTransferRet;
        }

        public SystemTransfer Get(long id)
        {
            SystemTransfer systemTransferRet = new SystemTransfer();

            try {
                SystemEntity systemEntityRet = _systemData.Get(id);

                if (systemEntityRet == null) {
                    systemTransferRet.AddMessage("Registro não encontrado");
                } else {
                    systemTransferRet.Item = new SystemModel(systemEntityRet);
                }
            } catch (ArgumentException ex) {
                systemTransferRet.Valid = false;
                systemTransferRet.Error = true;
                systemTransferRet.AddMessage(ex.Message);
            }

            return systemTransferRet;
        }

        public SystemTransfer Insert(SystemTransfer systemTransfer)
        {
            SystemTransfer systemTransferRet = new SystemTransfer();

            try {
                SystemEntity entity = _systemData.Insert(systemTransfer.Item.toEntity());

                _systemData.Save();

                systemTransferRet.Item = new SystemModel(entity);
            } catch (ArgumentException ex) {
                systemTransferRet.Valid = false;
                systemTransferRet.Error = true;
                systemTransferRet.AddMessage(ex.Message);
            }

            return systemTransferRet;
        }

        public SystemTransfer Update(SystemTransfer systemTransfer)
        {
            SystemTransfer systemTransferRet = new SystemTransfer();

            try {
                SystemEntity entity = _systemData.Update(systemTransfer.Item.toEntity());

                _systemData.Save();

                systemTransferRet.Item = new SystemModel(entity);
            } catch (ArgumentException ex) {
                systemTransferRet.Valid = false;
                systemTransferRet.Error = true;
                systemTransferRet.AddMessage(ex.Message);
            }

            return systemTransferRet;
        }

        public SystemTransfer Delete(long id)
        {
            SystemTransfer systemTransferRet = new SystemTransfer();

            try {
                SystemEntity entityExist = _systemData.Get(id);

                if (entityExist != null) {
                    SystemEntity entity = _systemData.Delete(entityExist);

                    _systemData.Save();

                    systemTransferRet.Item = new SystemModel(entity);
                } else {
                    systemTransferRet.AddMessage("Registro não encontrado");
                }
            } catch (ArgumentException ex) {
                systemTransferRet.Valid = false;
                systemTransferRet.Error = true;
                systemTransferRet.AddMessage(ex.Message);
            }

            return systemTransferRet;
        }
    }
}
