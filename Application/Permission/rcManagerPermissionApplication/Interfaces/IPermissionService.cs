﻿using rcManagerPermissionApplication.Transport;

namespace rcManagerPermissionApplication.Interfaces
{
    public interface IPermissionService
    {
        PermissionResponse List();
        PermissionResponse Get(long id);
        PermissionResponse Insert(PermissionRequest permissionRequest);
        PermissionResponse Update(PermissionRequest permissionRequest);
        PermissionResponse Delete(long id);
    }
}
