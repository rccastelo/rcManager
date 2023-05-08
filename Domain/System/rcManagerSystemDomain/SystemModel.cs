using System;
using System.Collections.Generic;

namespace rcManagerSystemDomain
{
    public class SystemModel
    {
        private SystemEntity _item = null;
        private IList<SystemEntity> _list = null;
        private IList<string> _messages = null;

        public SystemModel() { }

        public SystemModel(SystemModel model)
        {
            if (model != null) {
                this._item = model._item == null ? null : new SystemEntity(model._item);
                this._list = model._list == null ? null : new List<SystemEntity>(model._list);
                this.IsValid = model.IsValid;
                this._messages = model._messages == null ? null : new List<string>(model._messages);
            }
        }

        public SystemModel(long id, string name, string description, bool status)
        {
            this.SetItem(id, name, description, status);
        }

        public SystemModel(SystemEntity entity)
        {
            if (entity != null) this.SetItem(entity);
        }

        public SystemEntity Item
        {
            get { return this._item; }
            private set { }
        }

        public IList<SystemEntity> List
        {
            get { return this._list; }
            private set { }
        }

        public bool IsValid { get; set; }

        public IList<string> Messages
        {
            get { return this._messages; }
            private set { }
        }

        public bool ValidModel
        {
            get { return this.ValidateModel(); }
            private set { }
        }

        public void AddMessage(string message)
        {
            if (!string.IsNullOrWhiteSpace(message)) {
                if (this._messages == null) this._messages = new List<string>();

                this._messages.Add(message);
            }
        }

        public void AddMessages(IList<string> messages)
        {
            if ((messages != null) && (messages.Count > 0)) {
                if (this._messages == null) this._messages = new List<string>();

                foreach (string m in messages) {
                    if (!String.IsNullOrWhiteSpace(m)) this._messages.Add(m);
                }
            }
        }

        public void AddEntity(SystemEntity entity)
        {
            if (entity != null) {
                if (this._list == null) this._list = new List<SystemEntity>();

                this._list.Add(entity);
            }
        }

        public void AddEntities(IList<SystemEntity> entities)
        {
            if ((entities != null) && (entities.Count > 0)) {
                this._list = entities;
            }
        }

        private void SetItem(SystemEntity entity)
        {
            if (entity != null) {
                this.SetItem(entity.Id, entity.Name, entity.Description, entity.Status);
            }
        }

        private void SetItem(long id, string name, string description, bool status)
        {
            this._item = new SystemEntity() {
                Id = id,
                Name = name,
                Description = description,
                Status = status
            };
        }

        private bool ValidateModel()
        {
            bool validity = true;

            if (this._item.Id < 0) {
                validity = false;
                this.AddMessage("Campo [id] deve ser maior ou igual a zero");
            }

            if (this._item.Name == null) {
                validity = false;
                this.AddMessage("Campo [name] não pode ser nulo");
            } else {
                if (string.IsNullOrWhiteSpace(this._item.Name)) {
                    validity = false;
                    this.AddMessage("Campo [name] deve estar preenchido");
                }

                if (this._item.Name.Length < 3) {
                    validity = false;
                    this.AddMessage("Campo [name] deve possuir no mínimo 3 caracteres");
                }
            }

            if (this._item.Description != null) {
                if (string.IsNullOrWhiteSpace(this._item.Description)) {
                    validity = false;
                    this.AddMessage("Campo [description] deve estar preenchido");
                } else if (this._item.Description.Length < 3) {
                    validity = false;
                    this.AddMessage("Campo [description] deve possuir no mínimo 3 caracteres");
                }
            }

            return validity;
        }
    }
}