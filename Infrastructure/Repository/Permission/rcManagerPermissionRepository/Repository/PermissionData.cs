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

        public PermissionModel Get(long id)
        {
            PermissionModel model = null;

            PermissionEntity entity = _context.Set<PermissionEntity>().AsNoTracking().SingleOrDefault(et => et.Id == id);

            if (entity != null) {
                model = new PermissionModel(entity);
            }

            return model;
        }

        public IList<PermissionModel> List()
        {
            IList<PermissionModel> listMod = null;

            IList<PermissionEntity> listEnt = _context.Set<PermissionEntity>().AsNoTracking().ToList();

            if (listEnt != null) {
                listMod = listEnt.Select(et => new PermissionModel(et)).ToList();
            }

            return listMod;
        }

        public PermissionModel Insert(PermissionModel model)
        {
            PermissionModel modelRet = null;

            PermissionEntity entity = _context.Set<PermissionEntity>().Add(model.toEntity()).Entity;

            if (entity != null) {
                modelRet = new PermissionModel(entity);
            }

            return modelRet;
        }

        public PermissionModel Update(PermissionModel model)
        {
            PermissionModel modelRet = null;

            PermissionEntity entity = _context.Set<PermissionEntity>().Update(model.toEntity()).Entity;

            if (entity != null) {
                modelRet = new PermissionModel(entity);
            }

            return modelRet;
        }

        public PermissionModel Delete(PermissionModel model)
        {
            PermissionModel modelRet = null;

            PermissionEntity entity = _context.Set<PermissionEntity>().Remove(model.toEntity()).Entity;

            if (entity != null) {
                modelRet = new PermissionModel(entity);
            }

            return modelRet;
        }
    }
}
