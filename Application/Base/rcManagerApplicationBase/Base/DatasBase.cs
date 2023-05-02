using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using rcManagerApplicationBase.Interfaces;
using rcManagerDatabase.EF;
using rcManagerDomainBase.Base;
using System.Collections.Generic;
using System.Linq;

namespace rcManagerApplicationBase.Base
{
    public abstract class DatasBase<Entity> : IDatasBase<Entity> where Entity : EntityBase
    {
        private readonly ManagerDbContext _context;

        protected DatasBase(ManagerDbContext context)
        {
            this._context = context;
        }

        public Entity Get(long id)
        {
            return _context.Set<Entity>().AsNoTracking().SingleOrDefault(et => et.Id == id);
        }

        public IList<Entity> List()
        {
            return _context.Set<Entity>().AsNoTracking().ToList();
        }

        public Entity Insert(Entity entity)
        {
            return _context.Set<Entity>().Add(entity).Entity;
        }

        public virtual Entity Update(Entity entity)
        {
            return _context.Set<Entity>().Update(entity).Entity;
        }

        public Entity Delete(Entity entity)
        {
            return _context.Set<Entity>().Remove(entity).Entity;
        }

        public void Save()
        {
            this._context.SaveChanges();

            foreach(EntityEntry entry in this._context.ChangeTracker.Entries()) {
                entry.State = EntityState.Detached;
            }
        }
    }
}
