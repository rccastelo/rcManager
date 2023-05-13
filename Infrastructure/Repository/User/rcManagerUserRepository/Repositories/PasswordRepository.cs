using rcManagerUserDomain.Entities;
using rcManagerUserDomain.Models;
using rcManagerUserRepository.Interfaces;
using System.Collections.Generic;

namespace rcManagerUserRepository.Repositories
{
    class PasswordRepository : IPasswordRepository
    {
        private readonly IPasswordData _passwordData;

        public PasswordRepository(IPasswordData passwordData)
        {
            this._passwordData = passwordData;
        }

        public PasswordModel Get(long id)
        {
            PasswordModel modelRet = new PasswordModel();

            PasswordEntity entity = _passwordData.Get(id);

            if (entity != null) {
                modelRet = new PasswordModel(entity);
                modelRet.IsValidResponse = true;
            } else {
                modelRet.IsValidResponse = false;
                modelRet.AddMessage("Senha não encontrada.");
            }

            return modelRet;
        }

        public PasswordModel List()
        {
            PasswordModel modelRet = new PasswordModel();

            IList<PasswordEntity> listEntity = _passwordData.List();

            if ((listEntity != null) && (listEntity.Count > 0)) {
                modelRet.IsValidResponse = true;
                modelRet.AddEntities(listEntity);
            } else {
                modelRet.IsValidResponse = true;
                modelRet.AddMessage("Nenhum registro encontrado.");
            }

            return modelRet;
        }

        public PasswordModel Insert(PasswordModel model)
        {
            PasswordModel modelRet = null;

            model.Entity.Id = 0;
            PasswordEntity entity = _passwordData.Insert(model.Entity);

            if ((entity != null) && (entity.Id > 0)) {
                modelRet = new PasswordModel(entity);
                modelRet.IsValidResponse = true;
                modelRet.AddMessage("Senha incluída com sucesso.");
            } else {
                modelRet = new PasswordModel(model);
                modelRet.IsValidResponse = false;
                modelRet.AddMessage("Não foi possível incluir a Senha.");
            }

            return modelRet;
        }

        public PasswordModel Update(PasswordModel model)
        {
            PasswordModel modelRet = null;

            PasswordModel exist = this.Get(model.Entity.Id);

            if (exist != null) {
                PasswordEntity entity = _passwordData.Update(model.Entity);

                if (entity != null) {
                    modelRet = new PasswordModel(entity);
                    modelRet.IsValidResponse = true;
                    modelRet.AddMessage("Senha alterada com sucesso.");
                } else {
                    modelRet = new PasswordModel(model);
                    modelRet.IsValidResponse = false;
                    modelRet.AddMessage("Não foi possível alterar a Senha.");
                }
            } else {
                modelRet = new PasswordModel(model);
                modelRet.IsValidResponse = false;
                modelRet.AddMessage("Senha não encontrada para alteração.");
            }

            return modelRet;
        }

        public PasswordModel Delete(long id)
        {
            PasswordModel modelRet = null;

            PasswordModel exist = this.Get(id);

            if ((exist != null) && (exist.IsValidResponse)) {
                PasswordEntity entity = _passwordData.Delete(exist.Entity);

                if (entity != null) {
                    modelRet = new PasswordModel(entity);
                    modelRet.IsValidResponse = true;
                    modelRet.AddMessage("Senha excluída com sucesso.");
                } else {
                    modelRet = new PasswordModel();
                    modelRet.IsValidResponse = false;
                    modelRet.AddMessage("Não foi possível excluir a Senha.");
                }
            } else {
                modelRet = new PasswordModel();
                modelRet.IsValidResponse = false;
                modelRet.AddMessage("Senha não encontrada para exclusão.");
            }

            return modelRet;
        }
    }
}
