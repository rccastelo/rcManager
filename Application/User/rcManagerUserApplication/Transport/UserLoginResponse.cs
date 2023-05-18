using rcManagerApplicationBase.Base;
using rcManagerUserDomain.Transports;

namespace rcManagerUserApplication.Transport
{
    public class UserLoginResponse : ResponseBase<UserLoginResponseItem>
    {
        public UserLoginResponse() : base() { }

        public UserLoginResponse(UserLoginResponse response) : base(response) { }

        public void SetItem(UserResponseItem response) 
        {
            if (this._item == null) this._item = new UserLoginResponseItem();

            this._item.User = response;
        }

        public  void SetItem(LoginResponseItem response)
        {
            if (this._item == null) this._item = new UserLoginResponseItem();

            this._item.Login = response;
        }
    }
}
