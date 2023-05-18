using rcManagerUserDomain.Models;

namespace rcManagerUserRepository.Interfaces
{
    public interface IUserLoginRepository
    {
        UserModel InsertUserLogin(UserModel userModel, LoginModel loginModel);
    }
}
