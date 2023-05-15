using rcManagerDomainBase.Base;
using rcManagerPermissionDomain.Entities;
using rcManagerPermissionDomain.Transports;
using System;
using System.Collections.Generic;
using System.Linq;

namespace rcManagerPermissionDomain.Models
{
    public sealed class PermissionModel : ModelBase<PermissionEntity, PermissionRequestItem, PermissionResponseItem>
    {
        public PermissionModel() : base() { }

        public PermissionModel(PermissionModel model) : base(model) { }

        public PermissionModel(PermissionEntity entity) : base(entity) { }

        public PermissionModel(PermissionRequestItem request) : base(request) { }

        public PermissionModel(long id, long user_id, long system_id, DateTime date_from, DateTime date_to, 
                bool status, bool weekday,bool weekend, TimeSpan start_time, TimeSpan end_time)
        {
            this.SetEntity(id, user_id, system_id, date_from, date_to, status, weekday, weekend, start_time, end_time);
        }

        protected override void SetEntity(PermissionEntity entity)
        {
            if (entity != null) {
                this.SetEntity(entity.Id, entity.User_Id, entity.System_Id, entity.DateFrom, entity.DateTo,
                        entity.Status, entity.Weekday, entity.Weekend, entity.StartTime, entity.EndTime);
            }
        }

        protected override void SetEntity(PermissionRequestItem request)
        {
            if (request != null) {
                this.SetEntity(request.Id, request.User_Id, request.System_Id, request.DateFrom, request.DateTo,
                        request.Status, request.Weekday, request.Weekend, request.StartTime, request.EndTime);
            }
        }

        private void SetEntity(long id, long user_id, long system_id, DateTime date_from, DateTime date_to, 
                bool status, bool weekday, bool weekend, TimeSpan start_time, TimeSpan end_time)
        {
            this._entity = new PermissionEntity() {
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
            this.ValidateModel();
        }

        protected override PermissionResponseItem GetResponseItem()
        {
            if (this._entity == null) {
                return null;
            } else {
                return new PermissionResponseItem() {
                    Id = this._entity.Id,
                    User_Id = this._entity.User_Id,
                    System_Id = this._entity.System_Id,
                    DateFrom = this._entity.DateFrom,
                    DateTo = this._entity.DateTo,
                    Status = this._entity.Status,
                    Weekday = this._entity.Weekday,
                    Weekend = this._entity.Weekend,
                    StartTime = this._entity.StartTime,
                    EndTime = this._entity.EndTime
                };
            }
        }

        protected override IList<PermissionResponseItem> GetResponseList()
        {
            if ((this._entities == null) || (this._entities.Count <= 0)) {
                return null;
            } else {
                return this._entities.Select(et => new PermissionResponseItem() {
                    Id = et.Id,
                    User_Id = et.User_Id,
                    System_Id = et.System_Id,
                    DateFrom = et.DateFrom,
                    DateTo = et.DateTo,
                    Status = et.Status,
                    Weekday = et.Weekday,
                    Weekend = et.Weekend,
                    StartTime = et.StartTime,
                    EndTime = et.EndTime
                }).ToList();
            }
        }

        protected override void ValidateModel()
        {
            bool validity = true;
            this._messages = null;

            if (this._entity.Id < 0) {
                validity = false;
                this.AddMessage("Campo [id] deve ser maior ou igual a zero");
            }

            if (this._entity.User_Id < 0) {
                validity = false;
                this.AddMessage("Campo [user_id] deve ser maior ou igual a zero");
            }

            if (this._entity.System_Id < 0) {
                validity = false;
                this.AddMessage("Campo [system_id] deve ser maior ou igual a zero");
            }

            this._validModel = validity;
        }
    }
}
