using rcManagerUserDomain;
using rcManagerUserRepository.Interfaces;
using System.Collections.Generic;

namespace rcManagerUserRepository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserData _userData;
        private readonly IPasswordData _pwdData;

        public UserRepository(IUserData userData, IPasswordData pwdData)
        {
            this._userData = userData;
            this._pwdData = pwdData;
        }

        public UserModel Get(long id)
        {
            UserModel modelRet = new UserModel();

            UserEntity entity = _userData.Get(id);

            if (entity != null) {
                modelRet = new UserModel(entity);
                modelRet.IsValidResponse = true;
            } else {
                modelRet.IsValidResponse = false;
                modelRet.AddMessage("Usuário não encontrado.");
            }

            return modelRet;
        }

        public UserModel List()
        {
            UserModel modelRet = new UserModel();

            IList<UserEntity> listEntity = _userData.List();

            if ((listEntity != null) && (listEntity.Count > 0)) {
                modelRet.IsValidResponse = true;
                modelRet.AddEntities(listEntity);
            } else {
                modelRet.IsValidResponse = true;
                modelRet.AddMessage("Nenhum registro encontrado.");
            }

            return modelRet;
        }

        public UserModel Insert(UserModel model)
        {
            UserModel modelRet = null;

            model.Entity.Id = 0;
            UserEntity entity = _userData.Insert(model.Entity);

            _userData.Save();

            if ((entity != null) && (entity.Id > 0)) {
                modelRet = new UserModel(entity);
                modelRet.IsValidResponse = true;
                modelRet.AddMessage("Usuário incluído com sucesso.");
            } else {
                modelRet = new UserModel(model);
                modelRet.IsValidResponse = false;
                modelRet.AddMessage("Não foi possível incluir o Usuário.");
            }

            return modelRet;
        }

        public UserModel Update(UserModel model)
        {
            UserModel modelRet = null;

            UserModel exist = this.Get(model.Entity.Id);

            if (exist != null) {
                UserEntity entity = _userData.Update(model.Entity);

                _userData.Save();

                if (entity != null) {
                    modelRet = new UserModel(entity);
                    modelRet.IsValidResponse = true;
                    modelRet.AddMessage("Usuário alterado com sucesso.");
                } else {
                    modelRet = new UserModel(model);
                    modelRet.IsValidResponse = false;
                    modelRet.AddMessage("Não foi possível alterar o Usuário.");
                }
            } else {
                modelRet = new UserModel(model);
                modelRet.IsValidResponse = false;
                modelRet.AddMessage("Usuário não encontrado para alteração.");
            }

            return modelRet;
        }

        public UserModel Delete(long id)
        {
            UserModel modelRet = null;

            UserModel exist = this.Get(id);

            if ((exist != null) && (exist.IsValidResponse)) {
                UserEntity entity = _userData.Delete(exist.Entity);

                _userData.Save();

                if (entity != null) {
                    modelRet = new UserModel(entity);
                    modelRet.IsValidResponse = true;
                    modelRet.AddMessage("Usuário excluído com sucesso.");
                } else {
                    modelRet = new UserModel();
                    modelRet.IsValidResponse = false;
                    modelRet.AddMessage("Não foi possível excluir o Usuário.");
                }
            } else {
                modelRet = new UserModel();
                modelRet.IsValidResponse = false;
                modelRet.AddMessage("Usuário não encontrado para exclusão.");
            }

            return modelRet;
        }

        public UserModel InsertUserPwd(UserModel userModel, PasswordModel pwdModel)
        {
            UserModel modelRet = null;

            userModel.Entity.Id = 0;
            UserEntity user = _userData.Insert(userModel.Entity);

            pwdModel.Entity.User_Id = user.Id;
            PasswordEntity pwd = _pwdData.Insert(pwdModel.Entity);

            _userData.Save();

            if (((user != null) && (user.Id > 0)) && ((pwd != null) && (pwd.Id > 0))) {
                modelRet = new UserModel(user);
                modelRet.IsValidResponse = true;
                modelRet.AddMessage("Usuário e Senha incluídos com sucesso.");
            } else {
                modelRet = new UserModel(userModel);
                modelRet.IsValidResponse = false;
                modelRet.AddMessage("Não foi possível incluir o Usuário.");
            }

            return modelRet;
        }
    }
}
