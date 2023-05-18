using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rcManagerUserApplication.Interfaces;
using rcManagerUserApplication.Transport;
using Swashbuckle.AspNetCore.Annotations;

namespace rcManagerApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            this._loginService = loginService;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Listar todos os Logins",
            Description = "[pt-BR] Listar todos os Logins. \n\n " +
                "[en-US] List all Logins. ",
            Tags = new[] { "Login" }
        )]
        [ProducesResponseType(typeof(LoginResponse), 200)]
        [ProducesResponseType(typeof(LoginResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult List()
        {
            LoginResponse response;

            try {
                response = _loginService.List();
            } catch {
                response = new LoginResponse();
                response.IsValid = false;
                response.IsError = true;
                response.AddMessage("Erro ao listar os Logins");
            }

            if (response.IsError || !response.IsValid) {
                return BadRequest(response);
            } else {
                return Ok(response);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Obter o Login de um usuário pelo id",
            Description = "[pt-BR] Obter o Login de um usuário pelo id. \n\n " +
                "[en-US] Get a user's Login by id. ",
            Tags = new[] { "Login" }
        )]
        [ProducesResponseType(typeof(LoginResponse), 200)]
        [ProducesResponseType(typeof(LoginResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Get(long id)
        {
            LoginResponse response;

            try {
                response = _loginService.Get(id);
            } catch {
                response = new LoginResponse();
                response.IsValid = false;
                response.IsError = true;
                response.AddMessage("Erro ao consultar o Login");
            }

            if (response.IsError || !response.IsValid) {
                return BadRequest(response);
            } else {
                return Ok(response);
            }
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Incluir um Login para um usuário",
            Description = "[pt-BR] Incluir um Login para um usuário. \n\n " +
                "[en-US] Add a Login to a user. ",
            Tags = new[] { "Login" }
        )]
        [ProducesResponseType(typeof(LoginResponse), 200)]
        [ProducesResponseType(typeof(LoginResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Insert(LoginRequest request)
        {
            LoginResponse response;

            try {
                response = _loginService.Insert(request);
            } catch {
                response = new LoginResponse();
                response.IsValid = false;
                response.IsError = true;
                response.AddMessage("Erro ao incluir o Login");
            }

            if (response.IsError || !response.IsValid) {
                return BadRequest(response);
            } else {
                return Ok(response);
            }
        }

        [HttpPut]
        [SwaggerOperation(
            Summary = "Atualizar o Login de um usuário",
            Description = "[pt-BR] Atualizar o Login de um usuário. \n\n " +
                "[en-US] Update a user's Login. ",
            Tags = new[] { "Login" }
        )]
        [ProducesResponseType(typeof(LoginResponse), 200)]
        [ProducesResponseType(typeof(LoginResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Update(LoginRequest request)
        {
            LoginResponse response;

            try {
                response = _loginService.Update(request);
            } catch {
                response = new LoginResponse();
                response.IsValid = false;
                response.IsError = true;
                response.AddMessage("Erro ao alterar o Login");
            }

            if (response.IsError || !response.IsValid) {
                return BadRequest(response);
            } else {
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Excluir o Login de um usuário",
            Description = "[pt-BR] Excluir o Login de um usuário. \n\n " +
                "[en-US] Delete a user's Login. ",
            Tags = new[] { "Login" }
        )]
        [ProducesResponseType(typeof(LoginResponse), 200)]
        [ProducesResponseType(typeof(LoginResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Delete(long id)
        {
            LoginResponse response;

            try {
                response = _loginService.Delete(id);
            } catch {
                response = new LoginResponse();
                response.IsValid = false;
                response.IsError = true;
                response.AddMessage("Erro ao excluir o Login");
            }

            if (response.IsError || !response.IsValid) {
                return BadRequest(response);
            } else {
                return Ok(response);
            }
        }
    }
}