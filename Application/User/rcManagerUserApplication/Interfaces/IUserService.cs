using rcManagerUserApplication.Transport;

namespace rcManagerUserApplication.Interfaces
{
    public interface IUserService
    {
        UserResponse List();
        UserResponse Get(long id);
        UserResponse Insert(UserRequest userRequest);
        UserResponse Update(UserRequest userRequest);
        UserResponse Delete(long id);
    }
}
