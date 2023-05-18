using rcManagerUserDomain.Entities;
using System.Collections.Generic;

namespace rcManagerUserRepository.Interfaces
{
    public interface ILoginData
    {
        LoginEntity Get(long id);
        LoginEntity GetByLogin(string login);
        IList<LoginEntity> List();
        LoginEntity Insert(LoginEntity model);
        LoginEntity Update(LoginEntity model);
        LoginEntity Delete(LoginEntity model);
        void Save();
    }
}
