using rcManagerApplicationBase.Base;
using rcManagerSystemDomain;
using System;

namespace rcManagerSystemApplication.Application
{
    [Serializable]
    public class SystemTransfer : TransferBase<SystemModel>       
    {
        public SystemTransfer() : base() { }

        public SystemTransfer(SystemTransfer transfer) : base(transfer) { }
    }
}
