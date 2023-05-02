using Microsoft.AspNetCore.Mvc;
using rcManagerPermissionApplication.Application;
using rcManagerPermissionApplication.Interfaces;
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
        public IActionResult List(PermissionTransfer permissionTransfer)
        {
            PermissionTransfer permissionTransferRet;

            try {
                permissionTransferRet = _permissionService.List(permissionTransfer);
            } catch (Exception ex) {
                permissionTransferRet = new PermissionTransfer();
                permissionTransferRet.Valid = false;
                permissionTransferRet.Error = true;
                permissionTransferRet.AddMessage("Erro ao listar Permissões");
            }

            if (permissionTransferRet.Error || !permissionTransferRet.Valid) {
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
        public IActionResult Get(long id)
        {
            PermissionTransfer permissionTransferRet;

            try {
                permissionTransferRet = _permissionService.Get(id);
            } catch (Exception ex) {
                permissionTransferRet = new PermissionTransfer();
                permissionTransferRet.Valid = false;
                permissionTransferRet.Error = true;
                permissionTransferRet.AddMessage("Erro ao consultar Permissão");
            }

            if (permissionTransferRet.Error || !permissionTransferRet.Valid) {
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
        public IActionResult Insert(PermissionTransfer permissionTransfer)
        {
            PermissionTransfer permissionTransferRet;

            try {
                permissionTransferRet = _permissionService.Insert(permissionTransfer);
            } catch (Exception ex) {
                permissionTransferRet = new PermissionTransfer();
                permissionTransferRet.Valid = false;
                permissionTransferRet.Error = true;
                permissionTransferRet.AddMessage("Erro ao incluir Permissão");
            }

            if (permissionTransferRet.Error || !permissionTransferRet.Valid) {
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
        public IActionResult Update(PermissionTransfer permissionTransfer)
        {
            PermissionTransfer permissionTransferRet;

            try {
                permissionTransferRet = _permissionService.Update(permissionTransfer);
            } catch (Exception ex) {
                permissionTransferRet = new PermissionTransfer();
                permissionTransferRet.Valid = false;
                permissionTransferRet.Error = true;
                permissionTransferRet.AddMessage("Erro ao alterar Permissão");
            }

            if (permissionTransferRet.Error || !permissionTransferRet.Valid) {
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
        public IActionResult Delete(long id)
        {
            PermissionTransfer permissionTransferRet;

            try {
                permissionTransferRet = _permissionService.Delete(id);
            } catch (Exception ex) {
                permissionTransferRet = new PermissionTransfer();
                permissionTransferRet.Valid = false;
                permissionTransferRet.Error = true;
                permissionTransferRet.AddMessage("Erro ao excluir Permissão");
            }

            if (permissionTransferRet.Error || !permissionTransferRet.Valid) {
                return BadRequest(permissionTransferRet);
            } else {
                return Ok(permissionTransferRet);
            }
        }
    }
}
