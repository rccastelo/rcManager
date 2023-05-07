﻿using Microsoft.EntityFrameworkCore;
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
            return _context.Set<SystemEntity>().Add(entity).Entity;
        }

        public SystemEntity Update(SystemEntity entity)
        {
            return _context.Set<SystemEntity>().Update(entity).Entity;
        }

        public SystemEntity Delete(SystemEntity entity)
        {
            return _context.Set<SystemEntity>().Remove(entity).Entity;
        }
    }
}
