using rcManagerApplicationBase.Base;
using rcManagerUserDomain.Transports;
using System;

namespace rcManagerUserApplication.Transport
{
    [Serializable]
    public class PasswordResponse : ResponseBase<PasswordResponseItem>
    {
        public PasswordResponse() : base() { }

        public PasswordResponse(PasswordResponse response) : base(response) { }
    }
}
