using rcManagerDatabase;
using rcManagerDatas.Interfaces;
using rcManagerEntities.Entities;

namespace rcManagerDatas.Datas
{
    public class UserData : DatasBase<UserEntity>, IUserData
    {
        public UserData(ManagerDbContext context) : base(context)
        {

        }
    }
}
