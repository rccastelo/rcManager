using rcManagerUserApplication.Transport;

namespace rcManagerUserApplication.Interfaces
{
    public interface ILoginService
    {
        LoginResponse List();
        LoginResponse Get(long id);
        LoginResponse Insert(LoginRequest request);
        LoginResponse Update(LoginRequest request);
        LoginResponse Delete(long id);
    }
}
