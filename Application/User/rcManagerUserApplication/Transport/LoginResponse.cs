using rcManagerApplicationBase.Base;
using rcManagerUserDomain.Transports;
using System;

namespace rcManagerUserApplication.Transport
{
    [Serializable]
    public class LoginResponse : ResponseBase<LoginResponseItem>
    {
        public LoginResponse() : base() { }

        public LoginResponse(LoginResponse response) : base(response) { }
    }
}
