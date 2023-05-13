using Microsoft.AspNetCore.Mvc;
using rcManagerUserApplication.Interfaces;
using rcManagerUserApplication.Transport;
using Swashbuckle.AspNetCore.Annotations;

namespace rcManagerPasswordApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PasswordController : Controller
    {
        private readonly IPasswordService _passwordService;

        public PasswordController(IPasswordService passwordService)
        {
            this._passwordService = passwordService;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Listar todos os logins",
            Description = "[pt-BR] Listar todos os logins. \n\n " +
                "[en-US] List all logins. ",
            Tags = new[] { "Password" }
        )]
        [ProducesResponseType(typeof(PasswordResponse), 200)]
        [ProducesResponseType(typeof(PasswordResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult List()
        {
            PasswordResponse response;

            try {
                response = _passwordService.List();
            } catch {
                response = new PasswordResponse();
                response.IsValid = false;
                response.IsError = true;
                response.AddMessage("Erro ao listar logins");
            }

            if (response.IsError || !response.IsValid) {
                return BadRequest(response);
            } else {
                return Ok(response);
            }
        }

        [HttpPut]
        [SwaggerOperation(
            Summary = "Atualizar a senha de um usuário",
            Description = "[pt-BR] Atualizar a senha de um usuário. \n\n " +
                "[en-US] Update a user's password. ",
            Tags = new[] { "Password" }
        )]
        [ProducesResponseType(typeof(PasswordResponse), 200)]
        [ProducesResponseType(typeof(PasswordResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Update(PasswordRequest passwordRequest)
        {
            PasswordResponse response;

            try {
                response = _passwordService.Update(passwordRequest);
            } catch {
                response = new PasswordResponse();
                response.IsValid = false;
                response.IsError = true;
                response.AddMessage("Erro ao alterar Senha");
            }

            if (response.IsError || !response.IsValid) {
                return BadRequest(response);
            } else {
                return Ok(response);
            }
        }
    }
}
