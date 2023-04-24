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
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionData _permissionData;

        public PermissionService(IPermissionData permissionData)
        {
            this._permissionData = permissionData;
        }

        public PermissionTransfer list(PermissionTransfer permissionTransfer)
        {
            PermissionTransfer permissionTransferRet = new PermissionTransfer();

            try {
                IList<PermissionEntity> listRet = _permissionData.list();

                if ((listRet != null) && (listRet.Count > 0)) {
                    permissionTransferRet.list = listRet.Select(et => new PermissionModel(et)).ToList();
                } else {
                    permissionTransferRet.addMessage("Nenhum registro encontrado");
                }
            } catch (ArgumentException ex) {
                permissionTransferRet.valid = false;
                permissionTransferRet.error = true;
                permissionTransferRet.addMessage(ex.Message);
            }

            return permissionTransferRet;
        }

        public PermissionTransfer get(long id)
        {
            PermissionTransfer permissionTransferRet = new PermissionTransfer();

            try {
                PermissionEntity permissionEntityRet = _permissionData.get(id);

                if (permissionEntityRet == null) {
                    permissionTransferRet.addMessage("Registro não encontrado");
                } else {
                    permissionTransferRet.item = new PermissionModel(permissionEntityRet);
                }
            } catch (ArgumentException ex) {
                permissionTransferRet.valid = false;
                permissionTransferRet.error = true;
                permissionTransferRet.addMessage(ex.Message);
            }

            return permissionTransferRet;
        }

        public PermissionTransfer insert(PermissionTransfer permissionTransfer)
        {
            PermissionTransfer permissionTransferRet = new PermissionTransfer();

            try {
                PermissionEntity entity = _permissionData.insert(permissionTransfer.item.toEntity());

                _permissionData.save();

                permissionTransferRet.item = new PermissionModel(entity);
            } catch (ArgumentException ex) {
                permissionTransferRet.valid = false;
                permissionTransferRet.error = true;
                permissionTransferRet.addMessage(ex.Message);
            }

            return permissionTransferRet;
        }

        public PermissionTransfer update(PermissionTransfer permissionTransfer)
        {
            PermissionTransfer permissionTransferRet = new PermissionTransfer();

            try {
                PermissionEntity entity = _permissionData.update(permissionTransfer.item.toEntity());

                _permissionData.save();

                permissionTransferRet.item = new PermissionModel(entity);
            } catch (ArgumentException ex) {
                permissionTransferRet.valid = false;
                permissionTransferRet.error = true;
                permissionTransferRet.addMessage(ex.Message);
            }

            return permissionTransferRet;
        }

        public PermissionTransfer delete(long id)
        {
            PermissionTransfer permissionTransferRet = new PermissionTransfer();

            try {
                PermissionEntity entityExist = _permissionData.get(id);

                if (entityExist != null) {
                    PermissionEntity entity = _permissionData.delete(entityExist);

                    _permissionData.save();

                    permissionTransferRet.item = new PermissionModel(entity);
                } else {
                    permissionTransferRet.addMessage("Registro não encontrado");
                }
            } catch (ArgumentException ex) {
                permissionTransferRet.valid = false;
                permissionTransferRet.error = true;
                permissionTransferRet.addMessage(ex.Message);
            }

            return permissionTransferRet;
        }
    }
}
