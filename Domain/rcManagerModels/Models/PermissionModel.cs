using rcManagerEntities.Entities;
using System;

namespace rcManagerModels.Models
{
    public class PermissionModel : PermissionEntity
    {
        public PermissionModel() { }

        public PermissionModel(PermissionModel model)
        {
            if (model != null) {
                this.id = model.id;
                this.user_id = model.user_id;
                this.system_id = model.system_id;
                this.date_from = model.date_from;
                this.date_to = model.date_to;
                this.status = model.status;
                this.weekday = model.weekday;
                this.weekend = model.weekend;
                this.start_time = model.start_time;
                this.end_time = model.end_time;
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

            this.create(entity.id, entity.user_id, entity.system_id, entity.date_from, entity.date_to, entity.status, entity.weekday, entity.weekend, entity.start_time, entity.end_time);
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

            this.id = id;
            this.user_id = user_id;
            this.system_id = system_id;
            this.date_from = date_from;
            this.date_to = date_to;
            this.status = status;
            this.weekday = weekday;
            this.weekend = weekend;
            this.start_time = start_time;
            this.end_time = end_time;
        }

        public PermissionEntity toEntity()
        {
            return new PermissionEntity() {
                id = this.id,
                user_id = this.user_id,
                system_id = this.system_id,
                date_from = this.date_from,
                date_to = this.date_to,
                status = this.status,
                weekday = this.weekday,
                weekend = this.weekend,
                start_time = this.start_time,
                end_time = this.end_time
            };
        }
    }
}
