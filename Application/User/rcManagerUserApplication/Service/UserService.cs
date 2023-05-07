using rcManagerUserApplication.Interfaces;
using rcManagerUserApplication.Transport;
using rcManagerUserDomain;
using rcManagerUserRepository.Interfaces;
using System;
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
            UserResponse userResponseRet = new UserResponse();

            try {
                IList<UserModel> listRet = _repository.List();

                if ((listRet != null) && (listRet.Count > 0)) {
                    userResponseRet.List = listRet.Select(et => new UserEntity(et)).ToList();
                } else {
                    userResponseRet.AddMessage("Nenhum registro encontrado");
                }
            } catch (ArgumentException ex) {
                userResponseRet.IsValid = false;
                userResponseRet.Error = true;
                userResponseRet.AddMessage(ex.Message);
            }

            return userResponseRet;
        }

        public UserResponse Get(long id)
        {
            UserResponse userResponseRet = new UserResponse();

            try {
                UserModel userModelRet = _repository.Get(id);

                if (userModelRet == null) {
                    userResponseRet.AddMessage("Registro não encontrado");
                } else {
                    userResponseRet.Item = userModelRet;
                }
            } catch (ArgumentException ex) {
                userResponseRet.IsValid = false;
                userResponseRet.Error = true;
                userResponseRet.AddMessage(ex.Message);
            }

            return userResponseRet;
        }

        public UserResponse Insert(UserRequest userRequest)
        {
            UserResponse userResponseRet = new UserResponse();

            try {
                UserModel req = new UserModel(userRequest);

                UserModel model = _repository.Insert(req);

                userResponseRet.Item = model.toEntity();
            } catch (ArgumentException ex) {
                userResponseRet.IsValid = false;
                userResponseRet.Error = true;
                userResponseRet.AddMessage(ex.Message);
            }

            return userResponseRet;
        }

        public UserResponse Update(UserRequest userRequest)
        {
            UserResponse userResponseRet = new UserResponse();

            try {
                UserModel req = new UserModel(userRequest);

                UserModel model = _repository.Update(req);

                userResponseRet.Item = model.toEntity();
            } catch (ArgumentException ex) {
                userResponseRet.IsValid = false;
                userResponseRet.Error = true;
                userResponseRet.AddMessage(ex.Message);
            }

            return userResponseRet;
        }

        public UserResponse Delete(long id)
        {
            UserResponse userResponseRet = new UserResponse();

            try {
                UserEntity entityExist = _repository.Get(id);

                if (entityExist != null) {
                    UserModel req = new UserModel(entityExist);

                    UserModel model = _repository.Delete(req);

                    userResponseRet.Item = model.toEntity();
                } else {
                    userResponseRet.AddMessage("Registro não encontrado");
                }
            } catch (ArgumentException ex) {
                userResponseRet.IsValid = false;
                userResponseRet.Error = true;
                userResponseRet.AddMessage(ex.Message);
            }

            return userResponseRet;
        }
    }
}
