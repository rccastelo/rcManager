using rcManagerSystemApplication.Interfaces;
using rcManagerSystemApplication.Transport;
using rcManagerSystemDomain;
using rcManagerSystemRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace rcManagerSystemApplication.Service
{
    public class SystemService : ISystemService
    {
        private readonly ISystemRepository _repository;

        public SystemService(ISystemRepository repository)
        {
            this._repository = repository;
        }

        public SystemResponse List(SystemRequest systemRequest)
        {
            SystemResponse systemResponseRet = new SystemResponse();

            try {
                IList<SystemModel> listRet = _repository.List();

                if ((listRet != null)  && (listRet.Count > 0)) {
                    systemResponseRet.List = listRet.Select(et => new SystemEntity(et)).ToList(); 
                } else {
                    systemResponseRet.AddMessage("Nenhum registro encontrado");
                }
            } catch (ArgumentException ex) {
                systemResponseRet.IsValid = false;
                systemResponseRet.Error = true;
                systemResponseRet.AddMessage(ex.Message);
            }

            return systemResponseRet;
        }

        public SystemResponse Get(long id)
        {
            SystemResponse systemResponseRet = new SystemResponse();

            try {
                SystemModel systemModelRet = _repository.Get(id);

                if (systemModelRet == null) {
                    systemResponseRet.AddMessage("Registro não encontrado");
                } else {
                    systemResponseRet.Item = systemModelRet;
                }
            } catch (ArgumentException ex) {
                systemResponseRet.IsValid = false;
                systemResponseRet.Error = true;
                systemResponseRet.AddMessage(ex.Message);
            }

            return systemResponseRet;
        }

        public SystemResponse Insert(SystemRequest systemRequest)
        {
            SystemResponse systemResponseRet = new SystemResponse();

            try {
                SystemModel req = new SystemModel(systemRequest);

                SystemModel model = _repository.Insert(req);

                systemResponseRet.Item = model.toEntity();
            } catch (ArgumentException ex) {
                systemResponseRet.IsValid = false;
                systemResponseRet.Error = true;
                systemResponseRet.AddMessage(ex.Message);
            }

            return systemResponseRet;
        }

        public SystemResponse Update(SystemRequest systemRequest)
        {
            SystemResponse systemResponseRet = new SystemResponse();

            try {
                SystemModel req = new SystemModel(systemRequest);

                SystemModel model = _repository.Update(req);

                systemResponseRet.Item = model.toEntity();
            } catch (ArgumentException ex) {
                systemResponseRet.IsValid = false;
                systemResponseRet.Error = true;
                systemResponseRet.AddMessage(ex.Message);
            }

            return systemResponseRet;
        }

        public SystemResponse Delete(long id)
        {
            SystemResponse systemResponseRet = new SystemResponse();

            try {
                SystemEntity entityExist = _repository.Get(id);

                if (entityExist != null) {
                    SystemModel req = new SystemModel(entityExist);

                    SystemModel model = _repository.Delete(req);

                    systemResponseRet.Item = model.toEntity();
                } else {
                    systemResponseRet.AddMessage("Registro não encontrado");
                }
            } catch (ArgumentException ex) {
                systemResponseRet.IsValid = false;
                systemResponseRet.Error = true;
                systemResponseRet.AddMessage(ex.Message);
            }

            return systemResponseRet;
        }
    }
}
