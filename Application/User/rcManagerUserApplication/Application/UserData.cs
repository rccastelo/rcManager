using rcManagerApplicationBase.Base;
using rcManagerDatabase.EF;
using rcManagerUserApplication.Interfaces;
using rcManagerUserDomain;

namespace rcManagerUserApplication.Application
{
    public class UserData : DatasBase<UserEntity>, IUserData
    {
        public UserData(ManagerDbContext context) : base(context)
        {

        }
    }
}
