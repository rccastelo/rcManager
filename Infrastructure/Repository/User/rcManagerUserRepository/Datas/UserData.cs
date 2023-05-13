using Microsoft.EntityFrameworkCore;
using rcDbSqlServerEF;
using rcManagerUserDomain.Entities;
using rcManagerUserRepository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace rcManagerUserRepository.Datas
{
    public class UserData : DataEF, IUserData
    {
        public UserData(ManagerDbContext context) : base(context) { }

        public UserEntity Get(long id)
        {
            return _context.Set<UserEntity>().AsNoTracking().SingleOrDefault(et => et.Id == id);
        }

        public IList<UserEntity> List()
        {
            return _context.Set<UserEntity>().AsNoTracking().ToList();
        }

        public UserEntity Insert(UserEntity entity)
        {
            UserEntity ret = _context.Set<UserEntity>().Add(entity).Entity;

            this.Save();

            return ret;
        }

        public UserEntity Update(UserEntity entity)
        {
            UserEntity ret = _context.Set<UserEntity>().Update(entity).Entity;

            this.Save();

            return ret;
        }

        public UserEntity Delete(UserEntity entity)
        {
            UserEntity ret = _context.Set<UserEntity>().Remove(entity).Entity;

            this.Save();

            return ret;
        }
    }
}
