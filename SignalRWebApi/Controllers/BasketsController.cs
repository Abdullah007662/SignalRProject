using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalRBusinessLayer.Abstract;
using SignalRDataAccessLayer.Concrete;
using SignalRDtoLayer.ApiDTO.BasketDTO;
using SignalREntityLayer.Entities;
using SignalRWebApi.Models;

namespace SignalRWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly SignalRContext _context;
        private readonly IMapper _mapper;

        public BasketsController(
            IBasketService basketService,
            SignalRContext context,
            IMapper mapper)
        {
            _basketService = basketService;
            _context = context;
            _mapper = mapper;
        }

        // Endpoint to get basket by menu table ID
        [HttpGet("{menuTableId}")]
        public IActionResult GetBasketByMenuTableId(int menuTableId)
        {
            var basketList = _basketService.BGetBasketByMenuTableNumber(menuTableId);
            return Ok(basketList);
        }

        // Endpoint to get basket list with product names by menu table ID
        [HttpGet("ListWithProducts/{menuTableId}")]
        public IActionResult GetBasketListWithProducts(int menuTableId)
        {
            var baskets = _context.Baskets
                .Include(b => b.Product)
                .Where(b => b.MenuTableID == menuTableId)
                .Select(b => new ResultBasketListWithProduct
                {
                    BasketID = b.BasketID,
                    Count = b.Count,
                    MenuTableID = b.MenuTableID,
                    Price = b.Price,
                    ProductID = b.ProductID,
                    TotalPrice = b.TotalPrice,
                    ProductName = b.Product!.ProductName
                })
                .ToList();

            return Ok(baskets);
        }

        // Endpoint to create a new basket item
        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDTO dto)
        {
            if (dto.MenuTableID == 0)
            {
                return BadRequest("Masa seçilmedi.");
            }

            var product = _context.Products
             .FirstOrDefault(p => p.ProductID == dto.ProductID);

            if (product == null)
            {
                return BadRequest("Ürün bulunamadı.");
            }

            var basket = _mapper.Map<Basket>(dto);
            basket.Price = product.Price;
            basket.Count = 1;  // Default count (this can be adjusted as needed)
            basket.TotalPrice = basket.Price * basket.Count;

            _basketService.BAdd(basket);

            // Ensure the changes are persisted
            _context.SaveChanges();

            return Ok("Basket created successfully.");
        }

        // Endpoint to delete a basket item by ID
        [HttpPost("DeleteBasket")]
        public IActionResult DeleteBasket(int basketItemId, int menuTableId)
        {
            var basket = _basketService.BGetById(basketItemId);
            if (basket == null)
            {
                return NotFound("Basket item not found.");
            }

            // Sepeti sil
            _basketService.BDelete(basket);
            _context.SaveChanges(); // Veritabanına kaydet

            return Ok("Basket item deleted successfully.");
        }
    }
}
