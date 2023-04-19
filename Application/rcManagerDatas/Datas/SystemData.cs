using rcManagerDatas.Interfaces;
using rcManagerEntities.Entities;
using rcManagerTransfers.Transfers;

namespace rcManagerDatas.Datas
{
    public class SystemData : ISystemData
    {
        public SystemTransfer list(SystemTransfer systemTransfer)
        {
            SystemTransfer st = new SystemTransfer();

            st.entity = new SystemEntity();
            st.entity.id = 1;
            st.entity.name = "name um";
            st.entity.description = "description um";

            return st;
        }
    }
}
