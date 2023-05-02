using System;

namespace rcManagerUserDomain
{
    public class UserModel : UserEntity
    {
        public UserModel() { }

        public UserModel(UserModel model)
        {
            if (model != null) {
                this.Id = Id;
                this.Login = Login;
                this.Password = Password;
                this.Name = Name;
                this.Description = Description;
                this.Status = Status;
                this.CreatedAt = CreatedAt;
                this.UpdatedAt = UpdatedAt;
            }
        }

        public UserModel(long id, string login, string password, string name, string description, 
            bool status, DateTime createdAt, DateTime updatedAt)
        {
            this.create(id, login, password, name, description, status, createdAt, updatedAt);
        }

        public UserModel(UserEntity entity)
        {
            this.create(entity);
        }

        private void create(UserEntity entity)
        {
            if (entity == null) {
                throw new ArgumentException("[User] não pode ser nulo", "User");
            }

            this.create(entity.Id, entity.Login, entity.Password, entity.Name, entity.Description, 
                entity.Status, entity.CreatedAt, entity.UpdatedAt);
        }

        private void create(long id, string login, string password, string name, string description,
            bool status, DateTime createdAt, DateTime updatedAt)
        {
            if (id < 0) {
                throw new ArgumentException("Campo [id] deve ser maior ou igual a zero", "id");
            }

            if (name == null) {
                throw new ArgumentException("Campo [name] deve estar preenchido", "name");
            } else {
                name = name.Trim();

                if (String.IsNullOrWhiteSpace(name)) {
                    throw new ArgumentException("Campo [name] deve estar preenchido", "name");
                }

                if (name.Length < 3) {
                    throw new ArgumentException("Campo [name] deve possuir no mínimo 3 caracteres", "name");
                }
            }

            if (description != null) {
                description = description.Trim();

                if (String.IsNullOrWhiteSpace(description)) {
                    this.Description = null;
                } else if (description.Length < 3) {
                    throw new ArgumentException("Campo [description] deve possuir no mínimo 3 caracteres", "description");
                }
            }

            this.Id = id;
            this.Login = login;
            this.Password = password;
            this.Name = name;
            this.Description = description;
            this.Status = status;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
        }

        public UserEntity toEntity()
        {
            return new UserEntity() {
                Id = this.Id,
                Login = this.Login,
                Password = this.Password,
                Name = this.Name,
                Description = this.Description,
                Status = this.Status,
                CreatedAt = this.CreatedAt,
                UpdatedAt = this.UpdatedAt
            };
        }
    }
}
