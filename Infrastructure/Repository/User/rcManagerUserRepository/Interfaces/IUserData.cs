using rcManagerUserDomain;
using System.Collections.Generic;

namespace rcManagerUserRepository.Interfaces
{
    public interface IUserData
    {
        UserModel Get(long id);
        IList<UserModel> List();
        UserModel Insert(UserModel model);
        UserModel Update(UserModel model);
        UserModel Delete(UserModel model);
        void Save();
    }
}
