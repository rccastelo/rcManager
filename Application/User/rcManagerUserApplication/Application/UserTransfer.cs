using rcManagerApplicationBase.Base;
using rcManagerUserDomain;
using System;

namespace rcManagerUserApplication.Application
{
    [Serializable]
    public class UserTransfer : TransferBase<UserModel>
    {
        public UserTransfer() : base() { }

        public UserTransfer(UserTransfer transfer) : base(transfer) { }
    }
}
