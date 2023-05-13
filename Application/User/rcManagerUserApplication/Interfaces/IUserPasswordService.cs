using rcManagerUserApplication.Transport;

namespace rcManagerUserApplication.Interfaces
{
    public interface IUserPasswordService
    {
        UserPasswordResponse InsertUserPwd(UserPasswordRequest userPwdRequest);
    }
}
