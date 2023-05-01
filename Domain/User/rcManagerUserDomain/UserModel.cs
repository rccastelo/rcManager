using System;

namespace rcManagerUserDomain
{
    public class UserModel : UserEntity
    {
        public UserModel() { }

        public UserModel(UserModel model)
        {
            if (model != null) {
                this.id = id;
                this.login = login;
                this.password = password;
                this.name = name;
                this.description = description;
                this.status = status;
                this.createdAt = createdAt;
                this.updatedAt = updatedAt;
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

            this.create(entity.id, entity.login, entity.password, entity.name, entity.description, 
                entity.status, entity.createdAt, entity.updatedAt);
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
                    this.description = null;
                } else if (description.Length < 3) {
                    throw new ArgumentException("Campo [description] deve possuir no mínimo 3 caracteres", "description");
                }
            }

            this.id = id;
            this.login = login;
            this.password = password;
            this.name = name;
            this.description = description;
            this.status = status;
            this.createdAt = createdAt;
            this.updatedAt = updatedAt;
        }

        public UserEntity toEntity()
        {
            return new UserEntity() {
                id = this.id,
                login = this.login,
                password = this.password,
                name = this.name,
                description = this.description,
                status = this.status,
                createdAt = this.createdAt,
                updatedAt = this.updatedAt
            };
        }
    }
}
