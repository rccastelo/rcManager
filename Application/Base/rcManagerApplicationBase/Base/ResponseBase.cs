using System;
using System.Collections.Generic;

namespace rcManagerApplicationBase.Base
{
    [Serializable]
    public abstract class ResponseBase<TResponse>
    {
        private IList<string> _messages;
        protected TResponse _item;
        private IList<TResponse> _list;

        public ResponseBase()
        {
            this.IsValid = true;
            this.IsError = false;
        }

        public ResponseBase(ResponseBase<TResponse> response) : this()
        {
            if (response != null) {
                this.IsValid = response.IsValid;
                this.IsError = response.IsError;
                this.AddMessages(response.Messages);
                this.AddList(response.List);
                this.SetItem(response.Item);
            }
        }

        public bool IsValid { get; set; }
        public bool IsError { get; set; }

        public IList<string> Messages
        {
            get { return this._messages; }
        }

        public TResponse Item
        {
            get { return this._item; }
        }

        public IList<TResponse> List
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

        public void AddItem(TResponse item)
        {
            if (item != null) {
                if (this._list == null) this._list = new List<TResponse>();
                this.List.Add(item);
            }
        }

        public void AddList(IList<TResponse> list)
        {
            if ((list != null) && (list.Count > 0)) {
                if (this._list == null) this._list = new List<TResponse>();

                foreach(TResponse item in list) {
                    if (item != null) this._list.Add(item);
                }
            }
        }

        public void SetItem(TResponse item)
        {
            if (item != null) this._item = item;
        }
    }
}
