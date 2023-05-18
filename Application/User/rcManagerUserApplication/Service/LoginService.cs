using rcManagerUserApplication.Interfaces;
using rcManagerUserApplication.Transport;
using rcManagerUserDomain.Models;
using rcManagerUserRepository.Interfaces;

namespace rcManagerUserApplication.Service
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _repository;

        public LoginService(ILoginRepository repository)
        {
            this._repository = repository;
        }

        public LoginResponse List()
        {
            LoginResponse response = new LoginResponse();

            LoginModel modelResp = _repository.List();

            if (modelResp != null) {
                response.IsValid = modelResp.IsValidResponse;
                response.AddList(modelResp.ResponseList);
                response.AddMessages(modelResp.Messages);
            }

            return response;
        }

        public LoginResponse Get(long id)
        {
            LoginResponse response = new LoginResponse();

            LoginModel modelResp = _repository.Get(id);

            if (modelResp != null) {
                response.IsValid = modelResp.IsValidResponse;
                response.SetItem(modelResp.ResponseItem);
                response.AddMessages(modelResp.Messages);
            }

            return response;
        }

        public LoginResponse Insert(LoginRequest request)
        {
            LoginResponse response = new LoginResponse();

            LoginModel modelReq = new LoginModel(request);

            if (modelReq.IsValidModel) {
                LoginModel modelResp = _repository.Insert(modelReq);

                if (modelResp != null) {
                    response.IsValid = modelResp.IsValidResponse;
                    response.SetItem(modelResp.ResponseItem);
                    response.AddMessages(modelResp.Messages);
                }
            } else {
                response.IsValid = false;
                response.SetItem(modelReq.ResponseItem);
                response.AddMessages(modelReq.Messages);
            }

            return response;
        }

        public LoginResponse Update(LoginRequest request)
        {
            LoginResponse response = new LoginResponse();

            LoginModel modelReq = new LoginModel(request);

            if (modelReq.IsValidModel) {
                LoginModel modelResp = _repository.Update(modelReq);

                if (modelResp != null) {
                    response.IsValid = modelResp.IsValidResponse;
                    response.SetItem(modelResp.ResponseItem);
                    response.AddMessages(modelResp.Messages);
                }
            } else {
                response.IsValid = false;
                response.SetItem(modelReq.ResponseItem);
                response.AddMessages(modelReq.Messages);
            }

            return response;
        }

        public LoginResponse Delete(long id)
        {
            LoginResponse response = new LoginResponse();

            LoginModel modelResp = _repository.Delete(id);

            if (modelResp != null) {
                response.IsValid = modelResp.IsValidResponse;
                response.SetItem(modelResp.ResponseItem);
                response.AddMessages(modelResp.Messages);
            }

            return response;
        }
    }
}
