using System;
using System.Collections.Generic;

namespace rcManagerDomainBase.Base
{
    public abstract class ModelBase<TEntity, TTransport>
    {
        protected TEntity _entity;
        protected IList<TEntity> _entities;
        protected IList<string> _messages;

        protected ModelBase() { }

        protected ModelBase(ModelBase<TEntity, TTransport> model)
        {
            if (model != null)
            {
                if (model._entity != null) {
                    this._entity = (TEntity)Activator.CreateInstance(typeof(TEntity), model._entity);
                }
                this._entities = model._entities == null ? null : new List<TEntity>(model._entities);
                this.IsValidResponse = model.IsValidResponse;
                this._messages = model._messages == null ? null : new List<string>(model._messages);
            }
        }

        protected ModelBase(TEntity entity)
        {
            if (entity != null) this.SetEntity(entity);
        }

        protected ModelBase(TTransport trasnsport)
        {
            if (trasnsport != null) this.SetEntity(trasnsport);
        }

        public TEntity Entity
        {
            get { return this._entity; }
        }

        public IList<TEntity> Entities
        {
            get { return this._entities; }
        }

        public TTransport Transport
        {
            get { return this.GetTransport(); }
        }

        public IList<TTransport> TransportList
        {
            get { return this.GetListTransport(); }
        }

        public bool IsValidResponse { get; set; }

        public IList<string> Messages
        {
            get { return this._messages; }
        }

        public bool IsValidModel
        {
            get { return this.ValidateModel(); }
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

        public void AddEntity(TEntity entity)
        {
            if (entity != null) {
                if (this._entities == null) this._entities = new List<TEntity>();
                this._entities.Add(entity);
            }
        }

        public void AddEntities(IList<TEntity> entities)
        {
            if ((entities != null) && (entities.Count > 0)) {
                if (this._entities == null) this._entities = new List<TEntity>();

                foreach (TEntity entity in entities) {
                    if (entity != null) this._entities.Add(entity);
                }
            }
        }

        protected abstract void SetEntity(TEntity entity);

        protected abstract void SetEntity(TTransport transport);

        protected abstract TTransport GetTransport();

        protected abstract IList<TTransport> GetListTransport();

        protected abstract bool ValidateModel();
    }
}
