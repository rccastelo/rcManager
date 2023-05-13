using System;
using System.Collections.Generic;

namespace rcManagerApplicationBase.Base
{
    [Serializable]
    public abstract class ResponseBase<TTransport>
    {
        private IList<string> _messages;
        protected TTransport _item;
        private IList<TTransport> _list;

        public ResponseBase()
        {
            this.IsValid = true;
            this.IsError = false;
        }

        public ResponseBase(ResponseBase<TTransport> response) : this()
        {
            if (response != null) {
                this.IsValid = response.IsValid;
                this.IsError = response.IsError;

                if ((response.Messages != null) && (response.Messages.Count > 0)) {
                    this._messages = new List<string>(response.Messages);
                }

                if ((response.List != null) && (response.List.Count > 0)) {
                    this._list = new List<TTransport>(response.List);
                }

                if (response.Item != null) {
                    this._item = (TTransport)Activator.CreateInstance(typeof(TTransport), response.Item);
                }
            }
        }

        public bool IsValid { get; set; }
        public bool IsError { get; set; }

        public IList<string> Messages
        {
            get { return this._messages; }
        }

        public TTransport Item
        {
            get { return this._item; }
        }

        public IList<TTransport> List
        {
            get { return this._list; }
        }

        public void AddMessage(string message)
        {
            if (!String.IsNullOrWhiteSpace(message)) {
                if (this._messages == null) this._messages = new List<string>();

                this._messages.Add(message);
            }
        }

        public void AddMessages(IList<string> messages)
        {
            if ((messages != null) && (messages.Count > 0)) {
                if (this._messages == null) this._messages = new List<string>();

                foreach (string message in messages) {
                    if (!String.IsNullOrWhiteSpace(message)) this._messages.Add(message);
                }
            }
        }

        public void AddTransport(TTransport transport)
        {
            if (transport != null) {
                if (this._list == null) this._list = new List<TTransport>();
                this.List.Add(transport);
            }
        }

        public void AddList(IList<TTransport> list)
        {
            if ((list != null) && (list.Count > 0)) {
                if (this._list == null) this._list = new List<TTransport>();

                foreach(TTransport transport in list) {
                    if (transport != null) this._list.Add(transport);
                }
            }
        }

        public void SetItem(TTransport item)
        {
            if (item != null) this._item = item;
        }
    }
}
