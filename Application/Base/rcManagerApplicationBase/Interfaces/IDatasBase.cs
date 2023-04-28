using System.Collections.Generic;

namespace rcManagerApplicationBase.Interfaces
{
    public interface IDatasBase<Entity>
    {
        IList<Entity> list();
        Entity get(long id);
        Entity insert(Entity entity);
        Entity update(Entity entity);
        Entity delete(Entity entity);
        void save();
        void cancel();
    }
}
