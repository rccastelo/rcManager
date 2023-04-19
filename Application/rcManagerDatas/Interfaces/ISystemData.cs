using rcManagerTransfer.Interfaces;
using rcManagerTransfer.Transfers;

namespace rcManagerDatas.Interfaces
{
    public interface ISystemData
    {
        SystemTransfer list(ISystemTransfer systemTransfer);
    }
}
