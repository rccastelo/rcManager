using rcManagerApplicationBase.Base;
using rcManagerPermissionDomain;
using System;

namespace rcManagerPermissionApplication.Transport
{
    [Serializable]
    public class PermissionResponse : ResponseBase<PermissionEntity>
    {
        public PermissionResponse() : base() { }

        public PermissionResponse(PermissionResponse response) : base(response) { }
    }
}
