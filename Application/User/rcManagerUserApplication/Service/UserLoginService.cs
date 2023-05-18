using rcManagerUserApplication.Interfaces;
using rcManagerUserApplication.Transport;
using rcManagerUserDomain.Models;
using rcManagerUserRepository.Interfaces;

namespace rcManagerUserApplication.Service
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IUserLoginRepository _userLoginRepository;

        public UserLoginService(IUserLoginRepository userLoginRepository)
        {
            this._userLoginRepository = userLoginRepository;
        }

        public UserLoginResponse InsertUserLogin(UserLoginRequest request)
        {
            UserLoginResponse response = new UserLoginResponse();

            UserModel userReq = new UserModel(request.User);
            LoginModel loginReq = new LoginModel(request.Login);

            if (userReq.IsValidModel && loginReq.IsValidModel) {
                UserModel userResp = _userLoginRepository.InsertUserLogin(userReq, loginReq);

                if (userResp != null) {
                    response.IsValid = userResp.IsValidResponse;
                    response.SetItem(userResp.ResponseItem);
                    response.AddMessages(userResp.Messages);
                }
            } else {
                response.IsValid = false;
                response.SetItem(userReq.ResponseItem);
                response.SetItem(loginReq.ResponseItem);
                response.AddMessages(userReq.Messages);
                response.AddMessages(loginReq.Messages);
            }

            return response;
        }
    }
}
