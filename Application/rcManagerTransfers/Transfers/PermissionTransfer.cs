using rcManagerModels.Models;
using System;

namespace rcManagerTransfers.Transfers
{
    [Serializable]
    public class PermissionTransfer : TransferBase<PermissionModel>
    {
        public PermissionTransfer() : base() { }

        public PermissionTransfer(PermissionTransfer transfer) : base(transfer) { }
    }
}
