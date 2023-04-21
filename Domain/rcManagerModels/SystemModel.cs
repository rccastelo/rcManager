using rcManagerEntities.Entities;
using System;

namespace rcManagerModels
{
    public class SystemModel : SystemEntity
    {
        public SystemModel()
        {
        }

        public SystemModel(SystemEntity entity)
        {
            this.create(entity);
        }

        public SystemModel(long id, string name, string description, bool status)
        {
            this.create(id, name, description, status);
        }

        private void create(SystemEntity entity) 
        {
            if (entity == null) 
                throw new ArgumentException("O objeto [System] não pode ser nulo", "System");

            this.create(entity.id, entity.name, entity.description, entity.status);
        }

        private void create(long id, string name, string description, bool status)
        {
            if (id <= 0)
                throw new ArgumentException("Campo [id] deve ser maior que zero", "id");

            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Campo [name] deve estar preenchido", "name");

            if (String.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Campo [description] deve estar preenchido", "description");

            this.id = id;
            this.name = name;
            this.description = description;
            this.status = status;
        }
    }
}
