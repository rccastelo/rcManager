using rcManagerPermissionDomain.Entities;
using rcManagerPermissionDomain.Models;
using rcManagerPermissionRepository.Interfaces;
using System.Collections.Generic;

namespace rcManagerPermissionRepository.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly IPermissionData _permissionData;

        public PermissionRepository(IPermissionData permissionData)
        {
            this._permissionData = permissionData;
        }

        public PermissionModel Get(long id)
        {
            PermissionModel modelRet = new PermissionModel();

            PermissionEntity entity = _permissionData.Get(id);

            if (entity != null) {
                modelRet = new PermissionModel(entity);
                modelRet.IsValidResponse = true;
            } else {
                modelRet.IsValidResponse = false;
                modelRet.AddMessage("Permissão não encontrada.");
            }

            return modelRet;
        }

        public PermissionModel List()
        {
            PermissionModel modelRet = new PermissionModel();

            IList<PermissionEntity> listEntity = _permissionData.List();

            if ((listEntity != null) && (listEntity.Count > 0)) {
                modelRet.IsValidResponse = true;
                modelRet.AddEntities(listEntity);
            } else {
                modelRet.IsValidResponse = true; 
                modelRet.AddMessage("Nenhum registro encontrado.");
            }

            return modelRet;
        }

        public PermissionModel Insert(PermissionModel model)
        {
            PermissionModel modelRet = null;

            model.Entity.Id = 0;
            PermissionEntity entity = _permissionData.Insert(model.Entity);

            if ((entity != null) && (entity.Id > 0)) {
                modelRet = new PermissionModel(entity);
                modelRet.IsValidResponse = true;
                modelRet.AddMessage("Permissão incluída com sucesso.");
            } else {
                modelRet = new PermissionModel(model);
                modelRet.IsValidResponse = false;
                modelRet.AddMessage("Não foi possível incluir a Permissão.");
            }

            return modelRet;
        }

        public PermissionModel Update(PermissionModel model)
        {
            PermissionModel modelRet = null;

            PermissionModel exist = this.Get(model.Entity.Id);

            if (exist != null) {
                PermissionEntity entity = _permissionData.Update(model.Entity);

                if (entity != null) {
                    modelRet = new PermissionModel(entity);
                    modelRet.IsValidResponse = true;
                    modelRet.AddMessage("Permissão alterada com sucesso.");
                } else {
                    modelRet = new PermissionModel(model);
                    modelRet.IsValidResponse = false;
                    modelRet.AddMessage("Não foi possível alterar a Permissão.");
                }
            } else {
                modelRet = new PermissionModel(model);
                modelRet.IsValidResponse = false;
                modelRet.AddMessage("Permissão não encontrada para alteração.");
            }

            return modelRet;
        }

        public PermissionModel Delete(long id)
        {
            PermissionModel modelRet = null;

            PermissionModel exist = this.Get(id);

            if ((exist != null) && (exist.IsValidResponse)) {
                PermissionEntity entity = _permissionData.Delete(exist.Entity);

                if (entity != null) {
                    modelRet = new PermissionModel(entity);
                    modelRet.IsValidResponse = true;
                    modelRet.AddMessage("Permissão excluída com sucesso.");
                } else {
                    modelRet = new PermissionModel();
                    modelRet.IsValidResponse = false;
                    modelRet.AddMessage("Não foi possível excluir a Permissão.");
                }
            } else {
                modelRet = new PermissionModel();
                modelRet.IsValidResponse = false;
                modelRet.AddMessage("Permissão não encontrada para exclusão.");
            }

            return modelRet;
        }
    }
}
