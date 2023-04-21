using rcManagerDatabase;
using rcManagerDatas.Interfaces;
using rcManagerEntities;
using System.Collections.Generic;
using System.Linq;

namespace rcManagerDatas.Datas
{
    public abstract class DatasBase<Entity> : IDatasBase<Entity> where Entity : EntityBase
    {
        public readonly ManagerDbContext _context;

        public DatasBase(ManagerDbContext context)
        {
            this._context = context;
        }

        public Entity get(long id)
        {
            return _context.Set<Entity>().SingleOrDefault(et => et.id == id);
        }

        public IList<Entity> list()
        {
            return _context.Set<Entity>().ToList();
        }

        public Entity insert(Entity entity)
        {
            return _context.Set<Entity>().Add(entity).Entity;
        }

        public Entity update(Entity entity)
        {
            return _context.Set<Entity>().Update(entity).Entity;
        }

        public Entity delete(Entity entity)
        {
            return _context.Set<Entity>().Remove(entity).Entity;
        }

        public void save()
        {
            this._context.SaveChanges();
        }
    }
}
