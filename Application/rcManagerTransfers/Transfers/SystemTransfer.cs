using rcManagerModels.Models;
using System;

namespace rcManagerTransfers.Transfers
{
    [Serializable]
    public class SystemTransfer : TransferBase<SystemModel>       
    {
        public SystemTransfer() : base() { }

        public SystemTransfer(SystemTransfer transfer) : base(transfer) { }
    }
}
