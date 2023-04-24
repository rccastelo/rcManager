using rcManagerDatas.Interfaces;
using rcManagerEntities.Entities;
using rcManagerModels.Models;
using rcManagerServices.Interfaces;
using rcManagerTransfers.Transfers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace rcManagerServices.Services
{
    public class UserService : IUserService
    {
        private readonly IUserData _userData;

        public UserService(IUserData userData)
        {
            this._userData = userData;
        }

        public UserTransfer list(UserTransfer userTransfer)
        {
            UserTransfer userTransferRet = new UserTransfer();

            try {
                IList<UserEntity> listRet = _userData.list();

                if ((listRet != null) && (listRet.Count > 0)) {
                    userTransferRet.list = listRet.Select(et => new UserModel(et)).ToList();
                } else {
                    userTransferRet.addMessage("Nenhum registro encontrado");
                }
            } catch (ArgumentException ex) {
                userTransferRet.valid = false;
                userTransferRet.error = true;
                userTransferRet.addMessage(ex.Message);
            }

            return userTransferRet;
        }

        public UserTransfer get(long id)
        {
            UserTransfer userTransferRet = new UserTransfer();

            try {
                UserEntity userEntityRet = _userData.get(id);

                if (userEntityRet == null) {
                    userTransferRet.addMessage("Registro não encontrado");
                } else {
                    userTransferRet.item = new UserModel(userEntityRet);
                }
            } catch (ArgumentException ex) {
                userTransferRet.valid = false;
                userTransferRet.error = true;
                userTransferRet.addMessage(ex.Message);
            }

            return userTransferRet;
        }

        public UserTransfer insert(UserTransfer userTransfer)
        {
            UserTransfer userTransferRet = new UserTransfer();

            try {
                UserEntity entity = _userData.insert(userTransfer.item.toEntity());

                _userData.save();

                userTransferRet.item = new UserModel(entity);
            } catch (ArgumentException ex) {
                userTransferRet.valid = false;
                userTransferRet.error = true;
                userTransferRet.addMessage(ex.Message);
            }

            return userTransferRet;
        }

        public UserTransfer update(UserTransfer userTransfer)
        {
            UserTransfer userTransferRet = new UserTransfer();

            try {
                UserEntity entity = _userData.update(userTransfer.item.toEntity());

                _userData.save();

                userTransferRet.item = new UserModel(entity);
            } catch (ArgumentException ex) {
                userTransferRet.valid = false;
                userTransferRet.error = true;
                userTransferRet.addMessage(ex.Message);
            }

            return userTransferRet;
        }

        public UserTransfer delete(long id)
        {
            UserTransfer userTransferRet = new UserTransfer();

            try {
                UserEntity entityExist = _userData.get(id);

                if (entityExist != null) {
                    UserEntity entity = _userData.delete(entityExist);

                    _userData.save();

                    userTransferRet.item = new UserModel(entity);
                } else {
                    userTransferRet.addMessage("Registro não encontrado");
                }
            } catch (ArgumentException ex) {
                userTransferRet.valid = false;
                userTransferRet.error = true;
                userTransferRet.addMessage(ex.Message);
            }

            return userTransferRet;
        }
    }
}
