﻿using rcManagerSystemApplication.Transport;

namespace rcManagerSystemApplication.Interfaces
{
    public interface ISystemService
    {
        SystemResponse List();
        SystemResponse Get(long id);
        SystemResponse Insert(SystemRequest systemRequest);
        SystemResponse Update(SystemRequest systemRequest);
        SystemResponse Delete(long id);
    }
}
