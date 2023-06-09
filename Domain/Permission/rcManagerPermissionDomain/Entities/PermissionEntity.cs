﻿using rcManagerSystemDomain.Entities;
using rcManagerUserDomain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rcManagerPermissionDomain.Entities
{
    [Serializable]
    [Table("Permissions")]
    public class PermissionEntity
    {
        [Column("pk_id_permission", Order = 1)]
        [Required]
        [Key]
        public long Id { get; set; }

        [Column("fk_user_id", Order = 2)]
        [Required]
        public long User_Id { get; set; }

        [Column("fk_system_id", Order = 3)]
        [Required]
        public long System_Id { get; set; }

        [Column("status", Order = 4)]
        [Required]
        public bool Status { get; set; }

        [Column("date_from", Order = 5)]
        [Required]
        public DateTime DateFrom { get; set; }

        [Column("date_to", Order = 6)]
        [Required]
        public DateTime DateTo { get; set; }

        [Column("weekday", Order = 7)]
        [Required]
        public bool Weekday { get; set; }

        [Column("weekend", Order = 8)]
        [Required]
        public bool Weekend { get; set; }

        [Column("start_time", Order = 9)]
        [Required]
        public TimeSpan StartTime { get; set; }

        [Column("end_time", Order = 10)]
        [Required]
        public TimeSpan EndTime { get; set; }

        [ForeignKey("User_Id")]
        public UserEntity UserEntity { get; set; }

        [ForeignKey("System_Id")]
        public SystemEntity SystemEntity { get; set; }

        public PermissionEntity() { }

        public PermissionEntity(PermissionEntity entity)
        {
            if (entity != null) {
                this.Id = entity.Id;
                this.User_Id = entity.User_Id;
                this.System_Id = entity.System_Id;
                this.DateFrom = entity.DateFrom;
                this.DateTo = entity.DateTo;
                this.Status = entity.Status;
                this.Weekday = entity.Weekday;
                this.Weekend = entity.Weekend;
                this.StartTime = entity.StartTime;
                this.EndTime = entity.EndTime;
            }
        }
    }
}
