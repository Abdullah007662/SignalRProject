using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.DiscountDTO;
using SignalREntityLayer.Entities;

namespace SignalRWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountsController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult DiscountList()
        {
            var values = _mapper.Map<List<ResultDiscountDTO>>(_discountService.BGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDTO dTO)
        {
            _discountService.BAdd(_mapper.Map<Discount>(dTO));
            return Ok("Başarılı Bir Şekilde Oluşturuldu.!");
        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDTO dTO)
        {
            _discountService.BUpdate(_mapper.Map<Discount>(dTO));
            return Ok("Başarılı Bir Şekilde Güncellendi.!");
        }
        [HttpDelete]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.BGetById(id);
            _discountService.BDelete(value);
            return Ok("Başarılı Bir Şekilde Silindi.!");
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var value = _discountService.BGetById(id);
            return Ok(value);
        }
    }
}
