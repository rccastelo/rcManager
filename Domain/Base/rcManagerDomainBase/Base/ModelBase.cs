using System;
using System.Collections.Generic;

namespace rcManagerDomainBase.Base
{
    public abstract class ModelBase<TEntity, TRequest, TResponse>
    {
        protected TEntity _entity;
        protected IList<TEntity> _entities;
        protected IList<string> _messages;
        protected bool _validModel;

        protected ModelBase() { }

        protected ModelBase(ModelBase<TEntity, TRequest, TResponse> model)
        {
            if (model != null)
            {
                this.SetEntity(model._entity);
                this.AddEntities(model._entities);
                this.IsValidResponse = model.IsValidResponse;
                this.AddMessages(model._messages);
            }
        }

        protected ModelBase(TEntity entity)
        {
            if (entity != null) this.SetEntity(entity);
        }

        protected ModelBase(TRequest request)
        {
            if (request != null) this.SetEntity(request);
        }

        public TEntity Entity
        {
            get { return this._entity; }
        }

        public IList<TEntity> Entities
        {
            get { return this._entities; }
        }

        public TResponse ResponseItem
        {
            get { return this.GetResponseItem(); }
        }

        public IList<TResponse> ResponseList
        {
            get { return this.GetResponseList(); }
        }

        public bool IsValidResponse { get; set; }

        public IList<string> Messages
        {
            get { return this._messages; }
        }

        public bool IsValidModel
        {
            get { return this._validModel; }
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

        protected abstract void SetEntity(TRequest request);

        protected abstract TResponse GetResponseItem();

        protected abstract IList<TResponse> GetResponseList();

        protected abstract void ValidateModel();
    }
}
