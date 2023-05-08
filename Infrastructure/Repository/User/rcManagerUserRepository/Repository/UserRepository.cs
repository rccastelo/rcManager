using rcManagerUserDomain;
using rcManagerUserRepository.Interfaces;
using System.Collections.Generic;

namespace rcManagerUserRepository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserData _userData;

        public UserRepository(IUserData userData)
        {
            this._userData = userData;
        }

        public UserModel Get(long id)
        {
            UserModel modelRet = new UserModel();

            UserEntity entity = _userData.Get(id);

            if (entity != null) {
                modelRet = new UserModel(entity);
                modelRet.IsValid = true;
            } else {
                modelRet.IsValid = false;
                modelRet.AddMessage("Usuário não encontrado.");
            }

            return modelRet;
        }

        public UserModel List()
        {
            UserModel modelRet = new UserModel();

            IList<UserEntity> listEntity = _userData.List();

            if ((listEntity != null) && (listEntity.Count > 0)) {
                modelRet.IsValid = true;
                modelRet.AddEntities(listEntity);
            } else {
                modelRet.IsValid = true;
                modelRet.AddMessage("Nenhum registro encontrado.");
            }

            return modelRet;
        }

        public UserModel Insert(UserModel model)
        {
            UserModel modelRet = null;

            UserEntity entity = _userData.Insert(model.Item);

            _userData.Save();

            if ((entity != null) && (entity.Id > 0)) {
                modelRet = new UserModel(entity);
                modelRet.IsValid = true;
                modelRet.AddMessage("Usuário incluído com sucesso.");
            } else {
                modelRet = new UserModel(model);
                modelRet.IsValid = false;
                modelRet.AddMessage("Não foi possível incluir o Usuário.");
            }

            return modelRet;
        }

        public UserModel Update(UserModel model)
        {
            UserModel modelRet = null;

            UserModel exist = this.Get(model.Item.Id);

            if (exist != null) {
                UserEntity entity = _userData.Update(model.Item);

                _userData.Save();

                if (entity != null) {
                    modelRet = new UserModel(entity);
                    modelRet.IsValid = true;
                    modelRet.AddMessage("Usuário alterado com sucesso.");
                } else {
                    modelRet = new UserModel(model);
                    modelRet.IsValid = false;
                    modelRet.AddMessage("Não foi possível alterar o Usuário.");
                }
            } else {
                modelRet = new UserModel(model);
                modelRet.IsValid = false;
                modelRet.AddMessage("Usuário não encontrado para alteração.");
            }

            return modelRet;
        }

        public UserModel Delete(long id)
        {
            UserModel modelRet = null;

            UserModel exist = this.Get(id);

            if ((exist != null) && (exist.IsValid)) {
                UserEntity entity = _userData.Delete(exist.Item);

                _userData.Save();

                if (entity != null) {
                    modelRet = new UserModel(entity);
                    modelRet.IsValid = true;
                    modelRet.AddMessage("Usuário excluído com sucesso.");
                } else {
                    modelRet = new UserModel();
                    modelRet.IsValid = false;
                    modelRet.AddMessage("Não foi possível excluir o Usuário.");
                }
            } else {
                modelRet = new UserModel();
                modelRet.IsValid = false;
                modelRet.AddMessage("Usuário não encontrado para exclusão.");
            }

            return modelRet;
        }
    }
}
