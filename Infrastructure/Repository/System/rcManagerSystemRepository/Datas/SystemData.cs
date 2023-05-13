using Microsoft.EntityFrameworkCore;
using rcDbSqlServerEF;
using rcManagerSystemDomain.Entities;
using rcManagerSystemRepository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace rcManagerSystemRepository.Datas
{
    public class SystemData : DataEF, ISystemData
    {
        public SystemData(ManagerDbContext context) : base(context) { }

        public SystemEntity Get(long id)
        {
            return _context.Set<SystemEntity>().AsNoTracking().SingleOrDefault(et => et.Id == id);
        }

        public IList<SystemEntity> List()
        {
            return _context.Set<SystemEntity>().AsNoTracking().ToList();
        }

        public SystemEntity Insert(SystemEntity entity)
        {
            SystemEntity ret = _context.Set<SystemEntity>().Add(entity).Entity;

            this.Save();

            return ret;
        }

        public SystemEntity Update(SystemEntity entity)
        {
            SystemEntity ret = _context.Set<SystemEntity>().Update(entity).Entity;

            this.Save();

            return ret;
        }

        public SystemEntity Delete(SystemEntity entity)
        {
            SystemEntity ret = _context.Set<SystemEntity>().Remove(entity).Entity;

            this.Save();

            return ret;
        }
    }
}
