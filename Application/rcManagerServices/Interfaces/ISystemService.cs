using rcManagerTransfers.Transfers;

namespace rcManagerServices.Interfaces
{
    public interface ISystemService
    {
        public SystemTransfer list(SystemTransfer systemTransfer);
    }
}
