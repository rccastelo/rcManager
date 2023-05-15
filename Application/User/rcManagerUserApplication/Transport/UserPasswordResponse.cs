using rcManagerApplicationBase.Base;
using rcManagerUserDomain.Transports;

namespace rcManagerUserApplication.Transport
{
    public class UserPasswordResponse : ResponseBase<UserPasswordResponseItem>
    {
        public UserPasswordResponse() : base() { }

        public UserPasswordResponse(UserPasswordResponse response) : base(response) { }

        public void SetItem(UserResponseItem userResponse) 
        {
            if (this._item == null) this._item = new UserPasswordResponseItem();

            this._item.User = userResponse;
        }

        public  void SetItem(PasswordResponseItem passwordResponse)
        {
            if (this._item == null) this._item = new UserPasswordResponseItem();

            this._item.Password = passwordResponse;
        }
    }
}
