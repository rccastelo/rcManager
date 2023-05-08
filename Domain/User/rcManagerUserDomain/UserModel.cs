using System;
using System.Collections.Generic;

namespace rcManagerUserDomain
{
    public class UserModel
    {
        private UserEntity _item = null;
        private IList<UserEntity> _list = null;
        private IList<string> _messages = null;

        public UserModel() { }

        public UserModel(UserModel model)
        {
            if (model != null) {
                this._item = model._item == null ? null : new UserEntity(model._item);
                this._list = model._list == null ? null : new List<UserEntity>(model._list);
                this.IsValid = model.IsValid;
                this._messages = model._messages == null ? null : new List<string>(model._messages);
            }
        }

        public UserModel(long id, string login, string password, string name, string description, 
                bool status, DateTime createdAt, DateTime updatedAt)
        {
            this.SetItem(id, login, password, name, description, status, createdAt, updatedAt);
        }

        public UserModel(UserEntity entity)
        {
            if (entity != null) this.SetItem(entity);
        }

        public UserEntity Item
        {
            get { return this._item; }
            private set { }
        }

        public IList<UserEntity> List
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

        public void AddEntity(UserEntity entity)
        {
            if (entity != null) {
                if (this._list == null) this._list = new List<UserEntity>();

                this._list.Add(entity);
            }
        }

        public void AddEntities(IList<UserEntity> entities)
        {
            if ((entities != null) && (entities.Count > 0)) {
                this._list = entities;
            }
        }

        private void SetItem(UserEntity entity)
        {
            if (entity != null) {
                this.SetItem(entity.Id, entity.Login, entity.Password, entity.Name, entity.Description,
                        entity.Status, entity.CreatedAt, entity.UpdatedAt);
            }
        }

        private void SetItem(long id, string login, string password, string name, string description,
                bool status, DateTime createdAt, DateTime updatedAt)
        {
            this._item = new UserEntity() {
                Id = id,
                Name = name,
                Description = description,
                Status = status,
                Login = login,
                Password = password,
                CreatedAt = createdAt,
                UpdatedAt = updatedAt
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
                if (String.IsNullOrWhiteSpace(this._item.Name)) {
                    validity = false;
                    this.AddMessage("Campo [name] deve estar preenchido");
                }

                if (this._item.Name.Length < 3) {
                    validity = false;
                    this.AddMessage("Campo [name] deve possuir no mínimo 3 caracteres");
                }
            }

            if (this._item.Description != null) {
                if (String.IsNullOrWhiteSpace(this._item.Description)) {
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
