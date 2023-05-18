using rcManagerUserDomain.Entities;
using rcManagerUserDomain.Models;
using rcManagerUserRepository.Interfaces;
using System.Transactions;

namespace rcManagerUserRepository.Repositories
{
    public class UserLoginRepository : IUserLoginRepository
    {
        private readonly IUserData _userData;
        private readonly ILoginData _loginData;

        public UserLoginRepository(IUserData userData, ILoginData loginData)
        {
            this._userData = userData;
            this._loginData = loginData;
        }

        public UserModel InsertUserLogin(UserModel userModel, LoginModel loginModel)
        {
            UserModel modelRet = null;

            using (TransactionScope ts = new TransactionScope()) {
                LoginEntity loginExist = _loginData.GetByLogin(loginModel.Entity.Login);

                if (loginExist == null) {
                    userModel.Entity.Id = 0;
                    UserEntity user = _userData.Insert(userModel.Entity);

                    loginModel.Entity.User_Id = user.Id;
                    LoginEntity login = _loginData.Insert(loginModel.Entity);

                    if (((user != null) && (user.Id > 0)) && ((login != null) && (login.Id > 0))) {
                        modelRet = new UserModel(user);
                        modelRet.IsValidResponse = true;
                        modelRet.AddMessage("Usuário e Login incluídos com sucesso.");

                        ts.Complete();
                    } else {
                        modelRet = new UserModel(userModel);
                        modelRet.IsValidResponse = false;
                        modelRet.AddMessage("Não foi possível incluir o Usuário e Login.");
                    }
                } else {
                    modelRet = new UserModel(userModel);
                    modelRet.IsValidResponse = false;
                    modelRet.AddMessage("O Login informado já existe.");
                }

                ts.Dispose();
            }

            return modelRet;
        }
    }
}
