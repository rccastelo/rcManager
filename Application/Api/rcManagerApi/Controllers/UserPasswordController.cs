using Microsoft.AspNetCore.Mvc;
using rcManagerUserApplication.Interfaces;
using rcManagerUserApplication.Transport;
using Swashbuckle.AspNetCore.Annotations;

namespace rcManagerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserPasswordController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserPasswordController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Listar todos os logins",
            Tags = new[] { "Password" }
        )]
        [ProducesResponseType(typeof(PasswordResponse), 200)]
        [ProducesResponseType(typeof(PasswordResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult List()
        {
            PasswordResponse response;

            try
            {
                response = _userService.ListPwd();
            }
            catch
            {
                response = new PasswordResponse();
                response.IsValid = false;
                response.Error = true;
                response.AddMessage("Erro ao listar senhas");
            }

            if (response.Error || !response.IsValid)
            {
                return BadRequest(response);
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Incluir um Usuário, Login e Senha",
            Description = "[pt-BR] Incluir um Usuário, Login e Senha. \n\n " +
                "[en-US] Add a User, Login and Password. ",
            Tags = new[] { "UserPassword" }
        )]
        [ProducesResponseType(typeof(UserPasswordResponse), 200)]
        [ProducesResponseType(typeof(UserPasswordResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Insert(UserPasswordRequest userRequest)
        {
            UserPasswordResponse response;

            try
            {
                response = _userService.InsertUserPwd(userRequest);
            }
            catch
            {
                response = new UserPasswordResponse();
                response.IsValid = false;
                response.Error = true;
                response.AddMessage("Erro ao incluir Usuario e Senha");
            }

            if (response.Error || !response.IsValid)
            {
                return BadRequest(response);
            }
            else
            {
                return Ok(response);
            }
        }
    }
}
