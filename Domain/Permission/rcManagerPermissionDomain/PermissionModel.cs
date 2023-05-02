﻿using System;

namespace rcManagerPermissionDomain
{
    public class PermissionModel : PermissionEntity
    {
        public PermissionModel() { }

        public PermissionModel(PermissionModel model)
        {
            if (model != null) {
                this.Id = model.Id;
                this.User_Id = model.User_Id;
                this.System_Id = model.System_Id;
                this.DateFrom = model.DateFrom;
                this.DateTo = model.DateTo;
                this.Status = model.Status;
                this.Weekday = model.Weekday;
                this.Weekend = model.Weekend;
                this.StartTime = model.StartTime;
                this.EndTime = model.EndTime;
            }
        }

        public PermissionModel(long id, long user_id, long system_id, DateTime date_from, DateTime date_to, bool status, bool weekday,bool weekend, TimeSpan start_time, TimeSpan end_time)
        {
            this.create(id, user_id, system_id, date_from, date_to, status, weekday, weekend, start_time, end_time);
        }

        public PermissionModel(PermissionEntity entity)
        {
            this.create(entity);
        }

        private void create(PermissionEntity entity)
        {
            if (entity == null) {
                throw new ArgumentException("[Permission] não pode ser nulo", "Permission");
            }

            this.create(entity.Id, entity.User_Id, entity.System_Id, entity.DateFrom, entity.DateTo, entity.Status, entity.Weekday, entity.Weekend, entity.StartTime, entity.EndTime);
        }

        private void create(long id, long user_id, long system_id, DateTime date_from, DateTime date_to, bool status, bool weekday, bool weekend, TimeSpan start_time, TimeSpan end_time)
        {
            if (id < 0) {
                throw new ArgumentException("Campo [id] deve ser maior ou igual a zero", "id");
            }

            if (user_id < 0) {
                throw new ArgumentException("Campo [user_id] deve ser maior ou igual a zero", "user_id");
            }

            if (system_id < 0) {
                throw new ArgumentException("Campo [system_id] deve ser maior ou igual a zero", "system_id");
            }

            //if (name == null)
            //{
            //    throw new ArgumentException("Campo [name] deve estar preenchido", "name");
            //}
            //else
            //{
            //    name = name.Trim();

            //    if (String.IsNullOrWhiteSpace(name))
            //    {
            //        throw new ArgumentException("Campo [name] deve estar preenchido", "name");
            //    }

            //    if (name.Length < 3)
            //    {
            //        throw new ArgumentException("Campo [name] deve possuir no mínimo 3 caracteres", "name");
            //    }
            //}

            //if (description != null)
            //{
            //    description = description.Trim();

            //    if (String.IsNullOrWhiteSpace(description))
            //    {
            //        this.description = null;
            //    }
            //    else if (description.Length < 3)
            //    {
            //        throw new ArgumentException("Campo [description] deve possuir no mínimo 3 caracteres", "description");
            //    }
            //}

            this.Id = id;
            this.User_Id = user_id;
            this.System_Id = system_id;
            this.DateFrom = date_from;
            this.DateTo = date_to;
            this.Status = status;
            this.Weekday = weekday;
            this.Weekend = weekend;
            this.StartTime = start_time;
            this.EndTime = end_time;
        }

        public PermissionEntity toEntity()
        {
            return new PermissionEntity() {
                Id = this.Id,
                User_Id = this.User_Id,
                System_Id = this.System_Id,
                DateFrom = this.DateFrom,
                DateTo = this.DateTo,
                Status = this.Status,
                Weekday = this.Weekday,
                Weekend = this.Weekend,
                StartTime = this.StartTime,
                EndTime = this.EndTime
            };
        }
    }
}
