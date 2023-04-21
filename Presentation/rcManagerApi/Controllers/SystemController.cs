using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using rcManagerServices.Interfaces;
using rcManagerTransfers.Transfers;

namespace rcManagerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SystemController : ControllerBase
    {
        private readonly ISystemService systemService;

        public SystemController(ISystemService systemService)
        {
            this.systemService = systemService;
        }

        [HttpGet]
        public string list()
        {
            SystemTransfer systemTransfer = new SystemTransfer();

            SystemTransfer systemTransferRet = systemService.list(systemTransfer);

            return JsonConvert.SerializeObject(systemTransferRet);
        }

        [HttpGet("{id}")]
        public string get()
        {
            SystemTransfer systemTransfer = new SystemTransfer();

            SystemTransfer systemTransferRet = systemService.get(systemTransfer);

            return "JsonConvert.SerializeObject(systemTransferRet)";
        }

        [HttpPost]
        public void insert() {
            
        }

        [HttpPut]
        public void update()
        {

        }

        [HttpDelete]
        public void delete()
        {

        }
    }
}
