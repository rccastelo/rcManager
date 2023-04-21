using rcManagerDatabase;
using rcManagerDatas.Interfaces;
using rcManagerEntities.Entities;
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

        public void insert(Entity entity)
        {
            _context.Set<Entity>().Add(entity);
        }

        public void update(Entity entity)
        {
            _context.Set<Entity>().Update(entity);
        }

        public void delete(Entity entity)
        {
            _context.Set<Entity>().Remove(entity);
        }
    }
}
