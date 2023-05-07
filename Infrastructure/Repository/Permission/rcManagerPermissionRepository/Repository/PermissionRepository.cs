using rcManagerPermissionDomain;
using rcManagerPermissionRepository.Interfaces;
using System.Collections.Generic;
using System.Linq;

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
            PermissionModel modelRet = null;

            PermissionEntity entity = _permissionData.Get(id);

            if (entity != null) {
                modelRet = new PermissionModel(entity);
            } else {
                modelRet = new PermissionModel() {
                    IsValid = false
                };

                modelRet.AddMessage("Permissão não encontrada.");
            }

            return modelRet;
        }

        public IList<PermissionModel> List()
        {
            IList<PermissionModel> listRet = null;

            IList<PermissionEntity> listEntity = _permissionData.List();

            if ((listEntity != null) && (listEntity.Count > 0)) {
                listRet = listEntity.Select(et => new PermissionModel(et)).ToList();
            }

            return listRet;
        }

        public PermissionModel Insert(PermissionModel model)
        {
            PermissionModel modelRet = null;

            PermissionEntity entity = _permissionData.Insert(model.ToEntity());

            _permissionData.Save();

            if ((entity != null) && (entity.Id > 0)) {
                modelRet = new PermissionModel(entity);
                modelRet.AddMessage("Permissão incluída com sucesso.");
            }
            else
            {
                modelRet = new PermissionModel(model);
                modelRet.IsValid = false;
                modelRet.AddMessage("Não foi possível incluir a Permissão.");
            }

            return modelRet;
        }

        public PermissionModel Update(PermissionModel model)
        {
            PermissionModel modelRet = null;

            PermissionModel exist = this.Get(model.Id);

            if (exist != null) {
                PermissionEntity entity = _permissionData.Update(model.ToEntity());

                _permissionData.Save();

                if (entity != null) {
                    modelRet = new PermissionModel(entity);

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

            if (exist != null) {
                PermissionEntity entity = _permissionData.Delete(exist.ToEntity());

                _permissionData.Save();

                if (entity != null) {
                    modelRet = new PermissionModel(entity);
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
