using Microsoft.EntityFrameworkCore;
using rcDbSqlServerEF;
using rcManagerUserDomain.Entities;
using rcManagerUserRepository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace rcManagerUserRepository.Datas
{
    public class LoginData : DataEF, ILoginData
    {
        public LoginData(ManagerDbContext context) : base(context) { }

        public LoginEntity Get(long id)
        {
            return _context.Set<LoginEntity>().AsNoTracking().SingleOrDefault(et => et.Id == id);
        }

        public LoginEntity GetByLogin(string login)
        {
            return _context.Set<LoginEntity>().AsNoTracking().FirstOrDefault(et => et.Login == login);
        }

        public IList<LoginEntity> List()
        {
            return _context.Set<LoginEntity>().AsNoTracking().ToList();
        }

        public LoginEntity Insert(LoginEntity entity)
        {
            LoginEntity ret = _context.Set<LoginEntity>().Add(entity).Entity;

            this.Save();

            return ret;
        }

        public LoginEntity Update(LoginEntity entity)
        {
            LoginEntity ret = _context.Set<LoginEntity>().Update(entity).Entity;

            this.Save();

            return ret;
        }

        public LoginEntity Delete(LoginEntity entity)
        {
            LoginEntity ret = _context.Set<LoginEntity>().Remove(entity).Entity;

            this.Save();

            return ret;
        }
    }
}
