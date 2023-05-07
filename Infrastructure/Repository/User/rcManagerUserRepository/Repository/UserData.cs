using Microsoft.EntityFrameworkCore;
using rcDbSqlServerEF;
using rcManagerUserDomain;
using rcManagerUserRepository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace rcManagerUserRepository.Repository
{
    public class UserData : DataEF, IUserData
    {
        public UserData(ManagerDbContext context) : base(context) { }

        public UserModel Get(long id)
        {
            UserModel model = null;

            UserEntity entity = _context.Set<UserEntity>().AsNoTracking().SingleOrDefault(et => et.Id == id);

            if (entity != null) {
                model = new UserModel(entity) { Password = null };
            }

            return model;
        }

        public IList<UserModel> List()
        {
            IList<UserModel> listMod = null;

            IList<UserEntity> listEnt = _context.Set<UserEntity>().AsNoTracking().ToList();

            if (listEnt != null) {
                listMod = listEnt.Select(et => new UserModel(et) { Password = null }).ToList();
            }

            return listMod;
        }

        public UserModel Insert(UserModel model)
        {
            UserModel modelRet = null;

            UserEntity entity = _context.Set<UserEntity>().Add(model.toEntity()).Entity;

            if (entity != null) {
                modelRet = new UserModel(entity) { Password = null };
            }

            return modelRet;
        }

        public UserModel Update(UserModel model)
        {
            UserModel modelRet = null;

            UserEntity entity = _context.Set<UserEntity>().Update(model.toEntity()).Entity;

            if (entity != null) {
                modelRet = new UserModel(entity) { Password = null };
            }

            return modelRet;
        }

        public UserModel Delete(UserModel model) 
        {
            UserModel modelRet = null;

            UserEntity entity = _context.Set<UserEntity>().Remove(model.toEntity()).Entity;

            if (entity != null) {
                modelRet = new UserModel(entity) { Password = null };
            }

            return modelRet;
        }
    }
}
