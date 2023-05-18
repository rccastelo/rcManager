using rcManagerUserDomain.Entities;
using rcManagerUserDomain.Models;
using rcManagerUserRepository.Interfaces;
using System.Collections.Generic;

namespace rcManagerUserRepository.Repositories
{
    class LoginRepository : ILoginRepository
    {
        private readonly ILoginData _loginData;

        public LoginRepository(ILoginData loginData)
        {
            this._loginData = loginData;
        }

        public LoginModel Get(long id)
        {
            LoginModel modelRet = new LoginModel();

            LoginEntity entity = _loginData.Get(id);

            if (entity != null) {
                modelRet = new LoginModel(entity);
                modelRet.IsValidResponse = true;
            } else {
                modelRet.IsValidResponse = false;
                modelRet.AddMessage("Login não encontrado.");
            }

            return modelRet;
        }

        public LoginModel List()
        {
            LoginModel modelRet = new LoginModel();

            IList<LoginEntity> listEntity = _loginData.List();

            if ((listEntity != null) && (listEntity.Count > 0)) {
                modelRet.IsValidResponse = true;
                modelRet.AddEntities(listEntity);
            } else {
                modelRet.IsValidResponse = true;
                modelRet.AddMessage("Nenhum registro encontrado.");
            }

            return modelRet;
        }

        public LoginModel Insert(LoginModel model)
        {
            LoginModel modelRet = null;

            LoginEntity loginExist = _loginData.GetByLogin(model.Entity.Login);

            if (loginExist == null) {
                model.Entity.Id = 0;
                LoginEntity entity = _loginData.Insert(model.Entity);

                if ((entity != null) && (entity.Id > 0)) {
                    modelRet = new LoginModel(entity);
                    modelRet.IsValidResponse = true;
                    modelRet.AddMessage("Login incluído com sucesso.");
                } else {
                    modelRet = new LoginModel(model);
                    modelRet.IsValidResponse = false;
                    modelRet.AddMessage("Não foi possível incluir o Login.");
                }
            } else {
                modelRet = new LoginModel(model);
                modelRet.IsValidResponse = false;
                modelRet.AddMessage("O Login informado já existe.");
            }

            return modelRet;
        }

        public LoginModel Update(LoginModel model)
        {
            LoginModel modelRet = null;

            LoginEntity existLogin = _loginData.Get(model.Entity.Id);

            if (existLogin != null) {
                LoginEntity newLogin = _loginData.GetByLogin(model.Entity.Login);

                if ((newLogin == null) || ((newLogin != null) && (newLogin.Id == model.Entity.Id))) {
                    LoginEntity entity = _loginData.Update(model.Entity);

                    if (entity != null) {
                        modelRet = new LoginModel(entity);
                        modelRet.IsValidResponse = true;
                        modelRet.AddMessage("Login alterado com sucesso.");
                    } else {
                        modelRet = new LoginModel(model);
                        modelRet.IsValidResponse = false;
                        modelRet.AddMessage("Não foi possível alterar o Login.");
                    }
                } else {
                    modelRet = new LoginModel(model);
                    modelRet.IsValidResponse = false;
                    modelRet.AddMessage("O Login informado já existe.");
                }
            } else {
                modelRet = new LoginModel(model);
                modelRet.IsValidResponse = false;
                modelRet.AddMessage("Login não encontrado para alteração.");
            }

            return modelRet;
        }

        public LoginModel Delete(long id)
        {
            LoginModel modelRet = null;

            LoginEntity existLogin = _loginData.Get(id);

            if (existLogin != null) {
                LoginEntity entity = _loginData.Delete(existLogin);

                if (entity != null) {
                    modelRet = new LoginModel(entity);
                    modelRet.IsValidResponse = true;
                    modelRet.AddMessage("Login excluído com sucesso.");
                } else {
                    modelRet = new LoginModel();
                    modelRet.IsValidResponse = false;
                    modelRet.AddMessage("Não foi possível excluir o Login.");
                }
            } else {
                modelRet = new LoginModel();
                modelRet.IsValidResponse = false;
                modelRet.AddMessage("Login não encontrado para exclusão.");
            }

            return modelRet;
        }
    }
}
