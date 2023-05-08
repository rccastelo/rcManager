using rcManagerPermissionDomain;
using rcManagerPermissionRepository.Interfaces;
using System.Collections.Generic;

namespace rcManagerPermissionRepository.Repository
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
                modelRet.IsValid = true;
            } else {
                modelRet.IsValid = false;
                modelRet.AddMessage("Permissão não encontrada.");
            }

            return modelRet;
        }

        public PermissionModel List()
        {
            PermissionModel modelRet = new PermissionModel();

            IList<PermissionEntity> listEntity = _permissionData.List();

            if ((listEntity != null) && (listEntity.Count > 0)) {
                modelRet.IsValid = true;
                modelRet.AddEntities(listEntity);
            } else {
                modelRet.IsValid = true; 
                modelRet.AddMessage("Nenhum registro encontrado.");
            }

            return modelRet;
        }

        public PermissionModel Insert(PermissionModel model)
        {
            PermissionModel modelRet = null;

            PermissionEntity entity = _permissionData.Insert(model.Item);

            _permissionData.Save();

            if ((entity != null) && (entity.Id > 0)) {
                modelRet = new PermissionModel(entity);
                modelRet.IsValid = true;
                modelRet.AddMessage("Permissão incluída com sucesso.");
            } else {
                modelRet = new PermissionModel(model);
                modelRet.IsValid = false;
                modelRet.AddMessage("Não foi possível incluir a Permissão.");
            }

            return modelRet;
        }

        public PermissionModel Update(PermissionModel model)
        {
            PermissionModel modelRet = null;

            PermissionModel exist = this.Get(model.Item.Id);

            if (exist != null) {
                PermissionEntity entity = _permissionData.Update(model.Item);

                _permissionData.Save();

                if (entity != null) {
                    modelRet = new PermissionModel(entity);
                    modelRet.IsValid = true;
                    modelRet.AddMessage("Permissão alterada com sucesso.");
                } else {
                    modelRet = new PermissionModel(model);
                    modelRet.IsValid = false;
                    modelRet.AddMessage("Não foi possível alterar a Permissão.");
                }
            } else {
                modelRet = new PermissionModel(model);
                modelRet.IsValid = false;
                modelRet.AddMessage("Permissão não encontrada para alteração.");
            }

            return modelRet;
        }

        public PermissionModel Delete(long id)
        {
            PermissionModel modelRet = null;

            PermissionModel exist = this.Get(id);

            if ((exist != null) && (exist.IsValid)) {
                PermissionEntity entity = _permissionData.Delete(exist.Item);

                _permissionData.Save();

                if (entity != null) {
                    modelRet = new PermissionModel(entity);
                    modelRet.IsValid = true;
                    modelRet.AddMessage("Permissão excluída com sucesso.");
                } else {
                    modelRet = new PermissionModel();
                    modelRet.IsValid = false;
                    modelRet.AddMessage("Não foi possível excluir a Permissão.");
                }
            } else {
                modelRet = new PermissionModel();
                modelRet.IsValid = false;
                modelRet.AddMessage("Permissão não encontrada para exclusão.");
            }

            return modelRet;
        }
    }
}
