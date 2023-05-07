using Microsoft.AspNetCore.Mvc;
using rcManagerUserApplication.Interfaces;
using rcManagerUserApplication.Transport;
using Swashbuckle.AspNetCore.Annotations;

namespace rcManagerUserApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Listar todos os Usuários",
            Description = "[pt-BR] Listar todos os Usuários. \n\n " +
                "[en-US] List all Users. ",
            Tags = new[] { "Users" }
        )]
        [ProducesResponseType(typeof(UserResponse), 200)]
        [ProducesResponseType(typeof(UserResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult List()
        {
            UserResponse userRequestRet;

            try {
                userRequestRet = _userService.List();
            } catch {
                userRequestRet = new UserResponse();
                userRequestRet.IsValid = false;
                userRequestRet.Error = true;
                userRequestRet.AddMessage("Erro ao listar Usuarios");
            }

            if (userRequestRet.Error || !userRequestRet.IsValid) {
                return BadRequest(userRequestRet);
            } else {
                return Ok(userRequestRet);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Obter um Usuário pelo id",
            Description = "[pt-BR] Obter um Usuário pelo id. \n\n " +
                "[en-US] Get a User by id. ",
            Tags = new[] { "Users" }
        )]
        [ProducesResponseType(typeof(UserResponse), 200)]
        [ProducesResponseType(typeof(UserResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Get(long id)
        {
            UserResponse userRequestRet;

            try {
                userRequestRet = _userService.Get(id);
            } catch {
                userRequestRet = new UserResponse();
                userRequestRet.IsValid = false;
                userRequestRet.Error = true;
                userRequestRet.AddMessage("Erro ao consultar Usuario");
            }

            if (userRequestRet.Error || !userRequestRet.IsValid) {
                return BadRequest(userRequestRet);
            } else {
                return Ok(userRequestRet);
            }
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Incluir um Usuário",
            Description = "[pt-BR] Incluir um Usuário. \n\n " +
                "[en-US] Add a User. ",
            Tags = new[] { "Users" }
        )]
        [ProducesResponseType(typeof(UserResponse), 200)]
        [ProducesResponseType(typeof(UserResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Insert(UserRequest userRequest)
        {
            UserResponse userRequestRet;

            try {
                userRequestRet = _userService.Insert(userRequest);
            } catch {
                userRequestRet = new UserResponse();
                userRequestRet.IsValid = false;
                userRequestRet.Error = true;
                userRequestRet.AddMessage("Erro ao incluir Usuario");
            }

            if (userRequestRet.Error || !userRequestRet.IsValid) {
                return BadRequest(userRequestRet);
            } else {
                return Ok(userRequestRet);
            }
        }

        [HttpPut]
        [SwaggerOperation(
            Summary = "Atualizar um Usuário",
            Description = "[pt-BR] Atualizar um Usuário. \n\n " +
                "[en-US] Update a User. ",
            Tags = new[] { "Users" }
        )]
        [ProducesResponseType(typeof(UserResponse), 200)]
        [ProducesResponseType(typeof(UserResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Update(UserRequest userRequest)
        {
            UserResponse userRequestRet;

            try {
                userRequestRet = _userService.Update(userRequest);
            } catch {
                userRequestRet = new UserResponse();
                userRequestRet.IsValid = false;
                userRequestRet.Error = true;
                userRequestRet.AddMessage("Erro ao alterar Usuario");
            }

            if (userRequestRet.Error || !userRequestRet.IsValid) {
                return BadRequest(userRequestRet);
            } else {
                return Ok(userRequestRet);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Excluir um Usuário",
            Description = "[pt-BR] Excluir um Usuário. \n\n " +
                "[en-US] Delete a User. ",
            Tags = new[] { "Users" }
        )]
        [ProducesResponseType(typeof(UserResponse), 200)]
        [ProducesResponseType(typeof(UserResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Delete(long id)
        {
            UserResponse userRequestRet;

            try {
                userRequestRet = _userService.Delete(id);
            } catch {
                userRequestRet = new UserResponse();
                userRequestRet.IsValid = false;
                userRequestRet.Error = true;
                userRequestRet.AddMessage("Erro ao excluir Usuario");
            }

            if (userRequestRet.Error || !userRequestRet.IsValid) {
                return BadRequest(userRequestRet);
            } else {
                return Ok(userRequestRet);
            }
        }
    }
}
