using rcManagerPermissionDomain;
using System.Collections.Generic;

namespace rcManagerPermissionRepository.Interfaces
{
    public interface IPermissionRepository
    {
        PermissionModel List();
        PermissionModel Get(long id);
        PermissionModel Insert(PermissionModel model);
        PermissionModel Update(PermissionModel model);
        PermissionModel Delete(long id);
    }
}
