using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace rcManagerApi.Controllers
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
            Tags = new[] { "Tests" }
        )]
        [ProducesResponseType(200)]
        public string Test() {
            return "ok";
        }
    }
}
