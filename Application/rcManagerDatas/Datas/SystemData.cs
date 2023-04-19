using rcManagerDatas.Interfaces;
using rcManagerTransfer.Interfaces;
using rcManagerTransfer.Transfers;

namespace rcManagerDatas.Datas
{
    public class SystemData : ISystemData
    {
        public SystemTransfer list(ISystemTransfer systemTransfer)
        {
            SystemTransfer st = new SystemTransfer();

            st.name = "teste";

            return st;
        }
    }
}
