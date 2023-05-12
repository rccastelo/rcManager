using rcManagerUserApplication.Transport;

namespace rcManagerUserApplication.Interfaces
{
    public interface IPasswordService
    {
        PasswordResponse List();
        PasswordResponse Get(long id);
        PasswordResponse Insert(PasswordRequest passwordRequest);
        PasswordResponse Update(PasswordRequest passwordRequest);
        PasswordResponse Delete(long id);
    }
}
