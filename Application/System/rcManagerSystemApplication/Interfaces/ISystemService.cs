using rcManagerSystemApplication.Application;

namespace rcManagerSystemApplication.Interfaces
{
    public interface ISystemService
    {
        SystemTransfer List(SystemTransfer systemTransfer);
        SystemTransfer Get(long id);
        SystemTransfer Insert(SystemTransfer systemTransfer);
        SystemTransfer Update(SystemTransfer systemTransfer);
        SystemTransfer Delete(long id);
    }
}
