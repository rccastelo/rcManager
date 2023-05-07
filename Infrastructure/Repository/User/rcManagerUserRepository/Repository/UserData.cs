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
            return _context.Set<UserEntity>().Add(entity).Entity;
        }

        public UserEntity Update(UserEntity entity)
        {
            return _context.Set<UserEntity>().Update(entity).Entity;
        }

        public UserEntity Delete(UserEntity entity)
        {
            return _context.Set<UserEntity>().Remove(entity).Entity;
        }
    }
}
