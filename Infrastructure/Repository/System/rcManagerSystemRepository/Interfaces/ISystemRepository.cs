using rcManagerSystemDomain.Models;

namespace rcManagerSystemRepository.Interfaces
{
    public interface ISystemRepository
    {
        SystemModel List();
        SystemModel Get(long id);
        SystemModel Insert(SystemModel model);
        SystemModel Update(SystemModel model);
        SystemModel Delete(long id);
    }
}
