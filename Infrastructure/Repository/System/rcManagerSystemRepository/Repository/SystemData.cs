using Microsoft.EntityFrameworkCore;
using rcDbSqlServerEF;
using rcManagerSystemDomain;
using rcManagerSystemRepository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace rcManagerSystemRepository.Repository
{
    public class SystemData : DataEF, ISystemData
    {
        public SystemData(ManagerDbContext context) : base(context) { }

        public SystemModel Get(long id)
        {
            SystemModel model = null;

            SystemEntity entity = _context.Set<SystemEntity>().AsNoTracking().SingleOrDefault(et => et.Id == id);

            if (entity != null) {
                model = new SystemModel(entity);
            }

            return model;
        }

        public IList<SystemModel> List()
        {
            IList<SystemModel> listMod = null;

            IList<SystemEntity> listEnt = _context.Set<SystemEntity>().AsNoTracking().ToList();

            if (listEnt != null) {
                listMod = listEnt.Select(et => new SystemModel(et)).ToList();
            }

            return listMod;
        }

        public SystemModel Insert(SystemModel model)
        {
            SystemModel modelRet = null;

            SystemEntity entity = _context.Set<SystemEntity>().Add(model.toEntity()).Entity;

            if (entity != null) {
                modelRet = new SystemModel(entity);
            }

            return modelRet;
        }

        public SystemModel Update(SystemModel model)
        {
            SystemModel modelRet = null;

            SystemEntity entity = _context.Set<SystemEntity>().Update(model.toEntity()).Entity;

            if (entity != null) {
                modelRet = new SystemModel(entity);
            }

            return modelRet;
        }

        public SystemModel Delete(SystemModel model)
        {
            SystemModel modelRet = null;

            SystemEntity entity = _context.Set<SystemEntity>().Remove(model.toEntity()).Entity;

            if (entity != null) {
                modelRet = new SystemModel(entity);
            }

            return modelRet;
        }
    }
}
