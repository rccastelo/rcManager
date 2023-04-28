using rcManagerApplicationBase.Base;
using rcManagerDatabase.EF;
using rcManagerPermissionApplication.Interfaces;
using rcManagerPermissionDomain;

namespace rcManagerPermissionApplication.Application
{
    public class PermissionData : DatasBase<PermissionEntity>, IPermissionData
    {
        public PermissionData(ManagerDbContext context) : base(context)
        {

        }
    }
}
