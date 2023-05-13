using Microsoft.AspNetCore.Mvc;
using rcManagerUserApplication.Interfaces;
using rcManagerUserApplication.Transport;
using Swashbuckle.AspNetCore.Annotations;

namespace rcManagerApi.Controllers
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
            Tags = new[] { "User" }
        )]
        [ProducesResponseType(typeof(UserResponse), 200)]
        [ProducesResponseType(typeof(UserResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult List()
        {
            UserResponse response;

            try {
                response = _userService.List();
            } catch {
                response = new UserResponse();
                response.IsValid = false;
                response.IsError = true;
                response.AddMessage("Erro ao listar Usuarios");
            }

            if (response.IsError || !response.IsValid) {
                return BadRequest(response);
            } else {
                return Ok(response);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Obter um Usuário pelo id",
            Description = "[pt-BR] Obter um Usuário pelo id. \n\n " +
                "[en-US] Get a User by id. ",
            Tags = new[] { "User" }
        )]
        [ProducesResponseType(typeof(UserResponse), 200)]
        [ProducesResponseType(typeof(UserResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Get(long id)
        {
            UserResponse response;

            try {
                response = _userService.Get(id);
            } catch {
                response = new UserResponse();
                response.IsValid = false;
                response.IsError = true;
                response.AddMessage("Erro ao consultar Usuario");
            }

            if (response.IsError || !response.IsValid) {
                return BadRequest(response);
            } else {
                return Ok(response);
            }
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Incluir um Usuário",
            Description = "[pt-BR] Incluir um Usuário. \n\n " +
                "[en-US] Add a User. ",
            Tags = new[] { "User" }
        )]
        [ProducesResponseType(typeof(UserResponse), 200)]
        [ProducesResponseType(typeof(UserResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Insert(UserRequest userRequest)
        {
            UserResponse response;

            try {
                response = _userService.Insert(userRequest);
            } catch {
                response = new UserResponse();
                response.IsValid = false;
                response.IsError = true;
                response.AddMessage("Erro ao incluir Usuario");
            }

            if (response.IsError || !response.IsValid) {
                return BadRequest(response);
            } else {
                return Ok(response);
            }
        }

        [HttpPut]
        [SwaggerOperation(
            Summary = "Atualizar um Usuário",
            Description = "[pt-BR] Atualizar um Usuário. \n\n " +
                "[en-US] Update a User. ",
            Tags = new[] { "User" }
        )]
        [ProducesResponseType(typeof(UserResponse), 200)]
        [ProducesResponseType(typeof(UserResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Update(UserRequest userRequest)
        {
            UserResponse response;

            try {
                response = _userService.Update(userRequest);
            } catch {
                response = new UserResponse();
                response.IsValid = false;
                response.IsError = true;
                response.AddMessage("Erro ao alterar Usuario");
            }

            if (response.IsError || !response.IsValid) {
                return BadRequest(response);
            } else {
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Excluir um Usuário",
            Description = "[pt-BR] Excluir um Usuário. \n\n " +
                "[en-US] Delete a User. ",
            Tags = new[] { "User" }
        )]
        [ProducesResponseType(typeof(UserResponse), 200)]
        [ProducesResponseType(typeof(UserResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Delete(long id)
        {
            UserResponse response;

            try {
                response = _userService.Delete(id);
            } catch {
                response = new UserResponse();
                response.IsValid = false;
                response.IsError = true;
                response.AddMessage("Erro ao excluir Usuario");
            }

            if (response.IsError || !response.IsValid) {
                return BadRequest(response);
            } else {
                return Ok(response);
            }
        }
    }
}
