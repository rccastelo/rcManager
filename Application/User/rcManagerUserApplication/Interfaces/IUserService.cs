using rcManagerUserApplication.Application;

namespace rcManagerUserApplication.Interfaces
{
    public interface IUserService
    {
        UserTransfer List(UserTransfer userTransfer);
        UserTransfer Get(long id);
        UserTransfer Insert(UserTransfer userTransfer);
        UserTransfer Update(UserTransfer userTransfer);
        UserTransfer Delete(long id);
    }
}
