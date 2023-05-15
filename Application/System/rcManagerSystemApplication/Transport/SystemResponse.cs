using rcManagerApplicationBase.Base;
using rcManagerSystemDomain.Transports;
using System;

namespace rcManagerSystemApplication.Transport
{
    [Serializable]
    public class SystemResponse : ResponseBase<SystemResponseItem>
    {
        public SystemResponse() : base() { }

        public SystemResponse(SystemResponse response) : base(response) { }
    }
}
