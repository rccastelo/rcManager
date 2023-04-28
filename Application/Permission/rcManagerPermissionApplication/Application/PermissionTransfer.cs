using rcManagerApplicationBase.Base;
using rcManagerPermissionDomain;
using System;

namespace rcManagerPermissionApplication.Application
{
    [Serializable]
    public class PermissionTransfer : TransferBase<PermissionModel>
    {
        public PermissionTransfer() : base() { }

        public PermissionTransfer(PermissionTransfer transfer) : base(transfer) { }
    }
}
