using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.ApiDTO.TestimonialDTO;
using SignalREntityLayer.Entities;

namespace SignalRWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialsController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _mapper.Map<List<ResultTestimonialDTO>>(_testimonialService.BGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDTO dTO)
        {
            _testimonialService.BAdd(_mapper.Map<Testimonial>(dTO));
            return Ok("Başarılı Bir Şekilde Oluşturuldu");
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDTO dTO)
        {
            _testimonialService.BUpdate(_mapper.Map<Testimonial>(dTO));
            return Ok("Başarılı Bir Şekilde Güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.BGetById(id);
            _testimonialService.BDelete(value);
            return Ok("Başarılı Bir Şekilde Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _testimonialService.BGetById(id);
            return Ok(value);
        }
    }
}
