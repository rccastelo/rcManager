using rcManagerUserApplication.Interfaces;
using rcManagerUserDomain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace rcManagerUserApplication.Application
{
    public class UserService : IUserService
    {
        private readonly IUserData _userData;

        public UserService(IUserData userData)
        {
            this._userData = userData;
        }

        public UserTransfer List(UserTransfer userTransfer)
        {
            UserTransfer userTransferRet = new UserTransfer();

            try {
                IList<UserEntity> listRet = _userData.List();

                if ((listRet != null) && (listRet.Count > 0)) {
                    userTransferRet.List = listRet.Select(et => new UserModel(et)).ToList();
                } else {
                    userTransferRet.AddMessage("Nenhum registro encontrado");
                }
            } catch (ArgumentException ex) {
                userTransferRet.Valid = false;
                userTransferRet.Error = true;
                userTransferRet.AddMessage(ex.Message);
            }

            return userTransferRet;
        }

        public UserTransfer Get(long id)
        {
            UserTransfer userTransferRet = new UserTransfer();

            try {
                UserEntity userEntityRet = _userData.Get(id);

                if (userEntityRet == null) {
                    userTransferRet.AddMessage("Registro não encontrado");
                } else {
                    userTransferRet.Item = new UserModel(userEntityRet);
                }
            } catch (ArgumentException ex) {
                userTransferRet.Valid = false;
                userTransferRet.Error = true;
                userTransferRet.AddMessage(ex.Message);
            }

            return userTransferRet;
        }

        public UserTransfer Insert(UserTransfer userTransfer)
        {
            UserTransfer userTransferRet = new UserTransfer();

            try {
                UserEntity entity = _userData.Insert(userTransfer.Item.toEntity());

                _userData.Save();

                userTransferRet.Item = new UserModel(entity);
            } catch (ArgumentException ex) {
                userTransferRet.Valid = false;
                userTransferRet.Error = true;
                userTransferRet.AddMessage(ex.Message);
            }

            return userTransferRet;
        }

        public UserTransfer Update(UserTransfer userTransfer)
        {
            UserTransfer userTransferRet = new UserTransfer();

            try {
                UserEntity entity = _userData.Update(userTransfer.Item.toEntity());

                _userData.Save();

                userTransferRet.Item = new UserModel(entity);
            } catch (ArgumentException ex) {
                userTransferRet.Valid = false;
                userTransferRet.Error = true;
                userTransferRet.AddMessage(ex.Message);
            }

            return userTransferRet;
        }

        public UserTransfer Delete(long id)
        {
            UserTransfer userTransferRet = new UserTransfer();

            try {
                UserEntity entityExist = _userData.Get(id);

                if (entityExist != null) {
                    UserEntity entity = _userData.Delete(entityExist);

                    _userData.Save();

                    userTransferRet.Item = new UserModel(entity);
                } else {
                    userTransferRet.AddMessage("Registro não encontrado");
                }
            } catch (ArgumentException ex) {
                userTransferRet.Valid = false;
                userTransferRet.Error = true;
                userTransferRet.AddMessage(ex.Message);
            }

            return userTransferRet;
        }
    }
}
