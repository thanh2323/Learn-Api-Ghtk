using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientAuthentication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientSourceController : ControllerBase
    {
        private readonly ILogger<ClientSourceController> _logger;
        private readonly IClientSourceAuthenticationHandler _handler;

        public ClientSourceController(IClientSourceAuthenticationHandler handler, ILogger<ClientSourceController> logger )
        {
            _logger = logger;
            _handler = handler;
        }
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            _logger.LogInformation($"ClientSource Authentication Called with {id}");
            if (_handler.Validate(id))
            {
                _logger.LogInformation("ClientSource Authentication Succeeded");
                return Ok();
            }
            _logger.LogWarning("ClientSource Authentication Failed");
            return Unauthorized();
        }
    }
}
