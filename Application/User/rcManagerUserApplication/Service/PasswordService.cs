using rcManagerUserApplication.Interfaces;
using rcManagerUserApplication.Transport;
using rcManagerUserDomain.Models;
using rcManagerUserRepository.Interfaces;

namespace rcManagerUserApplication.Service
{
    public class PasswordService : IPasswordService
    {
        private readonly IPasswordRepository _repository;

        public PasswordService(IPasswordRepository repository)
        {
            this._repository = repository;
        }

        public PasswordResponse List()
        {
            PasswordResponse response = new PasswordResponse();

            PasswordModel modelResp = _repository.List();

            if (modelResp != null) {
                response.IsValid = modelResp.IsValidResponse;
                response.AddList(modelResp.ResponseList);
                response.AddMessages(modelResp.Messages);
            }

            return response;
        }

        public PasswordResponse Get(long id)
        {
            PasswordResponse response = new PasswordResponse();

            PasswordModel modelResp = _repository.Get(id);

            if (modelResp != null) {
                response.IsValid = modelResp.IsValidResponse;
                response.SetItem(modelResp.ResponseItem);
                response.AddMessages(modelResp.Messages);
            }

            return response;
        }

        public PasswordResponse Insert(PasswordRequest passwordRequest)
        {
            PasswordResponse response = new PasswordResponse();

            PasswordModel modelReq = new PasswordModel(passwordRequest);

            if (modelReq.IsValidModel) {
                PasswordModel modelResp = _repository.Insert(modelReq);

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

        public PasswordResponse Update(PasswordRequest passwordRequest)
        {
            PasswordResponse response = new PasswordResponse();

            PasswordModel modelReq = new PasswordModel(passwordRequest);

            if (modelReq.IsValidModel) {
                PasswordModel modelResp = _repository.Update(modelReq);

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

        public PasswordResponse Delete(long id)
        {
            PasswordResponse response = new PasswordResponse();

            PasswordModel modelResp = _repository.Delete(id);

            if (modelResp != null) {
                response.IsValid = modelResp.IsValidResponse;
                response.SetItem(modelResp.ResponseItem);
                response.AddMessages(modelResp.Messages);
            }

            return response;
        }
    }
}
