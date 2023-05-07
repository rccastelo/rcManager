using rcManagerUserApplication.Interfaces;
using rcManagerUserApplication.Transport;
using rcManagerUserDomain;
using rcManagerUserRepository.Interfaces;
using System.Collections.Generic;
using System.Linq;

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

            IList<UserModel> listResp = _repository.List();

            if ((listResp != null) && (listResp.Count > 0)) {
                response.List = listResp.Select(md => md.ToEntity()).ToList();
            } else {
                response.AddMessage("Nenhum registro encontrado");
            }

            return response;
        }

        public UserResponse Get(long id)
        {
            UserResponse response = new UserResponse();

            UserModel modelResp = _repository.Get(id);

            if (modelResp != null) {
                response.Item = modelResp.ToEntity();
                response.AddMessages(modelResp.Messages);
            }

            return response;
        }

        public UserResponse Insert(UserRequest userRequest)
        {
            UserResponse response = new UserResponse();

            UserModel modelReq = new UserModel(userRequest) { Id = 0 };

            UserModel modelResp = _repository.Insert(modelReq);

            if (modelResp != null) {
                response.Item = modelResp.ToEntity();
                response.AddMessages(modelResp.Messages);
            }

            return response;
        }

        public UserResponse Update(UserRequest userRequest)
        {
            UserResponse response = new UserResponse();

            UserModel modelReq = new UserModel(userRequest);

            UserModel modelResp = _repository.Update(modelReq);

            if (modelResp != null) {
                response.Item = modelResp.ToEntity();
                response.AddMessages(modelResp.Messages);
            }

            return response;
        }

        public UserResponse Delete(long id)
        {
            UserResponse response = new UserResponse();

            UserModel modelResp = _repository.Delete(id);

            if (modelResp != null) {
                response.Item = modelResp.ToEntity();
                response.AddMessages(modelResp.Messages);
            }

            return response;
        }
    }
}
