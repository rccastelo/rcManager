using rcManagerDatabase;
using rcManagerDatas.Interfaces;
using rcManagerEntities.Entities;

namespace rcManagerDatas.Datas
{
    public class PermissionData : DatasBase<PermissionEntity>, IPermissionData
    {
        public PermissionData(ManagerDbContext context) : base(context)
        {

        }
    }
}
