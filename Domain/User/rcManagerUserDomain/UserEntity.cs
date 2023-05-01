using rcManagerDomainBase.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rcManagerUserDomain
{
    [Serializable]
    [Table("Users")]
    public class UserEntity : EntityBase
    {
        [Column("login", Order = 2)]
        [Required]
        [StringLength(50)]
        public string login { get; set; }

        [Column("password", Order = 3)]
        [Required]
        [StringLength(200)]
        public string password { get; set; }

        [Column("name", Order = 4)]
        [StringLength(200)]
        public string name { get; set; }

        [Column("description", Order = 5)]
        [StringLength(200)]
        public string description { get; set; }

        [Column("status", Order = 6)]
        [Required]
        public bool status { get; set; }

        [Column("createdAt", Order = 7)]
        [Required]
        public DateTime createdAt { get; set; }

        [Column("updatedAt", Order = 8)]
        public DateTime updatedAt { get; set; }

        public UserEntity() { }

        public UserEntity(UserEntity entity)
        {
            if (entity != null)
            {
                this.id = entity.id;
                this.login = entity.login;
                this.password = entity.password;
                this.name = entity.name;
                this.description = entity.description;
                this.status = entity.status;
                this.createdAt = entity.createdAt;
                this.updatedAt = entity.updatedAt;
            }
        }
    }
}
