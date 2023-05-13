using rcManagerUserDomain.Entities;
using System.Collections.Generic;

namespace rcManagerUserRepository.Interfaces
{
    public interface IPasswordData
    {
        PasswordEntity Get(long id);
        IList<PasswordEntity> List();
        PasswordEntity Insert(PasswordEntity model);
        PasswordEntity Update(PasswordEntity model);
        PasswordEntity Delete(PasswordEntity model);
        void Save();
    }
}
