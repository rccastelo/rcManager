using rcManagerEntities.Entities;
using System;

namespace rcManagerModels.Models
{
    public class SystemModel : SystemEntity
    {
        public SystemModel()
        {
        }

        public SystemModel(SystemModel model)
        {
            if (model != null) {
                this.id = model.id;
                this.name = model.name;
                this.description = model.description;
                this.status = model.status;
            }
        }

        public SystemModel(long id, string name, string description, bool status)
        {
            this.create(id, name, description, status);
        }

        public SystemModel(SystemEntity entity)
        {
            if (entity != null)
                this.create(entity);
        }

        private void create(SystemEntity entity) 
        {
            if (entity == null) 
                throw new ArgumentException("System não pode ser nulo", "System");

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

        public SystemEntity toEntity() 
        {
            return new SystemEntity()
            {
                id = this.id,
                name = this.name,
                description = this.description,
                status = this.status
            };
        }
    }
}
