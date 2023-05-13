using rcManagerUserApplication.Interfaces;
using rcManagerUserApplication.Transport;
using rcManagerUserDomain.Models;
using rcManagerUserRepository.Interfaces;

namespace rcManagerUserApplication.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public UserResponse List()
        {
            UserResponse response = new UserResponse();

            UserModel modelResp = _userRepository.List();

            if (modelResp != null) {
                response.IsValid = modelResp.IsValidResponse;
                response.AddList(modelResp.TransportList);
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
                response.SetItem(modelResp.Transport);
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
                    response.SetItem(modelResp.Transport);
                    response.AddMessages(modelResp.Messages);
                }
            } else {
                response.IsValid = false;
                response.SetItem(modelReq.Transport);
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
                    response.SetItem(modelResp.Transport);
                    response.AddMessages(modelResp.Messages);
                }
            } else {
                response.IsValid = false;
                response.SetItem(modelReq.Transport);
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
                response.SetItem(modelResp.Transport);
                response.AddMessages(modelResp.Messages);
            }

            return response;
        }
    }
}
