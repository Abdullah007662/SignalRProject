using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;

namespace SignalRWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        public IActionResult TotalOrderCount()
        {
            return Ok(_orderService.BTotalOrderCount());
        }
        [HttpGet("ActiveOrderCount")]
        public IActionResult ActiveOrderCount()
        {
            return Ok(_orderService.BActiveOrderCount());
        }
        [HttpGet("LastOrderPrice")]
        public IActionResult LastOrderPrice()
        {
            return Ok(_orderService.BLastOrderPrice());
        }
        [HttpGet("TotalMoneyCaseAmount")]
        public IActionResult TotalMoneyCaseAmount()
        {
            return Ok(_orderService.BTotalMoneyCaseAmount());
        }
    }
}
