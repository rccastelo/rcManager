using Microsoft.AspNetCore.Mvc;
using rcManagerSystemApplication.Application;
using rcManagerSystemApplication.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace rcManagerApi.Controllers
{
    //[Authorize]
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
            //Description = "[pt-BR] Listar todos os Sistemas. Requer token de autenticação. \n\n " +
            //    "[en-US] List all Systems. Authentication token is required.",
            Tags = new[] { "Systems" }
        )]
        [ProducesResponseType(typeof(SystemTransfer), 200)]
        [ProducesResponseType(typeof(SystemTransfer), 400)]
        //[ProducesResponseType(401)]
        [ProducesResponseType(500)]
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
        [SwaggerOperation(
            Summary = "Obter um Sistema pelo id",
            Description = "[pt-BR] Obter um Sistema pelo id. \n\n " +
                "[en-US] Get a System by id. ",
            //Description = "[pt-BR] Obter um Sistema pelo id. Requer token de autenticação. \n\n " +
            //    "[en-US] Get a System by id. Authentication token is required.",
            Tags = new[] { "Systems" }
        )]
        [ProducesResponseType(typeof(SystemTransfer), 200)]
        [ProducesResponseType(typeof(SystemTransfer), 400)]
        //[ProducesResponseType(401)]
        [ProducesResponseType(500)]
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
        [SwaggerOperation(
            Summary = "Incluir um Sistema",
            Description = "[pt-BR] Incluir um Sistema. \n\n " +
                "[en-US] Add a System. ",
            //Description = "[pt-BR] Incluir um Sistema. Requer token de autenticação. \n\n " +
            //    "[en-US] Add a System. Authentication token is required.",
            Tags = new[] { "Systems" }
        )]
        [ProducesResponseType(typeof(SystemTransfer), 200)]
        [ProducesResponseType(typeof(SystemTransfer), 400)]
        //[ProducesResponseType(401)]
        [ProducesResponseType(500)]
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
        [SwaggerOperation(
            Summary = "Atualizar um Sistema",
            Description = "[pt-BR] Atualizar um Sistema. \n\n " +
                "[en-US] Update a System. ",
            //Description = "[pt-BR] Atualizar um Sistema. Requer token de autenticação. \n\n " +
            //    "[en-US] Update a System. Authentication token is required.",
            Tags = new[] { "Systems" }
        )]
        [ProducesResponseType(typeof(SystemTransfer), 200)]
        [ProducesResponseType(typeof(SystemTransfer), 400)]
        //[ProducesResponseType(401)]
        [ProducesResponseType(500)]
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
        [SwaggerOperation(
            Summary = "Excluir um Sistema",
            Description = "[pt-BR] Excluir um Sistema. \n\n " +
                "[en-US] Delete a System. ",
            //Description = "[pt-BR] Excluir um Sistema. Requer token de autenticação. \n\n " +
            //    "[en-US] Delete a System. Authentication token is required.",
            Tags = new[] { "Systems" }
        )]
        [ProducesResponseType(typeof(SystemTransfer), 200)]
        [ProducesResponseType(typeof(SystemTransfer), 400)]
        //[ProducesResponseType(401)]
        [ProducesResponseType(500)]
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
