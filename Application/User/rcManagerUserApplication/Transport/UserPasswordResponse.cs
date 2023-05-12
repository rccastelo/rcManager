using rcManagerApplicationBase.Base;
using rcManagerUserDomain;

namespace rcManagerUserApplication.Transport
{
    public class UserPasswordResponse : ResponseBase<UserPasswordTransport>
    {
        public UserPasswordResponse() : base() { }

        public UserPasswordResponse(UserPasswordResponse response) : base(response) { }
    }
}
