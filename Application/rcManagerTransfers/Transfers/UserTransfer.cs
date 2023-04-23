using rcManagerModels.Models;
using System;

namespace rcManagerTransfers.Transfers
{
    [Serializable]
    public class UserTransfer : TransferBase<UserModel>
    {
        public UserTransfer() : base() { }

        public UserTransfer(UserTransfer transfer) : base(transfer) { }
    }
}
