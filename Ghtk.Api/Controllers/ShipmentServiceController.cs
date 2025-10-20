using System.Threading.Tasks;
using Ghtk.Api.Models;
using Ghtk.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ghtk.Api.Controllers
{
    [Authorize]
    [Route("/services/shipment")]
    [ApiController]

    public class ShipmentServiceController(ILogger<ShipmentServiceController> logger, IOrderRepository orderRepository) : ControllerBase
    {
        private readonly ILogger<ShipmentServiceController> _logger = logger;
        private readonly IOrderRepository _orderRepository = orderRepository;
        [Route("order")]
        [HttpPost]
        
        public async Task<IActionResult> SubmitOrder([FromBody] SubmitOrderRequest order)
        {
            _logger.LogInformation("SubmitOrder Called");
            var result =  await _orderRepository.CreateOrderAsync();
            var response = new SubmitOrderResponse
            {
                Success = true,
             //   Message = "Order submitted successfully",
                Order = new SubmitOrderResponseOrder
                {
                    PartnerId = order.Order.Id,
                    Label = "LabelData",
                    Area = 1,
                    Fee = 50000,
                    InsuranceFee = 0,
                    TrackingId = 123456789,
                    EstimatedPickTime = "2024-07-01T10:00:00Z",
                    EstimatedDeliverTime = "2024-07-03T18:00:00Z",
                    Products = order.Products,
                    StatusId = 1
                }
            };
            return Ok(response);
        }
        [HttpGet]
        [Route("v2/{id}")]
        public IActionResult GetOrderStatus(string id)
        {
            _logger.LogInformation($"GetOrderStatus Called with {id}");
            var result = new GetOrderStatusResponse
            {
                Success = true,
                // Message = "Order status retrieved successfully",
                Order = new Order
                {
                    LabelId = "LabelData",
                    PartnerId = id,
                    Status = 3,
                    StatusText = "In Transit",
                    Created = DateTimeOffset.UtcNow.AddDays(-2),
                    Modified = DateTimeOffset.UtcNow,
                    Message = "Your order is on the way",
                    PickDate = DateTimeOffset.UtcNow.AddDays(-1),
                    DeliverDate = DateTimeOffset.UtcNow.AddDays(1),
                    CustomerFullname = "John Doe",
                    CustomerTel = "0123456789",
                    Address = "123 Main St, District, Province",
                    StorageDay = 3,
                    ShipMoney = 50000,
                }
            };
            return Ok(result);
        }

        [HttpPost]
        [Route("cancel/{id}")]
        public IActionResult CancelOrder(string id)
        {
            _logger.LogInformation($"CancelOrder Called with {id}");
            var result = new ApiResults
            {
                Success = true,
                 Message = "Order cancelled successfully"
            };
            return Ok();
        }
    }
}
