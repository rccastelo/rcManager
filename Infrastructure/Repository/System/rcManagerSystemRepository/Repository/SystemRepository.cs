using rcManagerSystemDomain;
using rcManagerSystemRepository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace rcManagerSystemRepository.Repository
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
            SystemModel modelRet = null;

            SystemEntity entity = _systemData.Get(id);

            if (entity != null) {
                modelRet = new SystemModel(entity);
            } else {
                modelRet = new SystemModel() {
                    IsValid = false
                };

                modelRet.AddMessage("Sistema não encontrado.");
            }

            return modelRet;
        }

        public IList<SystemModel> List()
        {
            IList<SystemModel> listRet = null;

            IList<SystemEntity> listEntity = _systemData.List();

            if ((listEntity != null) && (listEntity.Count > 0)) {
                listRet = listEntity.Select(et => new SystemModel(et)).ToList();
            }

            return listRet;
        }

        public SystemModel Insert(SystemModel model)
        {
            SystemModel modelRet = null;

            SystemEntity entity = _systemData.Insert(model.ToEntity());

            _systemData.Save();

            if ((entity != null) && (entity.Id > 0)) {
                modelRet = new SystemModel(entity);
                modelRet.AddMessage("Sistema incluído com sucesso.");
            } else {
                modelRet = new SystemModel(model);
                modelRet.IsValid = false;
                modelRet.AddMessage("Não foi possível incluir o Sistema.");
            }

            return modelRet;
        }

        public SystemModel Update(SystemModel model)
        {
            SystemModel modelRet = null;

            SystemModel exist = this.Get(model.Id);

            if (exist != null) {
                SystemEntity entity = _systemData.Update(model.ToEntity());

                _systemData.Save();

                if (entity != null) {
                    modelRet = new SystemModel(entity);

                    modelRet.AddMessage("Sistema alterado com sucesso.");
                } else {
                    modelRet = new SystemModel(model);
                    modelRet.IsValid = false;
                    modelRet.AddMessage("Não foi possível alterar o Sistema.");
                }
            } else {
                modelRet = new SystemModel(model);
                modelRet.IsValid = false;
                modelRet.AddMessage("Sistema não encontrado para alteração.");
            }

            return modelRet;
        }

        public SystemModel Delete(long id)
        {
            SystemModel modelRet = null;

            SystemModel exist = this.Get(id);

            if (exist != null) {
                SystemEntity entity = _systemData.Delete(exist.ToEntity());

                _systemData.Save();

                if (entity != null) {
                    modelRet = new SystemModel(entity);
                    modelRet.AddMessage("Sistema excluído com sucesso.");
                } else {
                    modelRet = new SystemModel();
                    modelRet.IsValid = false;
                    modelRet.AddMessage("Não foi possível excluir o Sistema.");
                }
            } else {
                modelRet = new SystemModel();
                modelRet.IsValid = false;
                modelRet.AddMessage("Sistema não encontrado para exclusão.");
            }

            return modelRet;
        }
    }
}
