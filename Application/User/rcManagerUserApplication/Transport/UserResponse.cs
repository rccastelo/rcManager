using rcManagerApplicationBase.Base;
using rcManagerUserDomain;
using System;

namespace rcManagerUserApplication.Transport
{
    [Serializable]
    public class UserResponse : ResponseBase<UserEntity>
    {
        public UserResponse() : base() { }

        public UserResponse(UserResponse response) : base(response) { }
    }
}
