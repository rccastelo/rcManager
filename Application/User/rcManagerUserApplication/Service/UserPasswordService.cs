using rcManagerUserApplication.Interfaces;
using rcManagerUserApplication.Transport;
using rcManagerUserDomain.Models;
using rcManagerUserRepository.Interfaces;

namespace rcManagerUserApplication.Service
{
    public class UserPasswordService : IUserPasswordService
    {
        private readonly IUserPasswordRepository _userPwdRepository;

        public UserPasswordService(IUserPasswordRepository userPwdRepository)
        {
            this._userPwdRepository = userPwdRepository;
        }

        public UserPasswordResponse InsertUserPwd(UserPasswordRequest userPwdRequest)
        {
            UserPasswordResponse response = new UserPasswordResponse();

            UserModel userReq = new UserModel(userPwdRequest.User);
            PasswordModel pwdReq = new PasswordModel(userPwdRequest.Password);

            if (userReq.IsValidModel && pwdReq.IsValidModel) {
                UserModel userResp = _userPwdRepository.InsertUserPwd(userReq, pwdReq);

                if (userResp != null) {
                    response.IsValid = userResp.IsValidResponse;
                    response.SetItem(userResp.ResponseItem);
                    response.AddMessages(userResp.Messages);
                }
            } else {
                response.IsValid = false;
                response.SetItem(userReq.ResponseItem);
                response.SetItem(pwdReq.ResponseItem);
                response.AddMessages(userReq.Messages);
                response.AddMessages(pwdReq.Messages);
            }

            return response;
        }
    }
}
