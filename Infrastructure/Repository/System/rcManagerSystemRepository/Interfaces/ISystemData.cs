using rcManagerSystemDomain;
using System.Collections.Generic;

namespace rcManagerSystemRepository.Interfaces
{
    public interface ISystemData
    {
        SystemModel Get(long id);
        IList<SystemModel> List();
        SystemModel Insert(SystemModel model);
        SystemModel Update(SystemModel model);
        SystemModel Delete(SystemModel model);
        void Save();
    }
}
