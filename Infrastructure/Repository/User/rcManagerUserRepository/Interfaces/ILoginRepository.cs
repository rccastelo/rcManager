using rcManagerUserDomain.Models;

namespace rcManagerUserRepository.Interfaces
{
    public interface ILoginRepository
    {
        LoginModel List();
        LoginModel Get(long id);
        LoginModel Insert(LoginModel model);
        LoginModel Update(LoginModel model);
        LoginModel Delete(long id);
    }
}
