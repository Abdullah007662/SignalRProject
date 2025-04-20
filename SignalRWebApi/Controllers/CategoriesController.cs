using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.ApiDTO.CategoryDTO;
using SignalREntityLayer.Entities;

namespace SignalRWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _mapper.Map<List<ResultCategoryDTO>>(_categoryService.BGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDTO createCategoryDTO)
        {
            _categoryService.BAdd(_mapper.Map<Category>(createCategoryDTO));
            return Ok("Kategori Başarılı Bir Şekilde Oluşturuldu");
        }
        [HttpDelete("{id}")]
        public IActionResult CategoryDelete(int id)
        {
            var value = _categoryService.BGetById(id);
            _categoryService.BDelete(value);
            return Ok("Kategori Başarılı Bir Şekilde Silindi");
        }
        [HttpPut]
        public IActionResult CategoryUpdate(UpdateCategoryDTO dTO)
        {
            _categoryService.BUpdate(_mapper.Map<Category>(dTO));
            return Ok("Kategori Başarılı Bir Şekilde Güncellendi");
        }
        [HttpGet("GetByID")]
        public IActionResult GetById(int id)
        {
            var value = _categoryService.BGetById(id);
            return Ok(value);
        }

    }
}
