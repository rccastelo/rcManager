using rcCryptography;
using rcManagerUserApplication.Interfaces;
using rcManagerUserApplication.Transport;
using rcManagerUserDomain;
using rcManagerUserRepository.Interfaces;

namespace rcManagerUserApplication.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            this._repository = repository;
        }

        public UserResponse List()
        {
            UserResponse response = new UserResponse();

            UserModel modelResp = _repository.List();

            if (modelResp != null) {
                response.IsValid = modelResp.IsValid;
                response.List = modelResp.List;
                response.AddMessages(modelResp.Messages);
            }

            return response;
        }

        public UserResponse Get(long id)
        {
            UserResponse response = new UserResponse();

            UserModel modelResp = _repository.Get(id);

            if (modelResp != null) {
                response.IsValid = modelResp.IsValid;
                response.Item = modelResp.Item;
                response.AddMessages(modelResp.Messages);
            }

            return response;
        }

        public UserResponse Insert(UserRequest userRequest)
        {
            UserResponse response = new UserResponse();

            userRequest.Id = 0;
            UserModel modelReq = new UserModel(userRequest);

            if (modelReq.ValidModel) {
                string secret = Crypto.GetSecretSHA512(modelReq.Item.Login + modelReq.Item.Password);

                modelReq.Item.Password = secret; 
                
                UserModel modelResp = _repository.Insert(modelReq);

                if (modelResp != null) {
                    response.IsValid = modelResp.IsValid;
                    response.Item = modelResp.Item;
                    response.AddMessages(modelResp.Messages);
                }
            } else {
                response.IsValid = false;
                response.Item = modelReq.Item;
                response.AddMessages(modelReq.Messages);
            }

            return response;
        }

        public UserResponse Update(UserRequest userRequest)
        {
            UserResponse response = new UserResponse();

            UserModel modelReq = new UserModel(userRequest);

            if (modelReq.ValidModel) {
                string secret = Crypto.GetSecretSHA512(modelReq.Item.Login + modelReq.Item.Password);

                modelReq.Item.Password = secret;

                UserModel modelResp = _repository.Update(modelReq);

                if (modelResp != null) {
                    response.IsValid = modelResp.IsValid;
                    response.Item = modelResp.Item;
                    response.AddMessages(modelResp.Messages);
                }
            } else {
                response.IsValid = false;
                response.Item = modelReq.Item;
                response.AddMessages(modelReq.Messages);
            }

            return response;
        }

        public UserResponse Delete(long id)
        {
            UserResponse response = new UserResponse();

            UserModel modelResp = _repository.Delete(id);

            if (modelResp != null) {
                response.IsValid = modelResp.IsValid;
                response.Item = modelResp.Item;
                response.AddMessages(modelResp.Messages);
            }

            return response;
        }
    }
}
