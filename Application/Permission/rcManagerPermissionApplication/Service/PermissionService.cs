using rcManagerPermissionApplication.Interfaces;
using rcManagerPermissionApplication.Transport;
using rcManagerPermissionDomain;
using rcManagerPermissionRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace rcManagerPermissionApplication.Service
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _repository;

        public PermissionService(IPermissionRepository repository)
        {
            this._repository = repository;
        }

        public PermissionResponse List(PermissionRequest permissionRequest)
        {
            PermissionResponse permissionResponseRet = new PermissionResponse();

            try {
                IList<PermissionModel> listRet = _repository.List();

                if ((listRet != null) && (listRet.Count > 0)) {
                    permissionResponseRet.List = listRet.Select(et => new PermissionEntity(et)).ToList();
                } else {
                    permissionResponseRet.AddMessage("Nenhum registro encontrado");
                }
            } catch (ArgumentException ex) {
                permissionResponseRet.IsValid = false;
                permissionResponseRet.Error = true;
                permissionResponseRet.AddMessage(ex.Message);
            }

            return permissionResponseRet;
        }

        public PermissionResponse Get(long id)
        {
            PermissionResponse permissionResponseRet = new PermissionResponse();

            try {
                PermissionModel permissionModelRet = _repository.Get(id);

                if (permissionModelRet == null) {
                    permissionResponseRet.AddMessage("Registro não encontrado");
                } else {
                    permissionResponseRet.Item = permissionModelRet;
                }
            } catch (ArgumentException ex) {
                permissionResponseRet.IsValid = false;
                permissionResponseRet.Error = true;
                permissionResponseRet.AddMessage(ex.Message);
            }

            return permissionResponseRet;
        }

        public PermissionResponse Insert(PermissionRequest permissionRequest)
        {
            PermissionResponse permissionResponseRet = new PermissionResponse();

            try {
                PermissionModel req = new PermissionModel(permissionRequest);

                PermissionModel model = _repository.Insert(req);

                permissionResponseRet.Item = model.toEntity();
            } catch (ArgumentException ex) {
                permissionResponseRet.IsValid = false;
                permissionResponseRet.Error = true;
                permissionResponseRet.AddMessage(ex.Message);
            }

            return permissionResponseRet;
        }

        public PermissionResponse Update(PermissionRequest permissionRequest)
        {
            PermissionResponse permissionResponseRet = new PermissionResponse();

            try {
                PermissionModel req = new PermissionModel(permissionRequest);

                PermissionModel model = _repository.Update(req);

                permissionResponseRet.Item = model.toEntity();
            }
            catch (ArgumentException ex) {
                permissionResponseRet.IsValid = false;
                permissionResponseRet.Error = true;
                permissionResponseRet.AddMessage(ex.Message);
            }

            return permissionResponseRet;
        }

        public PermissionResponse Delete(long id)
        {
            PermissionResponse permissionResponseRet = new PermissionResponse();

            try {
                PermissionEntity entityExist = _repository.Get(id);

                if (entityExist != null) {
                    PermissionModel req = new PermissionModel(entityExist);

                    PermissionModel model = _repository.Delete(req);

                    permissionResponseRet.Item = model.toEntity();
                } else {
                    permissionResponseRet.AddMessage("Registro não encontrado");
                }
            } catch (ArgumentException ex) {
                permissionResponseRet.IsValid = false;
                permissionResponseRet.Error = true;
                permissionResponseRet.AddMessage(ex.Message);
            }

            return permissionResponseRet;
        }
    }
}
