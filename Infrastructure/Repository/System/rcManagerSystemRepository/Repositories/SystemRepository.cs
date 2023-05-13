using rcManagerSystemDomain.Entities;
using rcManagerSystemDomain.Models;
using rcManagerSystemRepository.Interfaces;
using System.Collections.Generic;

namespace rcManagerSystemRepository.Repositories
{
    public class SystemRepository : ISystemRepository
    {
        private readonly ISystemData _systemData;

        public SystemRepository(ISystemData systemData)
        {
            this._systemData = systemData;
        }

        public SystemModel Get(long id)
        {
            SystemModel modelRet = new SystemModel();

            SystemEntity entity = _systemData.Get(id);

            if (entity != null) {
                modelRet = new SystemModel(entity);
                modelRet.IsValidResponse = true;
            } else {
                modelRet.IsValidResponse = false;
                modelRet.AddMessage("Sistema não encontrado.");
            }

            return modelRet;
        }

        public SystemModel List()
        {
            SystemModel modelRet = new SystemModel();

            IList<SystemEntity> listEntity = _systemData.List();

            if ((listEntity != null) && (listEntity.Count > 0)) {
                modelRet.IsValidResponse = true; 
                modelRet.AddEntities(listEntity);
            } else {
                modelRet.IsValidResponse = true;
                modelRet.AddMessage("Nenhum registro encontrado.");
            }

            return modelRet;
        }

        public SystemModel Insert(SystemModel model)
        {
            SystemModel modelRet = null;

            model.Entity.Id = 0;
            SystemEntity entity = _systemData.Insert(model.Entity);

            if ((entity != null) && (entity.Id > 0)) {
                modelRet = new SystemModel(entity);
                modelRet.IsValidResponse = true;
                modelRet.AddMessage("Sistema incluído com sucesso.");
            } else {
                modelRet = new SystemModel(model);
                modelRet.IsValidResponse = false;
                modelRet.AddMessage("Não foi possível incluir o Sistema.");
            }

            return modelRet;
        }

        public SystemModel Update(SystemModel model)
        {
            SystemModel modelRet = null;

            SystemModel exist = this.Get(model.Entity.Id);

            if (exist != null) {
                SystemEntity entity = _systemData.Update(model.Entity);

                if (entity != null) {
                    modelRet = new SystemModel(entity);
                    modelRet.IsValidResponse = true;
                    modelRet.AddMessage("Sistema alterado com sucesso.");
                } else {
                    modelRet = new SystemModel(model);
                    modelRet.IsValidResponse = false;
                    modelRet.AddMessage("Não foi possível alterar o Sistema.");
                }
            } else {
                modelRet = new SystemModel(model);
                modelRet.IsValidResponse = false;
                modelRet.AddMessage("Sistema não encontrado para alteração.");
            }

            return modelRet;
        }

        public SystemModel Delete(long id)
        {
            SystemModel modelRet = null;

            SystemModel exist = this.Get(id);

            if ((exist != null) && (exist.IsValidResponse)) {
                SystemEntity entity = _systemData.Delete(exist.Entity);

                if (entity != null) {
                    modelRet = new SystemModel(entity);
                    modelRet.IsValidResponse = true;
                    modelRet.AddMessage("Sistema excluído com sucesso.");
                } else {
                    modelRet = new SystemModel();
                    modelRet.IsValidResponse = false;
                    modelRet.AddMessage("Não foi possível excluir o Sistema.");
                }
            } else {
                modelRet = new SystemModel();
                modelRet.IsValidResponse = false;
                modelRet.AddMessage("Sistema não encontrado para exclusão.");
            }

            return modelRet;
        }
    }
}
