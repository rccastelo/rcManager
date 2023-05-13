using rcManagerDomainBase.Base;
using rcManagerUserDomain.Entities;
using rcManagerUserDomain.Transports;
using System.Collections.Generic;
using System.Linq;

namespace rcManagerUserDomain.Models
{
    public class PasswordModel : ModelBase<PasswordEntity, PasswordTransport>
    {
        public PasswordModel() : base() { }

        public PasswordModel(PasswordModel model) : base(model) { }

        public PasswordModel(PasswordEntity entity) : base(entity) { }

        public PasswordModel(PasswordTransport transport) : base(transport) { }

        public PasswordModel(long id, string login, string secret,
                string password, string confirmation, long userId)
        {
            this.SetEntity(id, login, secret, password, confirmation, userId);
        }

        protected override void SetEntity(PasswordEntity entity)
        {
            if (entity != null) this._entity = new PasswordEntity(entity);
        }

        protected override void SetEntity(PasswordTransport transport)
        {
            if (transport != null) {
                this.SetEntity(transport.Id, transport.Login, string.Empty,
                        transport.Password, transport.Confirmation, transport.User_Id);
            }
        }

        private void SetEntity(long id, string login, string secret,
                string password, string confirmation, long userId)
        {
            this._entity = new PasswordEntity() {
                Id = id,
                Login = login,
                Secret = secret,
                Password = password,
                Confirmation = confirmation,
                User_Id = userId
            };
        }

        protected override PasswordTransport GetTransport()
        {
            if (this._entity == null) {
                return null;
            } else {
                return new PasswordTransport() {
                    Id = this._entity.Id,
                    Login = this._entity.Login,
                    Password = this._entity.Password,
                    Confirmation = this._entity.Confirmation,
                    User_Id = this._entity.User_Id
                };
            }
        }

        protected override IList<PasswordTransport> GetListTransport()
        {
            if ((this._entities == null) || (this._entities.Count <= 0)) {
                return null;
            } else {
                return this._entities.Select(et => new PasswordTransport() {
                    Id = et.Id,
                    Login = et.Login,
                    Password = et.Password,
                    Confirmation = et.Confirmation,
                    User_Id = et.User_Id
                }).ToList();
            }
        }

        protected override bool ValidateModel()
        {
            bool validity = true;

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
            
            return validity;
        }
    }
}
