using Microsoft.AspNetCore.Mvc;
using rcManagerUserApplication.Interfaces;
using rcManagerUserApplication.Transport;
using Swashbuckle.AspNetCore.Annotations;

namespace rcManagerUserApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserPasswordController : ControllerBase
    {
        private readonly IUserPasswordService _userPwdService;

        public UserPasswordController(IUserPasswordService userPwdService)
        {
            this._userPwdService = userPwdService;
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

            try {
                response = _userPwdService.InsertUserPwd(userRequest);
            } catch {
                response = new UserPasswordResponse();
                response.IsValid = false;
                response.IsError = true;
                response.AddMessage("Erro ao incluir Usuario e Senha");
            }

            if (response.IsError || !response.IsValid) {
                return BadRequest(response);
            } else {
                return Ok(response);
            }
        }
    }
}
