using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rcManagerEntities.Entities
{
    [Serializable]
    [Table("Systems")]
    public class SystemEntity
    {
        [Column("id", Order = 1)]
        [Required]
        [Key]
        public long id { get; set; }

        [Column("name", Order = 2)]
        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Column("description", Order = 3)]
        [StringLength(200)]
        public string description { get; set; }

        [Column("status", Order = 4)]
        [Required]
        public bool status { get; set; }

        public SystemEntity() { }

        public SystemEntity(SystemEntity entity) 
        {
            if (entity != null)
            {
                this.id = entity.id;
                this.name = entity.name;
                this.description = entity.description;
                this.status = entity.status;
            }
        }
    }
}
