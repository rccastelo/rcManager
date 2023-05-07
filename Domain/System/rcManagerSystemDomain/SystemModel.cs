using System;
using System.Collections.Generic;

namespace rcManagerSystemDomain
{
    public class SystemModel : SystemEntity
    {
        public bool IsValid { get; set; }
        public IList<string> Messages { get; private set; }

        public SystemModel()
        {
            IsValid = true;
            Messages = new List<string>();
        }

        public void AddMessage(string message)
        {
            if (!String.IsNullOrWhiteSpace(message)) { 
                if (Messages == null) Messages = new List<string>();

                this.Messages.Add(message);
            }
        }

        public void AddMessages(IList<string> messages)
        {
            if ((messages != null) && (messages.Count > 0)) {
                if (this.Messages == null) this.Messages = new List<string>();

                foreach (string m in messages) {
                    if (!String.IsNullOrWhiteSpace(m)) this.Messages.Add(m);
                }
            }
        }

        public SystemModel(SystemModel model) : this()
        {
            if (model != null) {
                this.Id = model.Id;
                this.Name = model.Name;
                this.Description = model.Description;
                this.Status = model.Status;
            }
        }

        public SystemModel(long id, string name, string description, bool status) : this()
        {
            this.create(id, name, description, status);
        }

        public SystemModel(SystemEntity entity) : this()
        {
            this.create(entity);
        }

        private void create(SystemEntity entity) 
        {
            if (entity == null) {
                throw new ArgumentException("[System] não pode ser nulo", "System");
            }

            this.create(entity.Id, entity.Name, entity.Description, entity.Status);
        }

        private void create(long id, string name, string description, bool status)
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

                if (name.Length < 3)
                {
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
            this.Name = name;
            this.Description = description;
            this.Status = status;
        }

        public SystemEntity ToEntity() 
        {
            return new SystemEntity() {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description,
                Status = this.Status
            };
        }
    }
}
