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

        public Entity get(long id)
        {
            return _context.Set<Entity>().AsNoTracking().SingleOrDefault(et => et.id == id);
        }

        public IList<Entity> list()
        {
            return _context.Set<Entity>().AsNoTracking().ToList();
        }

        public Entity insert(Entity entity)
        {
            return _context.Set<Entity>().Add(entity).Entity;
        }

        public virtual Entity update(Entity entity)
        {
            return _context.Set<Entity>().Update(entity).Entity;
        }

        public Entity delete(Entity entity)
        {
            return _context.Set<Entity>().Remove(entity).Entity;
        }

        public void detach(Entity entity) 
        {
            _context.Entry<Entity>(entity).State = EntityState.Detached;
        }

        public void save()
        {
            this._context.SaveChanges();

            foreach(EntityEntry entry in this._context.ChangeTracker.Entries()) {
                entry.State = EntityState.Detached;
            }
        }

        public void cancel()
        {
            foreach (EntityEntry entry in this._context.ChangeTracker.Entries())
            {
                entry.State = EntityState.Detached;
            }
        }
    }
}
