using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.ApiDTO.AboutDTO;
using SignalREntityLayer.Entities;

namespace SignalRWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutsController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var aboutDTOs = _mapper.Map<List<ResultAboutDTO>>(_aboutService.BGetListAll());
            return Ok(aboutDTOs);
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDTO createAboutDto)
        {
            _aboutService.BAdd(_mapper.Map<About>(createAboutDto));
            return Ok("Hakkımızda bilgisi başarıyla eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var about = _aboutService.BGetById(id);
            _aboutService.BDelete(about);
            return Ok("Hakkımızda bilgisi başarıyla silindi.");
        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDTO updateAboutDTO)
        {
            _aboutService.BUpdate(_mapper.Map<About>(updateAboutDTO));
            return Ok("Hakkımızda bilgisi başarıyla güncellendi.");
        }
        [HttpGet("GetByID")]
        public IActionResult GetById(int id)
        {
            var value = _aboutService.BGetById(id);
            return Ok(value);
        }

    }
}
