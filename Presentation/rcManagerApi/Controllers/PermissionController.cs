using Microsoft.AspNetCore.Mvc;
using rcManagerServices.Interfaces;
using rcManagerTransfers.Transfers;
using System;

namespace rcManagerApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public PermissionController(IPermissionService permissionService)
        {
            this._permissionService = permissionService;
        }

        [HttpGet]
        public IActionResult list(PermissionTransfer permissionTransfer)
        {
            PermissionTransfer permissionTransferRet;

            try {
                permissionTransferRet = _permissionService.list(permissionTransfer);
            } catch (Exception ex) {
                permissionTransferRet = new PermissionTransfer();
                permissionTransferRet.valid = false;
                permissionTransferRet.error = true;
                permissionTransferRet.addMessage("Erro ao listar Permissões");
            }

            if (permissionTransferRet.error || !permissionTransferRet.valid) {
                return BadRequest(permissionTransferRet);
            } else {
                return Ok(permissionTransferRet);
            }
        }

        [HttpGet("{id}")]
        public IActionResult get(long id)
        {
            PermissionTransfer permissionTransferRet;

            try {
                permissionTransferRet = _permissionService.get(id);
            } catch (Exception ex) {
                permissionTransferRet = new PermissionTransfer();
                permissionTransferRet.valid = false;
                permissionTransferRet.error = true;
                permissionTransferRet.addMessage("Erro ao consultar Permissão");
            }

            if (permissionTransferRet.error || !permissionTransferRet.valid) {
                return BadRequest(permissionTransferRet);
            } else {
                return Ok(permissionTransferRet);
            }
        }

        [HttpPost]
        public IActionResult insert(PermissionTransfer permissionTransfer)
        {
            PermissionTransfer permissionTransferRet;

            try {
                permissionTransferRet = _permissionService.insert(permissionTransfer);
            } catch (Exception ex) {
                permissionTransferRet = new PermissionTransfer();
                permissionTransferRet.valid = false;
                permissionTransferRet.error = true;
                permissionTransferRet.addMessage("Erro ao incluir Permissão");
            }

            if (permissionTransferRet.error || !permissionTransferRet.valid) {
                return BadRequest(permissionTransferRet);
            } else {
                return Ok(permissionTransferRet);
            }
        }

        [HttpPut]
        public IActionResult update(PermissionTransfer permissionTransfer)
        {
            PermissionTransfer permissionTransferRet;

            try {
                permissionTransferRet = _permissionService.update(permissionTransfer);
            } catch (Exception ex) {
                permissionTransferRet = new PermissionTransfer();
                permissionTransferRet.valid = false;
                permissionTransferRet.error = true;
                permissionTransferRet.addMessage("Erro ao alterar Permissão");
            }

            if (permissionTransferRet.error || !permissionTransferRet.valid) {
                return BadRequest(permissionTransferRet);
            } else {
                return Ok(permissionTransferRet);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult delete(long id)
        {
            PermissionTransfer permissionTransferRet;

            try {
                permissionTransferRet = _permissionService.delete(id);
            } catch (Exception ex) {
                permissionTransferRet = new PermissionTransfer();
                permissionTransferRet.valid = false;
                permissionTransferRet.error = true;
                permissionTransferRet.addMessage("Erro ao excluir Permissão");
            }

            if (permissionTransferRet.error || !permissionTransferRet.valid) {
                return BadRequest(permissionTransferRet);
            } else {
                return Ok(permissionTransferRet);
            }
        }
    }
}
