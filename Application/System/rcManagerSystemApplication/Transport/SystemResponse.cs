using rcManagerApplicationBase.Base;
using rcManagerSystemDomain.Transports;
using System;

namespace rcManagerSystemApplication.Transport
{
    [Serializable]
    public class SystemResponse : ResponseBase<SystemTransport>
    {
        public SystemResponse() : base() { }

        public SystemResponse(SystemResponse response) : base(response) { }
    }
}
