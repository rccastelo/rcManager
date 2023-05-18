using rcCryptography;
using rcManagerDomainBase.Base;
using rcManagerUserDomain.Entities;
using rcManagerUserDomain.Transports;
using rcUtils;
using System.Collections.Generic;
using System.Linq;

namespace rcManagerUserDomain.Models
{
    public class LoginModel : ModelBase<LoginEntity, LoginRequestItem, LoginResponseItem>
    {
        public LoginModel() : base() { }

        public LoginModel(LoginModel model) : base(model) { }

        public LoginModel(LoginEntity entity) : base(entity) { }

        public LoginModel(LoginRequestItem request) : base(request) { }

        public LoginModel(long id, string login, string password, string confirmation, long userId)
        {
            this.SetEntity(id, login, password, confirmation, userId);
        }

        protected override void SetEntity(LoginEntity entity)
        {
            if (entity != null) {
                this.SetEntity(entity.Id, entity.Login, entity.Password, entity.Confirmation, entity.User_Id);
            }
        }

        protected override void SetEntity(LoginRequestItem request)
        {
            if (request != null) {
                this.SetEntity(request.Id, request.Login, request.Password, request.Confirmation, request.User_Id);
            }
        }

        private void SetEntity(long id, string login,
                string password, string confirmation, long userId)
        {
            this._entity = new LoginEntity() {
                Id = id,
                Login = login,
                Password = password,
                Confirmation = confirmation,
                User_Id = userId
            };
            this.ValidateModel();
            this.GenerateSecret();
        }

        protected override LoginResponseItem GetResponseItem()
        {
            if (this._entity == null) {
                return null;
            } else {
                return new LoginResponseItem() {
                    Id = this._entity.Id,
                    Login = this._entity.Login,
                    User_Id = this._entity.User_Id
                };
            }
        }

        protected override IList<LoginResponseItem> GetResponseList()
        {
            if ((this._entities == null) || (this._entities.Count <= 0)) {
                return null;
            } else {
                return this._entities.Select(et => new LoginResponseItem() {
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
                } else {
                    if ((this._entity.Login.Length < 3) || (this._entity.Login.Length > 30)) {
                        validity = false;
                        this.AddMessage("Campo [Login] deve possuir entre 3 e 30 caracteres");
                    }

                    if (!Validations.ValidateChars_Login(this._entity.Login)) {
                        validity = false;
                        this.AddMessage("Campo [Login] possui caracteres inválidos");
                        this.AddMessage("Caracteres válidos...");
                        this.AddMessage("Letras sem acento; Números; Traço -_");
                    }
                }
            }

            if (this._entity.Password == null) {
                validity = false;
                this.AddMessage("Campo [Password] não pode ser nulo");
            } else {
                if (string.IsNullOrWhiteSpace(this._entity.Password)) {
                    validity = false;
                    this.AddMessage("Campo [Password] deve estar preenchido");
                } else {
                    if ((this._entity.Password.Length < 3) || (this._entity.Password.Length > 30)) {
                        validity = false;
                        this.AddMessage("Campo [Password] deve possuir entre 3 e 30 caracteres");
                    }

                    if (!Validations.ValidateChars_Password(this._entity.Password)) {
                        validity = false;
                        this.AddMessage("Campo [Password] possui caracteres inválidos");
                        this.AddMessage("Caracteres válidos...");
                        this.AddMessage("Letras sem acento; Números; Especiais _?!@#$%&*.=+-");
                    }
                }
            }

            if (this._entity.Confirmation == null) {
                validity = false;
                this.AddMessage("Campo [Confirmation] não pode ser nulo");
            } else {
                if (string.IsNullOrWhiteSpace(this._entity.Confirmation)) {
                    validity = false;
                    this.AddMessage("Campo [Confirmation] deve estar preenchido");
                } else {
                    if ((this._entity.Confirmation.Length < 3) || (this._entity.Confirmation.Length > 30)) {
                        validity = false;
                        this.AddMessage("Campo [Confirmation] deve possuir entre 3 e 30 caracteres");
                    }

                    if (!Validations.ValidateChars_Password(this._entity.Confirmation)) {
                        validity = false;
                        this.AddMessage("Campo [Confirmation] possui caracteres inválidos");
                        this.AddMessage("Caracteres válidos...");
                        this.AddMessage("Letras sem acento; Números; Especiais _?!@#$%&*.=+-");
                    }
                }
            }

            if ((validity) && (_entity.Password != _entity.Confirmation)) {
                validity = false;
                this.AddMessage("Campo [Password] e [Confirmation] devem ser iguais");
            }

            this._validModel = validity;
        }
    }
}
