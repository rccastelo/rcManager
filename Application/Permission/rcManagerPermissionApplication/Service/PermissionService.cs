using rcManagerPermissionApplication.Interfaces;
using rcManagerPermissionApplication.Transport;
using rcManagerPermissionDomain;
using rcManagerPermissionRepository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace rcManagerPermissionApplication.Service
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _repository;

        public PermissionService(IPermissionRepository repository)
        {
            this._repository = repository;
        }

        public PermissionResponse List()
        {
            PermissionResponse response = new PermissionResponse();

            IList<PermissionModel> listResp = _repository.List();

            if ((listResp != null) && (listResp.Count > 0)) {
                response.List = listResp.Select(md => md.ToEntity()).ToList();
            } else {
                response.AddMessage("Nenhum registro encontrado");
            }

            return response;
        }

        public PermissionResponse Get(long id)
        {
            PermissionResponse response = new PermissionResponse();

            PermissionModel modelResp = _repository.Get(id);

            if (modelResp != null)
            {
                response.Item = modelResp.ToEntity();
                response.AddMessages(modelResp.Messages);
            }

            return response;
        }

        public PermissionResponse Insert(PermissionRequest permissionRequest)
        {
            PermissionResponse response = new PermissionResponse();

            PermissionModel modelReq = new PermissionModel(permissionRequest) { Id = 0 };

            PermissionModel modelResp = _repository.Insert(modelReq);

            if (modelResp != null) {
                response.Item = modelResp.ToEntity();
                response.AddMessages(modelResp.Messages);
            }

            return response;
        }

        public PermissionResponse Update(PermissionRequest permissionRequest)
        {
            PermissionResponse response = new PermissionResponse();

            PermissionModel modelReq = new PermissionModel(permissionRequest);

            PermissionModel modelResp = _repository.Update(modelReq);

            if (modelResp != null)
            {
                response.Item = modelResp.ToEntity();
                response.AddMessages(modelResp.Messages);
            }

            return response;
        }

        public PermissionResponse Delete(long id)
        {
            PermissionResponse response = new PermissionResponse();

            PermissionModel modelResp = _repository.Delete(id);

            if (modelResp != null)
            {
                response.Item = modelResp.ToEntity();
                response.AddMessages(modelResp.Messages);
            }

            return response;
        }
    }
}
