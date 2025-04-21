using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.ApiDTO.SocialMediaDTO;
using SignalREntityLayer.Entities;

namespace SignalRWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly ISocialMediaService socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediasController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            this.socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values = _mapper.Map<List<ResultSocialMediaDTO>>(socialMediaService.BGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDTO dTO)
        {
            socialMediaService.BAdd(_mapper.Map<SocialMedia>(dTO));
            return Ok("Başarılı Bir Şekilde Oluşturuldu");
        }
        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDTO dTO)
        {
            socialMediaService.BUpdate(_mapper.Map<SocialMedia>(dTO));
            return Ok("Başarılı Bir Şekilde Güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = socialMediaService.BGetById(id);
            socialMediaService.BDelete(value);
            return Ok("Başarılı Bir Şekilde Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = socialMediaService.BGetById(id);
            return Ok(value);
        }
    }
}
