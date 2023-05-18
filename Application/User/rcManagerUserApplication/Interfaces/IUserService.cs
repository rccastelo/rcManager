using rcManagerUserApplication.Transport;

namespace rcManagerUserApplication.Interfaces
{
    public interface IUserService
    {
        UserResponse List();
        UserResponse Get(long id);
        UserResponse Insert(UserRequest request);
        UserResponse Update(UserRequest request);
        UserResponse Delete(long id);
    }
}
