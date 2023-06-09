﻿using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace rcManagerUserApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(
            Summary = "Testar resposta da API",
            Description = "[pt-BR] Testar resposta da API. \n\n " +
                "[en-US] Test API response. ",
            Tags = new[] { "Test" }
        )]
        [ProducesResponseType(200)]
        public string Test()
        {
            return "ok";
        }
    }
}
