using rcManagerPermissionApplication.Interfaces;
using rcManagerPermissionApplication.Transport;
using rcManagerPermissionDomain;
using rcManagerPermissionRepository.Interfaces;

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

            PermissionModel modelResp = _repository.List();

            if (modelResp != null) {
                response.IsValid = modelResp.IsValidResponse;
                response.List = modelResp.TransportList;
                response.AddMessages(modelResp.Messages);
            }

            return response;
        }

        public PermissionResponse Get(long id)
        {
            PermissionResponse response = new PermissionResponse();

            PermissionModel modelResp = _repository.Get(id);

            if (modelResp != null) {
                response.IsValid = modelResp.IsValidResponse;
                response.Item = modelResp.Transport;
                response.AddMessages(modelResp.Messages);
            }

            return response;
        }

        public PermissionResponse Insert(PermissionRequest permissionRequest)
        {
            PermissionResponse response = new PermissionResponse();

            PermissionModel modelReq = new PermissionModel(permissionRequest);

            if (modelReq.IsValidModel) {
                PermissionModel modelResp = _repository.Insert(modelReq);

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

        public PermissionResponse Update(PermissionRequest permissionRequest)
        {
            PermissionResponse response = new PermissionResponse();

            PermissionModel modelReq = new PermissionModel(permissionRequest);

            if (modelReq.IsValidModel) {
                PermissionModel modelResp = _repository.Update(modelReq);

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

        public PermissionResponse Delete(long id)
        {
            PermissionResponse response = new PermissionResponse();

            PermissionModel modelResp = _repository.Delete(id);

            if (modelResp != null) {
                response.IsValid = modelResp.IsValidResponse;
                response.Item = modelResp.Transport;
                response.AddMessages(modelResp.Messages);
            }

            return response;
        }
    }
}
