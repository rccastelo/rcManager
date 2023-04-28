using rcManagerApplicationBase.Base;
using rcManagerDatabase.EF;
using rcManagerSystemApplication.Interfaces;
using rcManagerSystemDomain;

namespace rcManagerSystemApplication.Application
{
    public class SystemData : DatasBase<SystemEntity>, ISystemData
    {
        public SystemData(ManagerDbContext context) : base(context)
        {
            
        }
    }
}
