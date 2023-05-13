using Microsoft.EntityFrameworkCore;
using rcDbSqlServerEF;
using rcManagerUserDomain.Entities;
using rcManagerUserRepository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace rcManagerUserRepository.Datas
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
            PasswordEntity ret = _context.Set<PasswordEntity>().Add(entity).Entity;

            this.Save();

            return ret;
        }

        public PasswordEntity Update(PasswordEntity entity)
        {
            PasswordEntity ret = _context.Set<PasswordEntity>().Update(entity).Entity;

            this.Save();

            return ret;
        }

        public PasswordEntity Delete(PasswordEntity entity)
        {
            PasswordEntity ret = _context.Set<PasswordEntity>().Remove(entity).Entity;

            this.Save();

            return ret;
        }
    }
}
