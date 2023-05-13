using rcManagerUserDomain.Entities;
using rcManagerUserDomain.Models;
using rcManagerUserRepository.Interfaces;
using System.Transactions;

namespace rcManagerUserRepository.Repositories
{
    public class UserPasswordRepository : IUserPasswordRepository
    {
        private readonly IUserData _userData;
        private readonly IPasswordData _pwdData;

        public UserPasswordRepository(IUserData userData, IPasswordData pwdData)
        {
            this._userData = userData;
            this._pwdData = pwdData;
        }

        public UserModel InsertUserPwd(UserModel userModel, PasswordModel pwdModel)
        {
            UserModel modelRet = null;

            using (TransactionScope ts = new TransactionScope()) {
                userModel.Entity.Id = 0;
                UserEntity user = _userData.Insert(userModel.Entity);

                pwdModel.Entity.User_Id = user.Id;
                PasswordEntity pwd = _pwdData.Insert(pwdModel.Entity);

                if (((user != null) && (user.Id > 0)) && ((pwd != null) && (pwd.Id > 0))) {
                    modelRet = new UserModel(user);
                    modelRet.IsValidResponse = true;
                    modelRet.AddMessage("Usuário e Senha incluídos com sucesso.");

                    ts.Complete();
                } else {
                    modelRet = new UserModel(userModel);
                    modelRet.IsValidResponse = false;
                    modelRet.AddMessage("Não foi possível incluir o Usuário e Senha.");
                }

                ts.Dispose();
            }

            return modelRet;
        }
    }
}
