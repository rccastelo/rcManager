using rcManagerApplicationBase.Base;
using rcManagerUserDomain.Transports;
using System;

namespace rcManagerUserApplication.Transport
{
    [Serializable]
    public class UserResponse : ResponseBase<UserTransport>
    {
        public UserResponse() : base() { }

        public UserResponse(UserResponse response) : base(response) { }
    }
}
