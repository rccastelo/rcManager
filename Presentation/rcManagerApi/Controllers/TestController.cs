using Microsoft.AspNetCore.Mvc;

namespace rcManagerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public string test() {
            return "ok";
        }
    }
}
