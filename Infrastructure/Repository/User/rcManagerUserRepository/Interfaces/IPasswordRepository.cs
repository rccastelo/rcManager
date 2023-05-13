using rcManagerUserDomain.Models;

namespace rcManagerUserRepository.Interfaces
{
    public interface IPasswordRepository
    {
        PasswordModel List();
        PasswordModel Get(long id);
        PasswordModel Insert(PasswordModel model);
        PasswordModel Update(PasswordModel model);
        PasswordModel Delete(long id);
    }
}
