using rcManagerTransfers.Transfers;

namespace rcManagerServices.Interfaces
{
    public interface ISystemService
    {
        SystemTransfer list(SystemTransfer systemTransfer);
        SystemTransfer get(long id);
        SystemTransfer insert(SystemTransfer systemTransfer);
        SystemTransfer update(SystemTransfer systemTransfer);
        SystemTransfer delete(long id);
    }
}
