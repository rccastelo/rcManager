﻿using rcManagerApplicationBase.Base;
using rcManagerPermissionDomain.Transports;
using System;

namespace rcManagerPermissionApplication.Transport
{
    [Serializable]
    public class PermissionResponse : ResponseBase<PermissionTransport>
    {
        public PermissionResponse() : base() { }

        public PermissionResponse(PermissionResponse response) : base(response) { }
    }
}
