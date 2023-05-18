using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rcManagerSystemApplication.Interfaces;
using rcManagerSystemApplication.Transport;
using Swashbuckle.AspNetCore.Annotations;

namespace rcManagerUserApi.Controllers
{
    [Authorize]
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
            Tags = new[] { "System" }
        )]
        [ProducesResponseType(typeof(SystemResponse), 200)]
        [ProducesResponseType(typeof(SystemResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult List()
        {
            SystemResponse response;

            try {
                response = _systemService.List();
            } catch {
                response = new SystemResponse();
                response.IsValid = false;
                response.IsError = true;
                response.AddMessage("Erro ao listar Sistemas");
            }

            if (response.IsError || !response.IsValid) {
                return BadRequest(response);
            } else {
                return Ok(response);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Obter um Sistema pelo id",
            Description = "[pt-BR] Obter um Sistema pelo id. \n\n " +
                "[en-US] Get a System by id. ",
            Tags = new[] { "System" }
        )]
        [ProducesResponseType(typeof(SystemResponse), 200)]
        [ProducesResponseType(typeof(SystemResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Get(long id)
        {
            SystemResponse response;

            try {
                response = _systemService.Get(id);
            } catch {
                response = new SystemResponse();
                response.IsValid = false;
                response.IsError = true;
                response.AddMessage("Erro ao consultar Sistema");
            }

            if (response.IsError || !response.IsValid) {
                return BadRequest(response);
            } else {
                return Ok(response);
            }
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Incluir um Sistema",
            Description = "[pt-BR] Incluir um Sistema. \n\n " +
                "[en-US] Add a System. ",
            Tags = new[] { "System" }
        )]
        [ProducesResponseType(typeof(SystemResponse), 200)]
        [ProducesResponseType(typeof(SystemResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Insert(SystemRequest systemRequest)
        {
            SystemResponse response;

            try {
                response = _systemService.Insert(systemRequest);
            } catch {
                response = new SystemResponse();
                response.IsValid = false;
                response.IsError = true;
                response.AddMessage("Erro ao incluir Sistema");
            }

            if (response.IsError || !response.IsValid) {
                return BadRequest(response);
            } else {
                return Ok(response);
            }
        }

        [HttpPut]
        [SwaggerOperation(
            Summary = "Atualizar um Sistema",
            Description = "[pt-BR] Atualizar um Sistema. \n\n " +
                "[en-US] Update a System. ",
            Tags = new[] { "System" }
        )]
        [ProducesResponseType(typeof(SystemResponse), 200)]
        [ProducesResponseType(typeof(SystemResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Update(SystemRequest systemRequest)
        {
            SystemResponse response;

            try {
                response = _systemService.Update(systemRequest);
            } catch {
                response = new SystemResponse();
                response.IsValid = false;
                response.IsError = true;
                response.AddMessage("Erro ao alterar Sistema");
            }

            if (response.IsError || !response.IsValid) {
                return BadRequest(response);
            } else {
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Excluir um Sistema",
            Description = "[pt-BR] Excluir um Sistema. \n\n " +
                "[en-US] Delete a System. ",
            Tags = new[] { "System" }
        )]
        [ProducesResponseType(typeof(SystemResponse), 200)]
        [ProducesResponseType(typeof(SystemResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Delete(long id)
        {
            SystemResponse response;

            try {
                response = _systemService.Delete(id);
            } catch {
                response = new SystemResponse();
                response.IsValid = false;
                response.IsError = true;
                response.AddMessage("Erro ao excluir Sistema");
            }

            if (response.IsError || !response.IsValid) {
                return BadRequest(response);
            } else {
                return Ok(response);
            }
        }
    }
}
