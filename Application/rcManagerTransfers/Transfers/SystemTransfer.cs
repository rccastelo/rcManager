using rcManagerEntities.Entities;
using System;

namespace rcManagerTransfers.Transfers
{
    [Serializable]
    public class SystemTransfer : TransferBase<SystemEntity>       
    {
        public SystemTransfer() : base() { }

        public SystemTransfer(SystemTransfer transfer) : base(transfer) { }
    }
}
