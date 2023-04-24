using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rcManagerEntities.Entities
{
    [Serializable]
    [Table("Permissions")]
    public class PermissionEntity : EntityBase
    {
        [Column("user_id", Order = 2)]
        [Required]
        public long user_id { get; set; }

        [Column("system_id", Order = 3)]
        [Required]
        public long system_id { get; set; }

        [Column("status", Order = 4)]
        [Required]
        public bool status { get; set; }

        [Column("date_from", Order = 5)]
        [Required]
        public DateTime date_from { get; set; }

        [Column("date_to", Order = 6)]
        [Required]
        public DateTime date_to { get; set; }

        [Column("weekday", Order = 7)]
        [Required]
        public bool weekday { get; set; }

        [Column("weekend", Order = 8)]
        [Required]
        public bool weekend { get; set; }

        [Column("start_time", Order = 9)]
        [Required]
        public TimeSpan start_time { get; set; }

        [Column("end_time", Order = 10)]
        [Required]
        public TimeSpan end_time { get; set; }

        [ForeignKey("user_id")]
        public UserEntity UserEntity { get; set; }

        [ForeignKey("system_id")]
        public SystemEntity SystemEntity { get; set; }

        public PermissionEntity() { }

        public PermissionEntity(PermissionEntity entity)
        {
            if (entity != null)
            {
                this.id = entity.id;
                this.user_id = entity.user_id;
                this.system_id = entity.system_id;
                this.date_from = entity.date_from;
                this.date_to = entity.date_to;
                this.status = entity.status;
                this.weekday = entity.weekday;
                this.weekend = entity.weekend;
                this.start_time = entity.start_time;
                this.end_time = entity.end_time;
            }
        }
    }
}
