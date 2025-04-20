using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.ApiDTO.FeatureDTO;
using SignalREntityLayer.Entities;

namespace SignalRWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeaturesController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _mapper.Map<List<ResultFeatureDTO>>(_featureService.BGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDTO dTO)
        {
            _featureService.BAdd(_mapper.Map<Feature>(dTO));
            return Ok("Başarılı Bir Şekilde Oluşturuldu");
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDTO dTO)
        {
            _featureService.BUpdate(_mapper.Map<Feature>(dTO));
            return Ok("Başarılı Bir Şekilde Güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var value = _featureService.BGetById(id);
            _featureService.BDelete(value);
            return Ok("Başarılı Bir Şekilde Silindi");
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var value = _featureService.BGetById(id);
            return Ok(value);
        }
    }
}
