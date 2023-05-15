using rcManagerDomainBase.Base;
using rcManagerUserDomain.Entities;
using rcManagerUserDomain.Transports;
using System;
using System.Collections.Generic;
using System.Linq;

namespace rcManagerUserDomain.Models
{
    public sealed class UserModel : ModelBase<UserEntity, UserRequestItem, UserResponseItem>
    {
        public UserModel() : base() { }

        public UserModel(UserModel model) : base(model) { } 

        public UserModel(UserEntity entity) : base(entity) { }

        public UserModel(UserRequestItem request) : base(request) { }

        public UserModel(long id, string name, string description, bool status)
        {
            this.SetEntity(id, name, description, status, DateTime.MinValue, DateTime.MinValue);
        }

        protected override void SetEntity(UserEntity entity)
        {
            if (entity != null) {
                this.SetEntity(entity.Id, entity.Name, entity.Description, entity.Status, 
                        entity.CreatedAt, entity.UpdatedAt);
            }
        }

        protected override void SetEntity(UserRequestItem request)
        {
            if (request != null) {
                this.SetEntity(request.Id, request.Name, request.Description, request.Status,
                        DateTime.MinValue, DateTime.MinValue);
            }
        }

        private void SetEntity(long id, string name, string description, bool status, 
                DateTime createdAt, DateTime updatedAt)
        {
            this._entity = new UserEntity() {
                Id = id,
                Name = name,
                Description = description,
                Status = status,
                CreatedAt = createdAt,
                UpdatedAt = updatedAt
            };
            this.ValidateModel();
        }

        protected override UserResponseItem GetResponseItem()
        {
            if (this._entity == null) {
                return null;
            } else {
                return new UserResponseItem() {
                    Id = this._entity.Id,
                    Description = this._entity.Description,
                    Name = this._entity.Name,
                    Status = this._entity.Status,
                    CreatedAt = this._entity.CreatedAt,
                    UpdatedAt = this._entity.UpdatedAt
                };
            }
        }

        protected override IList<UserResponseItem> GetResponseList()
        {
            if ((this._entities == null) || (this._entities.Count <= 0)) {
                return null;
            } else {
                return this._entities.Select(et => new UserResponseItem() {
                    Id = et.Id,
                    Description = et.Description,
                    Name = et.Name,
                    Status = et.Status,
                    CreatedAt = et.CreatedAt,
                    UpdatedAt = et.UpdatedAt
                }).ToList();
            }
        }

        protected override void ValidateModel()
        {
            bool validity = true;
            this._messages = null;

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

            this._validModel = validity;
        }
    }
}
