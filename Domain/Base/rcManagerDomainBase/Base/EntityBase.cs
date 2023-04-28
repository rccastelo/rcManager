using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rcManagerDomainBase.Base
{
    [Serializable]
    public abstract class EntityBase
    {
        [Column("id", Order = 1)]
        [Required]
        [Key]
        public long id { get; set; }

        public EntityBase()
        {
        }

        public EntityBase(int id)
        {
            this.id = id;
        }

        public EntityBase(EntityBase entity)
        {
            if (entity != null)
            {
                this.id = entity.id;
            }
        }
    }
}
