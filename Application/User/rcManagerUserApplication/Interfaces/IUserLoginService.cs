using rcManagerUserApplication.Transport;

namespace rcManagerUserApplication.Interfaces
{
    public interface IUserLoginService
    {
        UserLoginResponse InsertUserLogin(UserLoginRequest request);
    }
}
