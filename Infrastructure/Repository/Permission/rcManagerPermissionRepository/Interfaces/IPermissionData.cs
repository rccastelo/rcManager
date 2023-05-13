using rcManagerPermissionDomain.Entities;
using System.Collections.Generic;

namespace rcManagerPermissionRepository.Interfaces
{
    public interface IPermissionData
    {
        PermissionEntity Get(long id);
        IList<PermissionEntity> List();
        PermissionEntity Insert(PermissionEntity entity);
        PermissionEntity Update(PermissionEntity model);
        PermissionEntity Delete(PermissionEntity model);
        void Save();
    }
}
