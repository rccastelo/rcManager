using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using rcManagerServices.Interfaces;
using rcManagerTransfer.Interfaces;
using rcManagerTransfer.Transfers;

namespace rcManagerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SystemController : ControllerBase
    {
        private readonly ISystemService systemService;
        private ISystemTransfer systemTransfer;

        public SystemController(ISystemService systemService,
                ISystemTransfer systemTransfer)
        {
            this.systemService = systemService;
            this.systemTransfer = systemTransfer;
        }

        [HttpGet]
        public string list()
        {
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
