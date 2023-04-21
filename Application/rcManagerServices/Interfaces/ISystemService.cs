using rcManagerTransfers.Transfers;

namespace rcManagerServices.Interfaces
{
    public interface ISystemService
    {
        public SystemTransfer list(SystemTransfer systemTransfer);
        public SystemTransfer get(SystemTransfer systemTransfer);
    }
}
