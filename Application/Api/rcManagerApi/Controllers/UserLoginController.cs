using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rcManagerUserApplication.Interfaces;
using rcManagerUserApplication.Transport;
using Swashbuckle.AspNetCore.Annotations;

namespace rcManagerApi.Controllers
{
    [Authorize(Policy = "Manager")]
    [ApiController]
    [Route("[controller]")]
    public class UserLoginController : ControllerBase
    {
        private readonly IUserLoginService _userLoginService;

        public UserLoginController(IUserLoginService userLoginService)
        {
            this._userLoginService = userLoginService;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Incluir um Usuário, Login e Senha",
            Description = "[pt-BR] Incluir um Usuário, Login e Senha. \n\n " +
                "[en-US] Add a User, Login and Password. ",
            Tags = new[] { "UserLogin" }
        )]
        [ProducesResponseType(typeof(UserLoginResponse), 200)]
        [ProducesResponseType(typeof(UserLoginResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Insert(UserLoginRequest request)
        {
            UserLoginResponse response;

            try {
                response = _userLoginService.InsertUserLogin(request);
            } catch {
                response = new UserLoginResponse();
                response.IsValid = false;
                response.IsError = true;
                response.AddMessage("Erro ao incluir Usuário e Login");
            }

            if (response.IsError || !response.IsValid) {
                return BadRequest(response);
            } else {
                return Ok(response);
            }
        }
    }
}
