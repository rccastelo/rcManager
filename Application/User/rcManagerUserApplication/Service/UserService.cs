using rcManagerUserApplication.Interfaces;
using rcManagerUserApplication.Transport;
using rcManagerUserDomain;
using rcManagerUserRepository.Interfaces;

namespace rcManagerUserApplication.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordRepository _pwdRepository;

        public UserService(IUserRepository userRepository, IPasswordRepository pwdRepository)
        {
            this._userRepository = userRepository;
            this._pwdRepository = pwdRepository;
        }

        public UserResponse List()
        {
            UserResponse response = new UserResponse();

            UserModel modelResp = _userRepository.List();

            if (modelResp != null) {
                response.IsValid = modelResp.IsValidResponse;
                response.List = modelResp.TransportList;
                response.AddMessages(modelResp.Messages);
            }

            return response;
        }

        public UserResponse Get(long id)
        {
            UserResponse response = new UserResponse();

            UserModel modelResp = _userRepository.Get(id);

            if (modelResp != null) {
                response.IsValid = modelResp.IsValidResponse;
                response.Item = modelResp.Transport;
                response.AddMessages(modelResp.Messages);
            }

            return response;
        }

        public UserResponse Insert(UserRequest userRequest)
        {
            UserResponse response = new UserResponse();

            UserModel modelReq = new UserModel(userRequest);

            if (modelReq.IsValidModel) {
                UserModel modelResp = _userRepository.Insert(modelReq);

                if (modelResp != null) {
                    response.IsValid = modelResp.IsValidResponse;
                    response.Item = modelResp.Transport;
                    response.AddMessages(modelResp.Messages);
                }
            } else {
                response.IsValid = false;
                response.Item = modelReq.Transport;
                response.AddMessages(modelReq.Messages);
            }

            return response;
        }

        public UserResponse Update(UserRequest userRequest)
        {
            UserResponse response = new UserResponse();

            UserModel modelReq = new UserModel(userRequest);

            if (modelReq.IsValidModel) {
                UserModel modelResp = _userRepository.Update(modelReq);

                if (modelResp != null) {
                    response.IsValid = modelResp.IsValidResponse;
                    response.Item = modelResp.Transport;
                    response.AddMessages(modelResp.Messages);
                }
            } else {
                response.IsValid = false;
                response.Item = modelReq.Transport;
                response.AddMessages(modelReq.Messages);
            }

            return response;
        }

        public UserResponse Delete(long id)
        {
            UserResponse response = new UserResponse();

            UserModel modelResp = _userRepository.Delete(id);

            if (modelResp != null) {
                response.IsValid = modelResp.IsValidResponse;
                response.Item = modelResp.Transport;
                response.AddMessages(modelResp.Messages);
            }

            return response;
        }

        public PasswordResponse ListPwd()
        {
            PasswordResponse response = new PasswordResponse();

            PasswordModel modelResp = _pwdRepository.List();

            if (modelResp != null)
            {
                response.IsValid = modelResp.IsValidResponse;
                response.List = modelResp.TransportList;
                response.AddMessages(modelResp.Messages);
            }

            return response;
        }

        public UserPasswordResponse InsertUserPwd(UserPasswordRequest userPwdRequest)
        {
            UserPasswordResponse response = new UserPasswordResponse();

            UserModel userReq = new UserModel(userPwdRequest.User);
            PasswordModel pwdReq = new PasswordModel(userPwdRequest.Password);

            if ((userReq.IsValidModel) && (pwdReq.IsValidModel)) {
                UserModel userResp = _userRepository.InsertUserPwd(userReq, pwdReq);

                if (userResp != null) {
                    response.IsValid = userResp.IsValidResponse;
                    response.Item.User = userResp.Transport;
                    response.AddMessages(userResp.Messages);
                }
            } else {
                response.IsValid = false;
                response.Item.User = userReq.Transport;
                response.AddMessages(userReq.Messages);
                response.AddMessages(pwdReq.Messages);
            }

            return response;
        }
    }
}
