using rcManagerSystemDomain;
using rcManagerSystemRepository.Interfaces;
using System.Collections.Generic;

namespace rcManagerSystemRepository.Repository
{
    public class SystemRepository : ISystemRepository
    {
        private readonly ISystemData _systemData;

        public SystemRepository(ISystemData systemData)
        {
            this._systemData = systemData;
        }

        public SystemModel Get(long id)
        {
            SystemModel ret = _systemData.Get(id);

            return ret;
        }

        public IList<SystemModel> List()
        {
            IList<SystemModel> ret = _systemData.List();

            return ret;
        }

        public SystemModel Insert(SystemModel model)
        {
            SystemModel ret = _systemData.Insert(model);

            _systemData.Save();

            return ret;
        }

        public SystemModel Update(SystemModel model)
        {
            SystemModel ret = _systemData.Update(model);

            _systemData.Save();

            return ret;
        }

        public SystemModel Delete(SystemModel model)
        {
            SystemModel ret = _systemData.Delete(model);

            _systemData.Save();

            return ret;
        }
    }
}
