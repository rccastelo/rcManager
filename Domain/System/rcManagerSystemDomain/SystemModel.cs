using rcManagerDomainBase.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace rcManagerSystemDomain
{
    public sealed class SystemModel : ModelBase<SystemEntity, SystemTransport>
    {
        public SystemModel() : base() { }

        public SystemModel(SystemModel model) : base(model) { }

        public SystemModel(SystemEntity entity) : base(entity) { }

        public SystemModel(SystemTransport transport) : base(transport) { }

        public SystemModel(long id, string name, string description, 
                bool status, DateTime createdAt, DateTime updatedAt)
        {
            this.SetEntity(id, name, description, status, createdAt, updatedAt);
        }

        protected override void SetEntity(SystemEntity entity)
        {
            if (entity != null) {
                this.SetEntity(entity.Id, entity.Name, entity.Description, 
                        entity.Status, entity.CreatedAt, entity.UpdatedAt);
            }
        }

        protected override void SetEntity(SystemTransport transport)
        {
            if (transport != null)
            {
                this.SetEntity(transport.Id, transport.Name, transport.Description,
                        transport.Status, transport.CreatedAt, transport.UpdatedAt);
            }
        }

        private void SetEntity(long id, string name, string description, 
                bool status, DateTime createdAt, DateTime updatedAt)
        {
            this._entity = new SystemEntity() {
                Id = id,
                Name = name,
                Description = description,
                Status = status,
                CreatedAt = createdAt,
                UpdatedAt = updatedAt
            };
        }

        protected override SystemTransport GetTransport()
        {
            if (this._entity == null) {
                return null;
            } else {
                return new SystemTransport() {
                    Id = this._entity.Id,
                    Description = this._entity.Description,
                    Name = this._entity.Name,
                    Status = this._entity.Status,
                    CreatedAt = this._entity.CreatedAt,
                    UpdatedAt = this._entity.UpdatedAt
                };
            }
        }

        protected override IList<SystemTransport> GetListTransport()
        {
            if ((this._entities == null) || (this._entities.Count <= 0)) {
                return null;
            } else {
                return this._entities.Select(et => new SystemTransport() {
                    Id = et.Id,
                    Description = et.Description,
                    Name = et.Name,
                    Status = et.Status,
                    CreatedAt = et.CreatedAt,
                    UpdatedAt = et.UpdatedAt
                }).ToList();
            }
        }

        protected override bool ValidateModel()
        {
            bool validity = true;

            if (this._entity.Id < 0) {
                validity = false;
                this.AddMessage("Campo [id] deve ser maior ou igual a zero");
            }

            if (this._entity.Name == null) {
                validity = false;
                this.AddMessage("Campo [name] não pode ser nulo");
            } else {
                if (string.IsNullOrWhiteSpace(this._entity.Name)) {
                    validity = false;
                    this.AddMessage("Campo [name] deve estar preenchido");
                }

                if (this._entity.Name.Length < 3) {
                    validity = false;
                    this.AddMessage("Campo [name] deve possuir no mínimo 3 caracteres");
                }
            }

            if (this._entity.Description != null) {
                if (string.IsNullOrWhiteSpace(this._entity.Description)) {
                    validity = false;
                    this.AddMessage("Campo [description] deve estar preenchido");
                } else if (this._entity.Description.Length < 3) {
                    validity = false;
                    this.AddMessage("Campo [description] deve possuir no mínimo 3 caracteres");
                }
            }

            return validity;
        }
    }
}
