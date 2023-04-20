using System;
using System.Collections.Generic;

namespace rcManagerTransfers.Transfers
{
    [Serializable]
    public abstract class TransferBase<T>
    {
        public bool valid { get; set; }
        public bool error { get; set; }
        public IList<string> messages { get; set; }
        public T entity { get; set; }
        public IList<T> list { get; set; }

        public TransferBase()
        {
            this.valid = true;
            this.error = false;
        }

        public TransferBase(TransferBase<T> transfer)
        {
            if (transfer != null)
            {
                this.valid = transfer.valid;
                this.error = transfer.error;

                if (transfer.messages != null)
                {
                    this.messages = new List<string>(transfer.messages);
                }

                if (transfer.list != null)
                {
                    this.list = new List<T>(transfer.list);
                }

                if (transfer.entity != null)
                {
                    this.entity = (T)Activator.CreateInstance(typeof(T), transfer.entity);
                }
            }
        }

        public void addMessage(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                if (this.messages == null)
                {
                    this.messages = new List<string>();
                }

                this.messages.Add(message);
            }
        }

        public void addEntity(T entity)
        {
            if (entity != null)
            {
                if (this.list == null)
                {
                    this.list = new List<T>();
                }

                this.list.Add(entity);
            }
        }
    }
}
