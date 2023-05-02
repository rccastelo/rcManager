using rcManagerPermissionApplication.Interfaces;
using rcManagerPermissionDomain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace rcManagerPermissionApplication.Application
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionData _permissionData;

        public PermissionService(IPermissionData permissionData)
        {
            this._permissionData = permissionData;
        }

        public PermissionTransfer List(PermissionTransfer permissionTransfer)
        {
            PermissionTransfer permissionTransferRet = new PermissionTransfer();

            try {
                IList<PermissionEntity> listRet = _permissionData.List();

                if ((listRet != null) && (listRet.Count > 0)) {
                    permissionTransferRet.List = listRet.Select(et => new PermissionModel(et)).ToList();
                } else {
                    permissionTransferRet.AddMessage("Nenhum registro encontrado");
                }
            } catch (ArgumentException ex) {
                permissionTransferRet.Valid = false;
                permissionTransferRet.Error = true;
                permissionTransferRet.AddMessage(ex.Message);
            }

            return permissionTransferRet;
        }

        public PermissionTransfer Get(long id)
        {
            PermissionTransfer permissionTransferRet = new PermissionTransfer();

            try {
                PermissionEntity permissionEntityRet = _permissionData.Get(id);

                if (permissionEntityRet == null) {
                    permissionTransferRet.AddMessage("Registro não encontrado");
                } else {
                    permissionTransferRet.Item = new PermissionModel(permissionEntityRet);
                }
            } catch (ArgumentException ex) {
                permissionTransferRet.Valid = false;
                permissionTransferRet.Error = true;
                permissionTransferRet.AddMessage(ex.Message);
            }

            return permissionTransferRet;
        }

        public PermissionTransfer Insert(PermissionTransfer permissionTransfer)
        {
            PermissionTransfer permissionTransferRet = new PermissionTransfer();

            try {
                PermissionEntity entity = _permissionData.Insert(permissionTransfer.Item.toEntity());

                _permissionData.Save();

                permissionTransferRet.Item = new PermissionModel(entity);
            } catch (ArgumentException ex) {
                permissionTransferRet.Valid = false;
                permissionTransferRet.Error = true;
                permissionTransferRet.AddMessage(ex.Message);
            }

            return permissionTransferRet;
        }

        public PermissionTransfer Update(PermissionTransfer permissionTransfer)
        {
            PermissionTransfer permissionTransferRet = new PermissionTransfer();

            try {
                PermissionEntity entity = _permissionData.Update(permissionTransfer.Item.toEntity());

                _permissionData.Save();

                permissionTransferRet.Item = new PermissionModel(entity);
            } catch (ArgumentException ex) {
                permissionTransferRet.Valid = false;
                permissionTransferRet.Error = true;
                permissionTransferRet.AddMessage(ex.Message);
            }

            return permissionTransferRet;
        }

        public PermissionTransfer Delete(long id)
        {
            PermissionTransfer permissionTransferRet = new PermissionTransfer();

            try {
                PermissionEntity entityExist = _permissionData.Get(id);

                if (entityExist != null) {
                    PermissionEntity entity = _permissionData.Delete(entityExist);

                    _permissionData.Save();

                    permissionTransferRet.Item = new PermissionModel(entity);
                } else {
                    permissionTransferRet.AddMessage("Registro não encontrado");
                }
            } catch (ArgumentException ex) {
                permissionTransferRet.Valid = false;
                permissionTransferRet.Error = true;
                permissionTransferRet.AddMessage(ex.Message);
            }

            return permissionTransferRet;
        }
    }
}
