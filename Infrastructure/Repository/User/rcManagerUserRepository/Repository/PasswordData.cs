using Microsoft.EntityFrameworkCore;
using rcDbSqlServerEF;
using rcManagerUserDomain;
using rcManagerUserRepository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace rcManagerUserRepository.Repository
{
    public class PasswordData : DataEF, IPasswordData
    {
        public PasswordData(ManagerDbContext context) : base(context) { }

        public PasswordEntity Get(long id)
        {
            return _context.Set<PasswordEntity>().AsNoTracking().SingleOrDefault(et => et.Id == id);
        }

        public IList<PasswordEntity> List()
        {
            return _context.Set<PasswordEntity>().AsNoTracking().ToList();
        }

        public PasswordEntity Insert(PasswordEntity entity)
        {
            return _context.Set<PasswordEntity>().Add(entity).Entity;
        }

        public PasswordEntity Update(PasswordEntity entity)
        {
            return _context.Set<PasswordEntity>().Update(entity).Entity;
        }

        public PasswordEntity Delete(PasswordEntity entity)
        {
            return _context.Set<PasswordEntity>().Remove(entity).Entity;
        }
    }
}
