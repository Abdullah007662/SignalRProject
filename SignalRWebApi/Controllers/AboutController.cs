using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.AboutDTO;
using SignalREntityLayer.Entities;

namespace SignalRWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var aboutEntities = _aboutService.BGetListAll();
            var aboutDTOs = _mapper.Map<List<ResultAboutDTO>>(aboutEntities);
            return Ok(aboutDTOs);
        }

        [HttpPost]
        public IActionResult Create(CreateAboutDTO createAboutDto)
        {
            var aboutEntity = _mapper.Map<About>(createAboutDto);
            _aboutService.BAdd(aboutEntity);
            return Ok("Hakkımızda bilgisi başarıyla eklendi.");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var about = _aboutService.BGetById(id);
            if (about == null)
            {
                return NotFound("Silinecek içerik bulunamadı.");
            }
            _aboutService.BDelete(about);
            return Ok("Hakkımızda bilgisi başarıyla silindi.");
        }
    }
}
