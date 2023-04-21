using Microsoft.AspNetCore.Mvc;
using rcManagerServices.Interfaces;
using rcManagerTransfers.Transfers;
using System;

namespace rcManagerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SystemController : ControllerBase
    {
        private readonly ISystemService _systemService;

        public SystemController(ISystemService systemService) 
        {
            this._systemService = systemService;
        }

        [HttpGet]
        public IActionResult list(SystemTransfer systemTransfer) 
        {
            SystemTransfer systemTransferRet;

            try {
                systemTransferRet = _systemService.list(systemTransfer);
            } catch (Exception ex) {
                systemTransferRet = new SystemTransfer();
                systemTransferRet.valid = false;
                systemTransferRet.error = true;
                systemTransferRet.addMessage("Erro ao listar Sistemas");
            }

            if (systemTransferRet.error || !systemTransferRet.valid) {
                return BadRequest(systemTransferRet);
            } else {
                return Ok(systemTransferRet);
            }
        }

        [HttpGet("{id}")]
        public IActionResult get(long id) 
        {
            SystemTransfer systemTransferRet;

            try
            {
                systemTransferRet = _systemService.get(id);
            }
            catch (Exception ex) {
                systemTransferRet = new SystemTransfer();
                systemTransferRet.valid = false;
                systemTransferRet.error = true;
                systemTransferRet.addMessage("Erro ao consultar Sistema");
            }

            if (systemTransferRet.error || !systemTransferRet.valid) {
                return BadRequest(systemTransferRet);
            } else {
                return Ok(systemTransferRet);
            }
        }

        [HttpPost]
        public IActionResult insert(SystemTransfer systemTransfer) 
        {
            SystemTransfer systemTransferRet;

            try
            {
                systemTransferRet = _systemService.insert(systemTransfer);
            }
            catch (Exception ex)
            {
                systemTransferRet = new SystemTransfer();
                systemTransferRet.valid = false;
                systemTransferRet.error = true;
                systemTransferRet.addMessage("Erro ao incluir Sistema");
            }

            if (systemTransferRet.error || !systemTransferRet.valid)
            {
                return BadRequest(systemTransferRet);
            }
            else
            {
                return Ok(systemTransferRet);
            }
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
