using rcManagerUserDomain;
using System.Collections.Generic;

namespace rcManagerUserRepository.Interfaces
{
    public interface IUserData
    {
        UserEntity Get(long id);
        IList<UserEntity> List();
        UserEntity Insert(UserEntity model);
        UserEntity Update(UserEntity model);
        UserEntity Delete(UserEntity model);
        void Save();
    }
}
