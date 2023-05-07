using Microsoft.AspNetCore.Mvc;
using rcManagerSystemApplication.Interfaces;
using rcManagerSystemApplication.Transport;
using Swashbuckle.AspNetCore.Annotations;

namespace rcManagerUserApi.Controllers
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
        [SwaggerOperation(
            Summary = "Listar todos os Sistemas",
            Description = "[pt-BR] Listar todos os Sistemas. \n\n " +
                "[en-US] List all Systems. ",
            Tags = new[] { "Systems" }
        )]
        [ProducesResponseType(typeof(SystemResponse), 200)]
        [ProducesResponseType(typeof(SystemResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult List()
        {
            SystemResponse systemResponseRet;

            try {
                systemResponseRet = _systemService.List();
            } catch {
                systemResponseRet = new SystemResponse();
                systemResponseRet.IsValid = false;
                systemResponseRet.Error = true;
                systemResponseRet.AddMessage("Erro ao listar Sistemas");
            }

            if (systemResponseRet.Error || !systemResponseRet.IsValid) {
                return BadRequest(systemResponseRet);
            } else {
                return Ok(systemResponseRet);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Obter um Sistema pelo id",
            Description = "[pt-BR] Obter um Sistema pelo id. \n\n " +
                "[en-US] Get a System by id. ",
            Tags = new[] { "Systems" }
        )]
        [ProducesResponseType(typeof(SystemResponse), 200)]
        [ProducesResponseType(typeof(SystemResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Get(long id)
        {
            SystemResponse systemResponseRet;

            try {
                systemResponseRet = _systemService.Get(id);
            } catch {
                systemResponseRet = new SystemResponse();
                systemResponseRet.IsValid = false;
                systemResponseRet.Error = true;
                systemResponseRet.AddMessage("Erro ao consultar Sistema");
            }

            if (systemResponseRet.Error || !systemResponseRet.IsValid) {
                return BadRequest(systemResponseRet);
            } else {
                return Ok(systemResponseRet);
            }
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Incluir um Sistema",
            Description = "[pt-BR] Incluir um Sistema. \n\n " +
                "[en-US] Add a System. ",
            Tags = new[] { "Systems" }
        )]
        [ProducesResponseType(typeof(SystemResponse), 200)]
        [ProducesResponseType(typeof(SystemResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Insert(SystemRequest systemRequest)
        {
            SystemResponse systemResponseRet;

            try {
                systemResponseRet = _systemService.Insert(systemRequest);
            } catch {
                systemResponseRet = new SystemResponse();
                systemResponseRet.IsValid = false;
                systemResponseRet.Error = true;
                systemResponseRet.AddMessage("Erro ao incluir Sistema");
            }

            if (systemResponseRet.Error || !systemResponseRet.IsValid) {
                return BadRequest(systemResponseRet);
            } else {
                return Ok(systemResponseRet);
            }
        }

        [HttpPut]
        [SwaggerOperation(
            Summary = "Atualizar um Sistema",
            Description = "[pt-BR] Atualizar um Sistema. \n\n " +
                "[en-US] Update a System. ",
            Tags = new[] { "Systems" }
        )]
        [ProducesResponseType(typeof(SystemResponse), 200)]
        [ProducesResponseType(typeof(SystemResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Update(SystemRequest systemRequest)
        {
            SystemResponse systemResponseRet;

            try {
                systemResponseRet = _systemService.Update(systemRequest);
            } catch {
                systemResponseRet = new SystemResponse();
                systemResponseRet.IsValid = false;
                systemResponseRet.Error = true;
                systemResponseRet.AddMessage("Erro ao alterar Sistema");
            }

            if (systemResponseRet.Error || !systemResponseRet.IsValid) {
                return BadRequest(systemResponseRet);
            } else {
                return Ok(systemResponseRet);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Excluir um Sistema",
            Description = "[pt-BR] Excluir um Sistema. \n\n " +
                "[en-US] Delete a System. ",
            Tags = new[] { "Systems" }
        )]
        [ProducesResponseType(typeof(SystemResponse), 200)]
        [ProducesResponseType(typeof(SystemResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Delete(long id)
        {
            SystemResponse systemResponseRet;

            try {
                systemResponseRet = _systemService.Delete(id);
            } catch {
                systemResponseRet = new SystemResponse();
                systemResponseRet.IsValid = false;
                systemResponseRet.Error = true;
                systemResponseRet.AddMessage("Erro ao excluir Sistema");
            }

            if (systemResponseRet.Error || !systemResponseRet.IsValid) {
                return BadRequest(systemResponseRet);
            } else {
                return Ok(systemResponseRet);
            }
        }
    }
}
