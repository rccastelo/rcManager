using rcManagerDatabase;
using rcManagerDatas.Interfaces;
using rcManagerEntities.Entities;

namespace rcManagerDatas.Datas
{
    public class SystemData : DatasBase<SystemEntity>, ISystemData
    {
        public SystemData(ManagerDbContext context) : base(context)
        {
        }
    }
}
