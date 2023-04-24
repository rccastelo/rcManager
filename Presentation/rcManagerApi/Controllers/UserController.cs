using Microsoft.AspNetCore.Mvc;
using rcManagerServices.Interfaces;
using rcManagerTransfers.Transfers;
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
        public IActionResult list(UserTransfer userTransfer)
        {
            UserTransfer userTransferRet;

            try
            {
                userTransferRet = _userService.list(userTransfer);
            }
            catch (Exception ex)
            {
                userTransferRet = new UserTransfer();
                userTransferRet.valid = false;
                userTransferRet.error = true;
                userTransferRet.addMessage("Erro ao listar Usuarios");
            }

            if (userTransferRet.error || !userTransferRet.valid)
            {
                return BadRequest(userTransferRet);
            }
            else
            {
                return Ok(userTransferRet);
            }
        }

        [HttpGet("{id}")]
        public IActionResult get(long id)
        {
            UserTransfer userTransferRet;

            try
            {
                userTransferRet = _userService.get(id);
            }
            catch (Exception ex)
            {
                userTransferRet = new UserTransfer();
                userTransferRet.valid = false;
                userTransferRet.error = true;
                userTransferRet.addMessage("Erro ao consultar Usuario");
            }

            if (userTransferRet.error || !userTransferRet.valid)
            {
                return BadRequest(userTransferRet);
            }
            else
            {
                return Ok(userTransferRet);
            }
        }

        [HttpPost]
        public IActionResult insert(UserTransfer userTransfer)
        {
            UserTransfer userTransferRet;

            try
            {
                userTransferRet = _userService.insert(userTransfer);
            }
            catch (Exception ex)
            {
                userTransferRet = new UserTransfer();
                userTransferRet.valid = false;
                userTransferRet.error = true;
                userTransferRet.addMessage("Erro ao incluir Usuario");
            }

            if (userTransferRet.error || !userTransferRet.valid)
            {
                return BadRequest(userTransferRet);
            }
            else
            {
                return Ok(userTransferRet);
            }
        }

        [HttpPut]
        public IActionResult update(UserTransfer userTransfer)
        {
            UserTransfer userTransferRet;

            try
            {
                userTransferRet = _userService.update(userTransfer);
            }
            catch (Exception ex)
            {
                userTransferRet = new UserTransfer();
                userTransferRet.valid = false;
                userTransferRet.error = true;
                userTransferRet.addMessage("Erro ao alterar Usuario");
            }

            if (userTransferRet.error || !userTransferRet.valid)
            {
                return BadRequest(userTransferRet);
            }
            else
            {
                return Ok(userTransferRet);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult delete(long id)
        {
            UserTransfer userTransferRet;

            try
            {
                userTransferRet = _userService.delete(id);
            }
            catch (Exception ex)
            {
                userTransferRet = new UserTransfer();
                userTransferRet.valid = false;
                userTransferRet.error = true;
                userTransferRet.addMessage("Erro ao excluir Usuario");
            }

            if (userTransferRet.error || !userTransferRet.valid)
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
