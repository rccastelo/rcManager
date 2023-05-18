﻿using rcManagerDomainBase.Base;
using rcManagerSystemDomain.Entities;
using rcManagerSystemDomain.Transports;
using rcUtils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace rcManagerSystemDomain.Models
{
    public sealed class SystemModel : ModelBase<SystemEntity, SystemRequestItem, SystemResponseItem>
    {
        public SystemModel() : base() { }

        public SystemModel(SystemModel model) : base(model) { }

        public SystemModel(SystemEntity entity) : base(entity) { }

        public SystemModel(SystemRequestItem request) : base(request) { }

        public SystemModel(long id, string name, string description, bool status)
        {
            this.SetEntity(id, name, description, status, DateTime.MinValue, DateTime.MinValue);
        }

        protected override void SetEntity(SystemEntity entity)
        {
            if (entity != null) {
                this.SetEntity(entity.Id, entity.Name, entity.Description, entity.Status, 
                        entity.CreatedAt, entity.UpdatedAt);
            }
        }

        protected override void SetEntity(SystemRequestItem request)
        {
            if (request != null) {
                this.SetEntity(request.Id, request.Name, request.Description, request.Status,
                        DateTime.MinValue, DateTime.MinValue);
            }
        }

        private void SetEntity(long id, string name, string description, bool status, 
                DateTime createdAt, DateTime updatedAt)
        {
            this._entity = new SystemEntity() {
                Id = id,
                Name = name,
                Description = description,
                Status = status,
                CreatedAt = createdAt,
                UpdatedAt = updatedAt
            };
            this.ValidateModel();
        }

        protected override SystemResponseItem GetResponseItem()
        {
            if (this._entity == null) {
                return null;
            } else {
                return new SystemResponseItem() {
                    Id = this._entity.Id,
                    Description = this._entity.Description,
                    Name = this._entity.Name,
                    Status = this._entity.Status,
                    CreatedAt = this._entity.CreatedAt,
                    UpdatedAt = this._entity.UpdatedAt
                };
            }
        }

        protected override IList<SystemResponseItem> GetResponseList()
        {
            if ((this._entities == null) || (this._entities.Count <= 0)) {
                return null;
            } else {
                return this._entities.Select(et => new SystemResponseItem() {
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
                this.AddMessage("Campo [Id] deve ser maior ou igual a zero");
            }

            if (this._entity.Name == null) {
                validity = false;
                this.AddMessage("Campo [Name] não pode ser nulo");
            } else {
                if (string.IsNullOrWhiteSpace(this._entity.Name)) {
                    validity = false;
                    this.AddMessage("Campo [Name] deve estar preenchido");
                } else {
                    if ((this._entity.Name.Length < 3) || (this._entity.Name.Length > 30)) {
                        validity = false;
                        this.AddMessage("Campo [Name] deve possuir entre 3 e 30 caracteres");
                    }

                    if (!Validations.ValidateChars_Name(this._entity.Name)) {
                        validity = false;
                        this.AddMessage("Campo [Name] possui caracteres inválidos");
                        this.AddMessage("Caracteres válidos...");
                        this.AddMessage("Letras; Números; Traço; Espaço");
                    }
                }
            }

            if (this._entity.Description != null) {
                if (string.IsNullOrWhiteSpace(this._entity.Description)) {
                    validity = false;
                    this.AddMessage("Campo [Description] deve estar preenchido");
                } else if ((this._entity.Description.Length < 3) || (this._entity.Description.Length > 200)) {
                    validity = false;
                    this.AddMessage("Campo [Description] deve possuir entre 3 e 200 caracteres");
                }
            }

            this._validModel = validity;
        }
    }
}
