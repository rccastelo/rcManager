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

            try {
                systemTransferRet = _systemService.get(id);
            } catch (Exception ex) {
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

            try {
                systemTransferRet = _systemService.insert(systemTransfer);
            } catch (Exception ex) {
                systemTransferRet = new SystemTransfer();
                systemTransferRet.valid = false;
                systemTransferRet.error = true;
                systemTransferRet.addMessage("Erro ao incluir Sistema");
            }

            if (systemTransferRet.error || !systemTransferRet.valid) {
                return BadRequest(systemTransferRet);
            } else {
                return Ok(systemTransferRet);
            }
        }

        [HttpPut]
        public IActionResult update(SystemTransfer systemTransfer) 
        {
            SystemTransfer systemTransferRet;

            try {
                systemTransferRet = _systemService.update(systemTransfer);
            } catch (Exception ex) {
                systemTransferRet = new SystemTransfer();
                systemTransferRet.valid = false;
                systemTransferRet.error = true;
                systemTransferRet.addMessage("Erro ao alterar Sistema");
            }

            if (systemTransferRet.error || !systemTransferRet.valid) {
                return BadRequest(systemTransferRet);
            } else {
                return Ok(systemTransferRet);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult delete(long id) 
        {
            SystemTransfer systemTransferRet;

            try {
                systemTransferRet = _systemService.delete(id);
            } catch (Exception ex) {
                systemTransferRet = new SystemTransfer();
                systemTransferRet.valid = false;
                systemTransferRet.error = true;
                systemTransferRet.addMessage("Erro ao excluir Sistema");
            }

            if (systemTransferRet.error || !systemTransferRet.valid) {
                return BadRequest(systemTransferRet);
            } else {
                return Ok(systemTransferRet);
            }
        }
    }
}
