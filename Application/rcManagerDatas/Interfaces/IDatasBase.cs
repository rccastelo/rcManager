using System.Collections.Generic;

namespace rcManagerDatas.Interfaces
{
    public interface IDatasBase<Entity>
    {
        Entity get(long id);

        void insert(Entity entity);

        void update(Entity entity);

        void delete(Entity entity);

        IList<Entity> list();
    }
}
