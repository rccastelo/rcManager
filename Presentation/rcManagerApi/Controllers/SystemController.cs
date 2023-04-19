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
        private SystemTransfer systemTransfer;

        public SystemController(ISystemService systemService)
        {
            this.systemService = systemService;
        }

        [HttpGet]
        public string list()
        {
            this.systemTransfer = new SystemTransfer();

            SystemTransfer systemTransferRet = systemService.list(systemTransfer);

            return JsonConvert.SerializeObject(systemTransferRet);
        }

        [HttpGet("/{id}")]
        public void get()
        {

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
