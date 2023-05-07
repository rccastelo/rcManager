using rcManagerPermissionDomain;
using System.Collections.Generic;

namespace rcManagerPermissionRepository.Interfaces
{
    public interface IPermissionRepository
    {
        IList<PermissionModel> List();
        PermissionModel Get(long id);
        PermissionModel Insert(PermissionModel model);
        PermissionModel Update(PermissionModel model);
        PermissionModel Delete(PermissionModel model);
    }
}
