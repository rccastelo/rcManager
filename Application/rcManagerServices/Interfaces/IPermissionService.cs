using rcManagerTransfers.Transfers;

namespace rcManagerServices.Interfaces
{
    public interface IPermissionService
    {
        PermissionTransfer list(PermissionTransfer permissionTransfer);
        PermissionTransfer get(long id);
        PermissionTransfer insert(PermissionTransfer permissionTransfer);
        PermissionTransfer update(PermissionTransfer permissionTransfer);
        PermissionTransfer delete(long id);
    }
}
