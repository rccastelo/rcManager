using Microsoft.AspNetCore.Mvc;
using rcManagerUserApplication.Application;
using rcManagerUserApplication.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System;

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
            Tags = new[] { "Users" }
        )]
        [ProducesResponseType(typeof(UserTransfer), 200)]
        [ProducesResponseType(typeof(UserTransfer), 400)]
        [ProducesResponseType(500)]
        public IActionResult List(UserTransfer userTransfer)
        {
            UserTransfer userTransferRet;

            try
            {
                userTransferRet = _userService.List(userTransfer);
            }
            catch (Exception ex)
            {
                userTransferRet = new UserTransfer();
                userTransferRet.Valid = false;
                userTransferRet.Error = true;
                userTransferRet.AddMessage("Erro ao listar Usuarios");
            }

            if (userTransferRet.Error || !userTransferRet.Valid)
            {
                return BadRequest(userTransferRet);
            }
            else
            {
                return Ok(userTransferRet);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Obter um Usuário pelo id",
            Description = "[pt-BR] Obter um Usuário pelo id. \n\n " +
                "[en-US] Get a User by id. ",
            Tags = new[] { "Users" }
        )]
        [ProducesResponseType(typeof(UserTransfer), 200)]
        [ProducesResponseType(typeof(UserTransfer), 400)]
        [ProducesResponseType(500)]
        public IActionResult Get(long id)
        {
            UserTransfer userTransferRet;

            try
            {
                userTransferRet = _userService.Get(id);
            }
            catch (Exception ex)
            {
                userTransferRet = new UserTransfer();
                userTransferRet.Valid = false;
                userTransferRet.Error = true;
                userTransferRet.AddMessage("Erro ao consultar Usuario");
            }

            if (userTransferRet.Error || !userTransferRet.Valid)
            {
                return BadRequest(userTransferRet);
            }
            else
            {
                return Ok(userTransferRet);
            }
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Incluir um Usuário",
            Description = "[pt-BR] Incluir um Usuário. \n\n " +
                "[en-US] Add a User. ",
            Tags = new[] { "Users" }
        )]
        [ProducesResponseType(typeof(UserTransfer), 200)]
        [ProducesResponseType(typeof(UserTransfer), 400)]
        [ProducesResponseType(500)]
        public IActionResult Insert(UserTransfer userTransfer)
        {
            UserTransfer userTransferRet;

            try
            {
                userTransferRet = _userService.Insert(userTransfer);
            }
            catch (Exception ex)
            {
                userTransferRet = new UserTransfer();
                userTransferRet.Valid = false;
                userTransferRet.Error = true;
                userTransferRet.AddMessage("Erro ao incluir Usuario");
            }

            if (userTransferRet.Error || !userTransferRet.Valid)
            {
                return BadRequest(userTransferRet);
            }
            else
            {
                return Ok(userTransferRet);
            }
        }

        [HttpPut]
        [SwaggerOperation(
            Summary = "Atualizar um Usuário",
            Description = "[pt-BR] Atualizar um Usuário. \n\n " +
                "[en-US] Update a User. ",
            Tags = new[] { "Users" }
        )]
        [ProducesResponseType(typeof(UserTransfer), 200)]
        [ProducesResponseType(typeof(UserTransfer), 400)]
        [ProducesResponseType(500)]
        public IActionResult Update(UserTransfer userTransfer)
        {
            UserTransfer userTransferRet;

            try
            {
                userTransferRet = _userService.Update(userTransfer);
            }
            catch (Exception ex)
            {
                userTransferRet = new UserTransfer();
                userTransferRet.Valid = false;
                userTransferRet.Error = true;
                userTransferRet.AddMessage("Erro ao alterar Usuario");
            }

            if (userTransferRet.Error || !userTransferRet.Valid)
            {
                return BadRequest(userTransferRet);
            }
            else
            {
                return Ok(userTransferRet);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Excluir um Usuário",
            Description = "[pt-BR] Excluir um Usuário. \n\n " +
                "[en-US] Delete a User. ",
            Tags = new[] { "Users" }
        )]
        [ProducesResponseType(typeof(UserTransfer), 200)]
        [ProducesResponseType(typeof(UserTransfer), 400)]
        [ProducesResponseType(500)]
        public IActionResult Delete(long id)
        {
            UserTransfer userTransferRet;

            try
            {
                userTransferRet = _userService.Delete(id);
            }
            catch (Exception ex)
            {
                userTransferRet = new UserTransfer();
                userTransferRet.Valid = false;
                userTransferRet.Error = true;
                userTransferRet.AddMessage("Erro ao excluir Usuario");
            }

            if (userTransferRet.Error || !userTransferRet.Valid)
            {
                return BadRequest(userTransferRet);
            }
            else
            {
                return Ok(userTransferRet);
            }
        }
    }
}
