using System;
using System.Collections.Generic;

namespace rcManagerApplicationBase.Base
{
    [Serializable]
    public abstract class TransferBase<T>
    {
        public bool Valid { get; set; }
        public bool Error { get; set; }
        public IList<string> Messages { get; set; }
        public T Item { get; set; }
        public IList<T> List { get; set; }

        public TransferBase()
        {
            this.Valid = true;
            this.Error = false;
        }

        public TransferBase(TransferBase<T> transfer)
        {
            if (transfer != null)
            {
                this.Valid = transfer.Valid;
                this.Error = transfer.Error;

                if (transfer.Messages != null)
                {
                    this.Messages = new List<string>(transfer.Messages);
                }

                if (transfer.List != null)
                {
                    this.List = new List<T>(transfer.List);
                }

                if (transfer.Item != null)
                {
                    this.Item = (T)Activator.CreateInstance(typeof(T), transfer.Item);
                }
            }
        }

        public void AddMessage(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                if (this.Messages == null)
                {
                    this.Messages = new List<string>();
                }

                this.Messages.Add(message);
            }
        }

        public void AddModel(T model)
        {
            if (model != null)
            {
                if (this.List == null)
                {
                    this.List = new List<T>();
                }

                this.List.Add(model);
            }
        }
    }
}
