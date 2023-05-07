using Microsoft.EntityFrameworkCore;
using rcDbSqlServerEF;
using rcManagerPermissionDomain;
using rcManagerPermissionRepository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace rcManagerPermissionRepository.Repository
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
            return _context.Set<PermissionEntity>().Add(entity).Entity;
        }

        public PermissionEntity Update(PermissionEntity entity)
        {
            return _context.Set<PermissionEntity>().Update(entity).Entity;
        }

        public PermissionEntity Delete(PermissionEntity entity)
        {
            return _context.Set<PermissionEntity>().Remove(entity).Entity;
        }
    }
}
