using Microsoft.EntityFrameworkCore;
using rcDbSqlServerEF;
using rcManagerPermissionDomain.Entities;
using rcManagerPermissionRepository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace rcManagerPermissionRepository.Datas
{
    public class PermissionData : DataEF, IPermissionData
    {
        public PermissionData(ManagerDbContext context) : base(context) { }

        public PermissionEntity Get(long id)
        {
            return _context.Set<PermissionEntity>().AsNoTracking().SingleOrDefault(et => et.Id == id);
        }

        public IList<PermissionEntity> List()
        {
            return _context.Set<PermissionEntity>().AsNoTracking().ToList();
        }

        public PermissionEntity Insert(PermissionEntity entity)
        {
            PermissionEntity ret = _context.Set<PermissionEntity>().Add(entity).Entity;

            this.Save();

            return ret;
        }

        public PermissionEntity Update(PermissionEntity entity)
        {
            PermissionEntity ret = _context.Set<PermissionEntity>().Update(entity).Entity;

            this.Save();

            return ret;
        }

        public PermissionEntity Delete(PermissionEntity entity)
        {
            PermissionEntity ret = _context.Set<PermissionEntity>().Remove(entity).Entity;

            this.Save();

            return ret;
        }
    }
}
