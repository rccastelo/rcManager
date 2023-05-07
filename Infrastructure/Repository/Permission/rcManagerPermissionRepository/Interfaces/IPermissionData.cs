using rcManagerPermissionDomain;
using System.Collections.Generic;

namespace rcManagerPermissionRepository.Interfaces
{
    public interface IPermissionData
    {
        PermissionModel Get(long id);
        IList<PermissionModel> List();
        PermissionModel Insert(PermissionModel model);
        PermissionModel Update(PermissionModel model);
        PermissionModel Delete(PermissionModel model);
        void Save();
    }
}
