using rcManagerApplicationBase.Base;
using rcManagerUserDomain.Transports;

namespace rcManagerUserApplication.Transport
{
    public class UserPasswordResponse : ResponseBase<UserPasswordTransport>
    {
        public UserPasswordResponse() : base() { }

        public UserPasswordResponse(UserPasswordResponse response) : base(response) { }

        public void SetItem(UserTransport transport) 
        {
            if (this._item == null) this._item = new UserPasswordTransport();

            this._item.User = transport;
        }

        public  void SetItem(PasswordTransport transport)
        {
            if (this._item == null) this._item = new UserPasswordTransport();

            this._item.Password = transport;
        }
    }
}
