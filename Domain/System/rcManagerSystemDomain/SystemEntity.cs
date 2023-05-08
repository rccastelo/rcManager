using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rcManagerSystemDomain
{
    [Serializable]
    [Table("Systems")]
    public class SystemEntity
    {
        [Column("id", Order = 1)]
        [Required]
        [Key]
        public long Id { get; set; }

        [Column("name", Order = 2)]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column("description", Order = 3)]
        [StringLength(200)]
        public string Description { get; set; }

        [Column("status", Order = 4)]
        [Required]
        public bool Status { get; set; }

        public SystemEntity() { }

        public SystemEntity(SystemEntity entity) 
        {
            if (entity != null)
            {
                this.Id = entity.Id;
                this.Name = entity.Name;
                this.Description = entity.Description;
                this.Status = entity.Status;
            }
        }
    }
}
