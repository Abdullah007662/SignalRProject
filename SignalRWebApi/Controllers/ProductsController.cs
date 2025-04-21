using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.ApiDTO.ProductDTO;
using SignalREntityLayer.Entities;

namespace SignalRWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _mapper.Map<List<ResultProductDTO>>(_productService.BGetListAll());
            return Ok(values);
        }
        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            var values = _productService.ProductCount();
            return Ok(values);
        }
        [HttpGet("BProductCountByCategoryNameDrink")]
        public IActionResult BProductCountByCategoryNameDrink()
        {
            var values = _productService.BProductCountByCategoryNameDrink();
            return Ok(values);
        }
        [HttpGet("BProductCountByCategoryNameHamburger")]
        public IActionResult BProductCountByCategoryNameHamburger()
        {
            var values = _productService.BProductCountByCategoryNameHamburger();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDTO dTO)
        {
            _productService.BAdd(_mapper.Map<Product>(dTO));
            return Ok("Başarılı Bir Şekilde Oluşturuldu");
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDTO dTO)
        {
            _productService.BUpdate(_mapper.Map<Product>(dTO));
            return Ok("Başarılı Bir Şekilde Güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.BGetById(id);
            _productService.BDelete(value);
            return Ok("Başarılı Bir Şekilde Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _productService.BGetById(id);
            return Ok(value);
        }
        [HttpGet("ProductWithCategory")]
        public IActionResult ProductWithCategory()
        {
            var values = _mapper.Map<List<ResultProductWithCategory>>(_productService.BGetProductWithCategory());
            return Ok(values);
        }
    }
}
