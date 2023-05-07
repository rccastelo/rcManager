using rcManagerUserDomain;
using rcManagerUserRepository.Interfaces;
using System.Collections.Generic;
using System.Linq;

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
            UserModel modelRet = null;

            UserEntity entity = _userData.Get(id);

            if (entity != null) {
                modelRet = new UserModel(entity);
            } else {
                modelRet = new UserModel() {
                    IsValid = false
                };

                modelRet.AddMessage("Usuário não encontrado.");
            }

            return modelRet;
        }

        public IList<UserModel> List()
        {
            IList<UserModel> listRet = null;

            IList<UserEntity> listEntity = _userData.List();

            if ((listEntity != null) && (listEntity.Count > 0)) {
                listRet = listEntity.Select(et => new UserModel(et)).ToList();
            }

            return listRet;
        }

        public UserModel Insert(UserModel model)
        {
            UserModel modelRet = null;

            UserEntity entity = _userData.Insert(model.ToEntity());

            _userData.Save();

            if ((entity != null) && (entity.Id > 0)) {
                modelRet = new UserModel(entity);
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

            UserModel exist = this.Get(model.Id);

            if (exist != null) {
                UserEntity entity = _userData.Update(model.ToEntity());

                _userData.Save();

                if (entity != null) {
                    modelRet = new UserModel(entity);

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

            if (exist != null) {
                UserEntity entity = _userData.Delete(exist.ToEntity());

                _userData.Save();

                if (entity != null) {
                    modelRet = new UserModel(entity);
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
