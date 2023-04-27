using Microsoft.AspNetCore.Mvc;
using rcManagerServices.Interfaces;
using rcManagerTransfers.Transfers;
using Swashbuckle.AspNetCore.Annotations;
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
        [SwaggerOperation(
            Summary = "Listar todas as Permissões",
            Description = "[pt-BR] Listar todos os Permissões. \n\n " +
                "[en-US] List all Permissions. ",
            Tags = new[] { "Permissions" }
        )]
        [ProducesResponseType(typeof(PermissionTransfer), 200)]
        [ProducesResponseType(typeof(PermissionTransfer), 400)]
        [ProducesResponseType(500)]
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
        [SwaggerOperation(
            Summary = "Obter uma Permissão pelo id",
            Description = "[pt-BR] Obter um Permissão pelo id. \n\n " +
                "[en-US] Get a Permission by id. ",
            Tags = new[] { "Permissions" }
        )]
        [ProducesResponseType(typeof(PermissionTransfer), 200)]
        [ProducesResponseType(typeof(PermissionTransfer), 400)]
        [ProducesResponseType(500)]
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
        [SwaggerOperation(
            Summary = "Incluir uma Permissão",
            Description = "[pt-BR] Incluir um Permissão. \n\n " +
                "[en-US] Add a Permission. ",
            Tags = new[] { "Permissions" }
        )]
        [ProducesResponseType(typeof(PermissionTransfer), 200)]
        [ProducesResponseType(typeof(PermissionTransfer), 400)]
        [ProducesResponseType(500)]
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
        [SwaggerOperation(
            Summary = "Atualizar uma Permissão",
            Description = "[pt-BR] Atualizar um Permissão. \n\n " +
                "[en-US] Update a Permission. ",
            Tags = new[] { "Permissions" }
        )]
        [ProducesResponseType(typeof(PermissionTransfer), 200)]
        [ProducesResponseType(typeof(PermissionTransfer), 400)]
        [ProducesResponseType(500)]
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
        [SwaggerOperation(
            Summary = "Excluir uma Permissão",
            Description = "[pt-BR] Excluir uma Permissão. \n\n " +
                "[en-US] Delete a Permission. ",
            Tags = new[] { "Permissions" }
        )]
        [ProducesResponseType(typeof(PermissionTransfer), 200)]
        [ProducesResponseType(typeof(PermissionTransfer), 400)]
        [ProducesResponseType(500)]
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
