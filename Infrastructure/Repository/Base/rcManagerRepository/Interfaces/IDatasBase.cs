using System.Collections.Generic;

namespace rcManagerRepositoryBase.Interfaces
{
    public interface IDatasBase<Entity>
    {
        IList<Entity> List();
        Entity Get(long id);
        Entity Insert(Entity entity);
        Entity Update(Entity entity);
        Entity Delete(Entity entity);
    }
}
