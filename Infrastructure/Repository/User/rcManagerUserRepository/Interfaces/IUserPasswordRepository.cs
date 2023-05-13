using rcManagerUserDomain.Models;

namespace rcManagerUserRepository.Interfaces
{
    public interface IUserPasswordRepository
    {
        UserModel InsertUserPwd(UserModel userModel, PasswordModel pwdModel);
    }
}
