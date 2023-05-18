using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rcManagerUserDomain.Entities
{
    [Serializable]
    [Table("Login")]
    public class LoginEntity
    {
        [Column("pk_id_login", Order = 1)]
        [Required]
        [Key]
        public long Id { get; set; }

        [Column("login", Order = 2)]
        [Required]
        [StringLength(50)]
        public string Login { get; set; }

        [Column("secret", Order = 3)]
        [StringLength(300)]
        public string Secret { get; set; }

        [Column("fk_user_id", Order = 4)]
        [Required]
        public long User_Id { get; set; }

        [ForeignKey("User_Id")]
        public UserEntity UserEntity { get; set; }

        [NotMapped]
        [StringLength(50)]
        public string Password { get; set; }

        [NotMapped]
        [StringLength(50)]
        public string Confirmation { get; set; }

        public LoginEntity() { }

        public LoginEntity(LoginEntity entity)
        {
            if (entity != null) {
                this.Id = entity.Id;
                this.Login = entity.Login;
                this.User_Id = entity.User_Id;
                this.Password = entity.Password;
                this.Confirmation = entity.Confirmation;
            }
        }
    }
}
