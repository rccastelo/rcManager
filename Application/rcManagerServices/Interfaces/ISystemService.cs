using rcManagerTransfer.Interfaces;
using rcManagerTransfer.Transfers;

namespace rcManagerServices.Interfaces
{
    public interface ISystemService
    {
        public SystemTransfer list(ISystemTransfer systemTransfer);
    }
}
