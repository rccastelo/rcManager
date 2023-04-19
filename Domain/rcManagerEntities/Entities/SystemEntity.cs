using System;

namespace rcManagerEntities.Entities
{
    [Serializable]
    public class SystemEntity
    {
        public long id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public SystemEntity() { }

        public SystemEntity(SystemEntity entity) 
        {
            if (entity != null)
            {
                this.id = entity.id;
                this.name = entity.name;
                this.description = entity.description;
            }
        }
    }
}
