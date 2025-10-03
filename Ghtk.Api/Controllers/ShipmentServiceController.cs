using Ghtk.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ghtk.Api.Controllers
{
    [Route("/services/shipment")]
    [ApiController]
    public class ShipmentServiceController : ControllerBase
    {

        public ShipmentServiceController()
        {
        }
        [Route("order")]
        [HttpPost]
        public IActionResult CreateOreder([FromBody] CreateOrder createOrder)
        {
            return Ok();
        }
    }
}
