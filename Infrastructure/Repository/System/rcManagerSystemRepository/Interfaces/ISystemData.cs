using rcManagerSystemDomain.Entities;
using System.Collections.Generic;

namespace rcManagerSystemRepository.Interfaces
{
    public interface ISystemData
    {
        SystemEntity Get(long id);
        IList<SystemEntity> List();
        SystemEntity Insert(SystemEntity model);
        SystemEntity Update(SystemEntity model);
        SystemEntity Delete(SystemEntity model);
        void Save();
    }
}
