using System;
using System.Collections.Generic;

namespace rcManagerApplicationBase.Base
{
    [Serializable]
    public abstract class ResponseBase<T>
    {
        public bool IsValid { get; set; }
        public bool Error { get; set; }
        public IList<string> Messages { get; set; }
        public T Item { get; set; }
        public IList<T> List { get; set; }

        public ResponseBase()
        {
            this.IsValid = true;
            this.Error = false;
            this.Messages = new List<string>();
        }

        public ResponseBase(ResponseBase<T> response) : this()
        {
            if (response != null)
            {
                this.IsValid = response.IsValid;
                this.Error = response.Error;

                if (response.Messages != null) {
                    this.Messages = new List<string>(response.Messages);
                }

                if (response.List != null) {
                    this.List = new List<T>(response.List);
                }

                if (response.Item != null) {
                    this.Item = (T)Activator.CreateInstance(typeof(T), response.Item);
                }
            }
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

        public void AddEntity(T entity)
        {
            if (entity != null) {
                if (this.List == null) {
                    this.List = new List<T>();
                }

                this.List.Add(entity);
            }
        }
    }
}
