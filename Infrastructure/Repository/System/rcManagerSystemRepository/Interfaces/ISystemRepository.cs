using rcManagerSystemDomain;
using System.Collections.Generic;

namespace rcManagerSystemRepository.Interfaces
{
    public interface ISystemRepository
    {
        IList<SystemModel> List();
        SystemModel Get(long id);
        SystemModel Insert(SystemModel model);
        SystemModel Update(SystemModel model);
        SystemModel Delete(long id);
    }
}
