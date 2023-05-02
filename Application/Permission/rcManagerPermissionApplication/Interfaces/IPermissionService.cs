using rcManagerPermissionApplication.Application;

namespace rcManagerPermissionApplication.Interfaces
{
    public interface IPermissionService
    {
        PermissionTransfer List(PermissionTransfer permissionTransfer);
        PermissionTransfer Get(long id);
        PermissionTransfer Insert(PermissionTransfer permissionTransfer);
        PermissionTransfer Update(PermissionTransfer permissionTransfer);
        PermissionTransfer Delete(long id);
    }
}
