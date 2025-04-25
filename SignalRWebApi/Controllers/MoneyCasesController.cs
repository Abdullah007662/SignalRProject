using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;

namespace SignalRWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyCasesController : ControllerBase
    {
        private readonly IMoneyCaseService _moneyCaseService;

        public MoneyCasesController(IMoneyCaseService moneyCaseService)
        {
            _moneyCaseService = moneyCaseService;
        }
        [HttpGet]
        public IActionResult TotalMoneyCaseAmount()
        {
            return Ok(_moneyCaseService.BTotalMoneyCaseAmount());
        }
    }
}
