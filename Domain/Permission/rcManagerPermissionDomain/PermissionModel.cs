using System;
using System.Collections.Generic;

namespace rcManagerPermissionDomain
{
    public class PermissionModel
    {
        private PermissionEntity _item = null;
        private IList<PermissionEntity> _list = null;
        private IList<string> _messages = null;

        public PermissionModel() { }

        public PermissionModel(PermissionModel model)
        {
            if (model != null) {
                this._item = model._item == null ? null : new PermissionEntity(model._item);
                this._list = model._list == null ? null : new List<PermissionEntity>(model._list);
                this.IsValid = model.IsValid;
                this._messages = model._messages == null ? null : new List<string>(model._messages);
            }
        }

        public PermissionModel(long id, long user_id, long system_id, DateTime date_from, DateTime date_to, 
                bool status, bool weekday,bool weekend, TimeSpan start_time, TimeSpan end_time)
        {
            this.SetItem(id, user_id, system_id, date_from, date_to, status, weekday, weekend, start_time, end_time);
        }

        public PermissionModel(PermissionEntity entity)
        {
            if (entity != null) this.SetItem(entity);
        }


        public PermissionEntity Item
        {
            get { return this._item; }
            private set { }
        }

        public IList<PermissionEntity> List
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

        public void AddEntity(PermissionEntity entity)
        {
            if (entity != null) {
                if (this._list == null) this._list = new List<PermissionEntity>();

                this._list.Add(entity);
            }
        }

        public void AddEntities(IList<PermissionEntity> entities)
        {
            if ((entities != null) && (entities.Count > 0)) {
                this._list = entities;
            }
        }

        private void SetItem(PermissionEntity entity)
        {
            if (entity != null) {
                this.SetItem(entity.Id, entity.User_Id, entity.System_Id, entity.DateFrom, entity.DateTo, 
                        entity.Status, entity.Weekday, entity.Weekend, entity.StartTime, entity.EndTime);
            }
        }

        private void SetItem(long id, long user_id, long system_id, DateTime date_from, DateTime date_to, 
                bool status, bool weekday, bool weekend, TimeSpan start_time, TimeSpan end_time)
        {
            this._item = new PermissionEntity() {
                Id = id,
                User_Id = user_id,
                System_Id = system_id,
                DateFrom = date_from,
                DateTo = date_to,
                Status = status,
                Weekday = weekday,
                Weekend = weekend,
                StartTime = start_time,
                EndTime = end_time
            };
        }

        private bool ValidateModel()
        {
            bool validity = true;

            if (this._item.Id < 0) {
                validity = false;
                this.AddMessage("Campo [id] deve ser maior ou igual a zero");
            }

            if (this._item.User_Id < 0) {
                validity = false;
                this.AddMessage("Campo [user_id] deve ser maior ou igual a zero");
            }

            if (this._item.System_Id < 0) {
                validity = false;
                this.AddMessage("Campo [system_id] deve ser maior ou igual a zero");
            }

            return validity;
        }
    }
}
