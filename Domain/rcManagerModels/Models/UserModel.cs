using rcManagerEntities.Entities;
using System;

namespace rcManagerModels.Models
{
    public class UserModel : UserEntity
    {
        public UserModel()
        {
        }

        public UserModel(UserModel model)
        {
            if (model != null)
            {
                this.id = model.id;
                this.name = model.name;
                this.description = model.description;
                this.status = model.status;
            }
        }

        public UserModel(long id, string name, string description, bool status)
        {
            this.create(id, name, description, status);
        }

        public UserModel(UserEntity entity)
        {
            if (entity != null)
                this.create(entity);
        }

        private void create(UserEntity entity)
        {
            if (entity == null)
                throw new ArgumentException("User não pode ser nulo", "User");

            this.create(entity.id, entity.name, entity.description, entity.status);
        }

        private void create(long id, string name, string description, bool status)
        {
            if (id < 0)
                throw new ArgumentException("Campo id deve ser maior ou igual a zero", "id");

            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Campo name deve estar preenchido", "name");

            if (String.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Campo description deve estar preenchido", "description");

            this.id = id;
            this.name = name;
            this.description = description;
            this.status = status;
        }

        public UserEntity toEntity()
        {
            return new UserEntity()
            {
                id = this.id,
                name = this.name,
                description = this.description,
                status = this.status
            };
        }
    }
}
