﻿using rcManagerTransfers.Transfers;

namespace rcManagerServices.Interfaces
{
    public interface IUserService
    {
        UserTransfer list(UserTransfer userTransfer);
        UserTransfer get(long id);
        UserTransfer insert(UserTransfer userTransfer);
        UserTransfer update(UserTransfer userTransfer);
        UserTransfer delete(long id);
    }
}
