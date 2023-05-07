using rcManagerUserDomain;
using System.Collections.Generic;

namespace rcManagerUserRepository.Interfaces
{
    public interface IUserRepository
    {
        IList<UserModel> List();
        UserModel Get(long id);
        UserModel Insert(UserModel model);
        UserModel Update(UserModel model);
        UserModel Delete(UserModel model);
    }
}
