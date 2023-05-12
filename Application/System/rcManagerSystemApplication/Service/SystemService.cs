using rcManagerSystemApplication.Interfaces;
using rcManagerSystemApplication.Transport;
using rcManagerSystemDomain;
using rcManagerSystemRepository.Interfaces;

namespace rcManagerSystemApplication.Service
{
    public class SystemService : ISystemService
    {
        private readonly ISystemRepository _repository;

        public SystemService(ISystemRepository repository)
        {
            this._repository = repository;
        }

        public SystemResponse List()
        {
            SystemResponse response = new SystemResponse();

            SystemModel modelResp = _repository.List();

            if (modelResp != null) {
                response.IsValid = modelResp.IsValidResponse;
                response.List = modelResp.TransportList;
                response.AddMessages(modelResp.Messages);
            }

            return response;
        }

        public SystemResponse Get(long id)
        {
            SystemResponse response = new SystemResponse();

            SystemModel modelResp = _repository.Get(id);

            if (modelResp != null) {
                response.IsValid = modelResp.IsValidResponse;
                response.Item = modelResp.Transport;
                response.AddMessages(modelResp.Messages);
            }

            return response;
        }

        public SystemResponse Insert(SystemRequest systemRequest)
        {
            SystemResponse response = new SystemResponse();

            SystemModel modelReq = new SystemModel(systemRequest);

            if (modelReq.IsValidModel) {
                SystemModel modelResp = _repository.Insert(modelReq);

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

        public SystemResponse Update(SystemRequest systemRequest)
        {
            SystemResponse response = new SystemResponse();

            SystemModel modelReq = new SystemModel(systemRequest);

            if (modelReq.IsValidModel) {
                SystemModel modelResp = _repository.Update(modelReq);

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

        public SystemResponse Delete(long id)
        {
            SystemResponse response = new SystemResponse();

            SystemModel modelResp = _repository.Delete(id);

            if (modelResp != null) {
                response.IsValid = modelResp.IsValidResponse;
                response.Item = modelResp.Transport;
                response.AddMessages(modelResp.Messages);
            }

            return response;
        }
    }
}
