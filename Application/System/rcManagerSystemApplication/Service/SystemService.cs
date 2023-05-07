using rcManagerSystemApplication.Interfaces;
using rcManagerSystemApplication.Transport;
using rcManagerSystemDomain;
using rcManagerSystemRepository.Interfaces;
using System.Collections.Generic;
using System.Linq;

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

            IList<SystemModel> listResp = _repository.List();

            if ((listResp != null) && (listResp.Count > 0)) {
                response.List = listResp.Select(md => md.ToEntity()).ToList();
            } else {
                response.AddMessage("Nenhum registro encontrado");
            }

            return response;
        }

        public SystemResponse Get(long id)
        {
            SystemResponse response = new SystemResponse();

            SystemModel modelResp = _repository.Get(id);

            if (modelResp != null) {
                response.Item = modelResp.ToEntity();
                response.AddMessages(modelResp.Messages);
            }

            return response;
        }

        public SystemResponse Insert(SystemRequest systemRequest)
        {
            SystemResponse response = new SystemResponse();

            SystemModel modelReq = new SystemModel(systemRequest) { Id = 0 };

            SystemModel modelResp = _repository.Insert(modelReq);

            if (modelResp != null) {
                response.Item = modelResp.ToEntity();
                response.AddMessages(modelResp.Messages);
            }

            return response;
        }

        public SystemResponse Update(SystemRequest systemRequest)
        {
            SystemResponse response = new SystemResponse();

            SystemModel modelReq = new SystemModel(systemRequest);

            SystemModel modelResp = _repository.Update(modelReq);

            if (modelResp != null) {
                response.Item = modelResp.ToEntity();
                response.AddMessages(modelResp.Messages);
            }

            return response;
        }

        public SystemResponse Delete(long id)
        {
            SystemResponse response = new SystemResponse();

            SystemModel modelResp = _repository.Delete(id);

            if (modelResp != null) {
                response.Item = modelResp.ToEntity();
                response.AddMessages(modelResp.Messages);
            }

            return response;
        }
    }
}
