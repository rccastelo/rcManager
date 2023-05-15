using rcCryptography;
using rcManagerDomainBase.Base;
using rcManagerUserDomain.Entities;
using rcManagerUserDomain.Transports;
using System.Collections.Generic;
using System.Linq;

namespace rcManagerUserDomain.Models
{
    public class PasswordModel : ModelBase<PasswordEntity, PasswordRequestItem, PasswordResponseItem>
    {
        public PasswordModel() : base() { }

        public PasswordModel(PasswordModel model) : base(model) { }

        public PasswordModel(PasswordEntity entity) : base(entity) { }

        public PasswordModel(PasswordRequestItem request) : base(request) { }

        public PasswordModel(long id, string login, string password, string confirmation, long userId)
        {
            this.SetEntity(id, login, password, confirmation, userId);
        }

        protected override void SetEntity(PasswordEntity entity)
        {
            if (entity != null) {
                this.SetEntity(entity.Id, entity.Login, entity.Password, entity.Confirmation, entity.User_Id);
            }
        }

        protected override void SetEntity(PasswordRequestItem request)
        {
            if (request != null) {
                this.SetEntity(request.Id, request.Login, request.Password, request.Confirmation, request.User_Id);
            }
        }

        private void SetEntity(long id, string login,
                string password, string confirmation, long userId)
        {
            this._entity = new PasswordEntity() {
                Id = id,
                Login = login,
                Password = password,
                Confirmation = confirmation,
                User_Id = userId
            };
            this.ValidateModel();
            this.GenerateSecret();
        }

        protected override PasswordResponseItem GetResponseItem()
        {
            if (this._entity == null) {
                return null;
            } else {
                return new PasswordResponseItem() {
                    Id = this._entity.Id,
                    Login = this._entity.Login,
                    User_Id = this._entity.User_Id
                };
            }
        }

        protected override IList<PasswordResponseItem> GetResponseList()
        {
            if ((this._entities == null) || (this._entities.Count <= 0)) {
                return null;
            } else {
                return this._entities.Select(et => new PasswordResponseItem() {
                    Id = et.Id,
                    Login = et.Login,
                    User_Id = et.User_Id
                }).ToList();
            }
        }

        private void GenerateSecret() 
        {
            if ((this._entity != null) &&
                ((!string.IsNullOrWhiteSpace(this._entity.Login)) && 
                (!string.IsNullOrWhiteSpace(this._entity.Password)))) {
                this._entity.Secret = Crypto.GetSecretSHA512(this._entity.Login + this._entity.Password);
            }
        }

        protected override void ValidateModel()
        {
            bool validity = true;
            this._messages = null;

            if (this._entity.Id < 0) {
                validity = false;
                this.AddMessage("Campo [Id] deve ser maior ou igual a zero");
            }

            if (this._entity.Login == null) {
                validity = false;
                this.AddMessage("Campo [Login] não pode ser nulo");
            } else {
                if (string.IsNullOrWhiteSpace(this._entity.Login)) {
                    validity = false;
                    this.AddMessage("Campo [Login] deve estar preenchido");
                }

                if (this._entity.Login.Length < 3) {
                    validity = false;
                    this.AddMessage("Campo [Login] deve possuir no mínimo 3 caracteres");
                }
            }

            if (this._entity.Password == null) {
                validity = false;
                this.AddMessage("Campo [Password] não pode ser nulo");
            } else {
                if (string.IsNullOrWhiteSpace(this._entity.Password)) {
                    validity = false;
                    this.AddMessage("Campo [Password] deve estar preenchido");
                }

                if (this._entity.Password.Length < 3) {
                    validity = false;
                    this.AddMessage("Campo [Password] deve possuir no mínimo 3 caracteres");
                }
            }

            if (this._entity.Confirmation == null) {
                validity = false;
                this.AddMessage("Campo [Confirmation] não pode ser nulo");
            } else {
                if (string.IsNullOrWhiteSpace(this._entity.Confirmation)) {
                    validity = false;
                    this.AddMessage("Campo [Confirmation] deve estar preenchido");
                }

                if (this._entity.Confirmation.Length < 3) {
                    validity = false;
                    this.AddMessage("Campo [Confirmation] deve possuir no mínimo 3 caracteres");
                }
            }

            if (((!string.IsNullOrWhiteSpace(_entity.Password)) && (!string.IsNullOrWhiteSpace(_entity.Confirmation))) &&
                (_entity.Password != _entity.Confirmation))
            {
                validity = false;
                this.AddMessage("Campo [Password] e [Confirmation] não são iguais");
            }

            this._validModel = validity;
        }
    }
}
