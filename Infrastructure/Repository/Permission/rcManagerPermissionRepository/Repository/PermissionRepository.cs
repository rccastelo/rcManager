using rcManagerPermissionDomain;
using rcManagerPermissionRepository.Interfaces;
using System.Collections.Generic;

namespace rcManagerPermissionRepository.Repository
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly IPermissionData _permissionData;

        public PermissionRepository(IPermissionData permissionData)
        {
            this._permissionData = permissionData;
        }

        public PermissionModel Get(long id)
        {
            PermissionModel ret = _permissionData.Get(id);

            return ret;
        }

        public IList<PermissionModel> List()
        {
            IList<PermissionModel> ret = _permissionData.List();

            return ret;
        }

        public PermissionModel Insert(PermissionModel model)
        {
            PermissionModel ret = _permissionData.Insert(model);

            _permissionData.Save();

            return ret;
        }

        public PermissionModel Update(PermissionModel model)
        {
            PermissionModel ret = _permissionData.Update(model);

            _permissionData.Save();

            return ret;
        }

        public PermissionModel Delete(PermissionModel model)
        {
            PermissionModel ret = _permissionData.Delete(model);

            _permissionData.Save();

            return ret;
        }
    }
}
