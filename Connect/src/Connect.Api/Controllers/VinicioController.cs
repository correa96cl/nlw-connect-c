using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Connect.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VinicioController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Vinicio PORRRRAAA";
        }
    }
}
