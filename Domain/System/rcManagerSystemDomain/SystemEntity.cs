using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rcManagerSystemDomain
{
    [Serializable]
    [Table("Systems")]
    public class SystemEntity
    {
        [Column("pk_id_system", Order = 1)]
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

        [Column("createdAt", Order = 5)]
        [Required]
        public DateTime CreatedAt { get; set; }

        [Column("updatedAt", Order = 6)]
        public DateTime UpdatedAt { get; set; }

        public SystemEntity() { }

        public SystemEntity(SystemEntity entity) 
        {
            if (entity != null) {
                this.Id = entity.Id;
                this.Name = entity.Name;
                this.Description = entity.Description;
                this.Status = entity.Status;
                this.CreatedAt = entity.CreatedAt;
                this.UpdatedAt = entity.UpdatedAt;
            }
        }
    }
}
