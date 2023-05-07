using rcManagerApplicationBase.Base;
using rcManagerSystemDomain;
using System;

namespace rcManagerSystemApplication.Transport
{
    [Serializable]
    public class SystemResponse : ResponseBase<SystemEntity>
    {
        public SystemResponse() : base() { }

        public SystemResponse(SystemResponse response) : base(response) { }
    }
}
