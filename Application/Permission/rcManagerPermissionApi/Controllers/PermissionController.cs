using Microsoft.AspNetCore.Mvc;
using rcManagerPermissionApplication.Interfaces;
using rcManagerPermissionApplication.Transport;
using Swashbuckle.AspNetCore.Annotations;

namespace rcManagerPermissionApi.Controllers
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
            Description = "[pt-BR] Listar todos as Permissões. \n\n " +
                "[en-US] List all Permissions. ",
            Tags = new[] { "Permissions" }
        )]
        [ProducesResponseType(typeof(PermissionResponse), 200)]
        [ProducesResponseType(typeof(PermissionResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult List()
        {
            PermissionResponse permissionResponseRet;

            try {
                permissionResponseRet = _permissionService.List();
            } catch {
                permissionResponseRet = new PermissionResponse();
                permissionResponseRet.IsValid = false;
                permissionResponseRet.Error = true;
                permissionResponseRet.AddMessage("Erro ao listar Permissões");
            }

            if (permissionResponseRet.Error || !permissionResponseRet.IsValid) {
                return BadRequest(permissionResponseRet);
            } else {
                return Ok(permissionResponseRet);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Obter uma Permissão pelo id",
            Description = "[pt-BR] Obter uma Permissão pelo id. \n\n " +
                "[en-US] Get a Permission by id. ",
            Tags = new[] { "Permissions" }
        )]
        [ProducesResponseType(typeof(PermissionResponse), 200)]
        [ProducesResponseType(typeof(PermissionResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Get(long id)
        {
            PermissionResponse permissionResponseRet;

            try {
                permissionResponseRet = _permissionService.Get(id);
            } catch {
                permissionResponseRet = new PermissionResponse();
                permissionResponseRet.IsValid = false;
                permissionResponseRet.Error = true;
                permissionResponseRet.AddMessage("Erro ao consultar Permissão");
            }

            if (permissionResponseRet.Error || !permissionResponseRet.IsValid) {
                return BadRequest(permissionResponseRet);
            } else {
                return Ok(permissionResponseRet);
            }
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Incluir uma Permissão",
            Description = "[pt-BR] Incluir uma Permissão. \n\n " +
                "[en-US] Add a Permission. ",
            Tags = new[] { "Permissions" }
        )]
        [ProducesResponseType(typeof(PermissionResponse), 200)]
        [ProducesResponseType(typeof(PermissionResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Insert(PermissionRequest permissionRequest)
        {
            PermissionResponse permissionResponseRet;

            try {
                permissionResponseRet = _permissionService.Insert(permissionRequest);
            } catch {
                permissionResponseRet = new PermissionResponse();
                permissionResponseRet.IsValid = false;
                permissionResponseRet.Error = true;
                permissionResponseRet.AddMessage("Erro ao incluir Permissão");
            }

            if (permissionResponseRet.Error || !permissionResponseRet.IsValid) {
                return BadRequest(permissionResponseRet);
            } else {
                return Ok(permissionResponseRet);
            }
        }

        [HttpPut]
        [SwaggerOperation(
            Summary = "Atualizar uma Permissão",
            Description = "[pt-BR] Atualizar uma Permissão. \n\n " +
                "[en-US] Update a Permission. ",
            Tags = new[] { "Permissions" }
        )]
        [ProducesResponseType(typeof(PermissionResponse), 200)]
        [ProducesResponseType(typeof(PermissionResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Update(PermissionRequest permissionRequest)
        {
            PermissionResponse permissionResponseRet;

            try {
                permissionResponseRet = _permissionService.Update(permissionRequest);
            } catch {
                permissionResponseRet = new PermissionResponse();
                permissionResponseRet.IsValid = false;
                permissionResponseRet.Error = true;
                permissionResponseRet.AddMessage("Erro ao alterar Permissão");
            }

            if (permissionResponseRet.Error || !permissionResponseRet.IsValid) {
                return BadRequest(permissionResponseRet);
            } else {
                return Ok(permissionResponseRet);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Excluir uma Permissão",
            Description = "[pt-BR] Excluir uma Permissão. \n\n " +
                "[en-US] Delete a Permission. ",
            Tags = new[] { "Permissions" }
        )]
        [ProducesResponseType(typeof(PermissionResponse), 200)]
        [ProducesResponseType(typeof(PermissionResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Delete(long id)
        {
            PermissionResponse permissionResponseRet;

            try {
                permissionResponseRet = _permissionService.Delete(id);
            } catch {
                permissionResponseRet = new PermissionResponse();
                permissionResponseRet.IsValid = false;
                permissionResponseRet.Error = true;
                permissionResponseRet.AddMessage("Erro ao excluir Permissão");
            }

            if (permissionResponseRet.Error || !permissionResponseRet.IsValid) {
                return BadRequest(permissionResponseRet);
            } else {
                return Ok(permissionResponseRet);
            }
        }
    }
}
