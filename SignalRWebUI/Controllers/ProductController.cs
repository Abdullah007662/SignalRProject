using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SignalRWebUI.DTO.CategoryDTO;
using SignalRWebUI.DTO.ProductDTO;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient _httpClient;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyApiClient");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("api/Products/ProductWithCategory");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithCategory>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var response = await _httpClient.GetAsync("api/Categories");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(jsonData);
                ViewBag.Categories = new SelectList(categories, "CategoryID", "CategoryName");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDTO dto)
        {
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Products", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var responseMessage = await _httpClient.DeleteAsync($"api/Products/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var productResponse = await _httpClient.GetAsync($"api/Products/{id}");
            var categoryResponse = await _httpClient.GetAsync("api/Categories");

            if (productResponse.IsSuccessStatusCode && categoryResponse.IsSuccessStatusCode)
            {
                var productJson = await productResponse.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<UpdateProductDTO>(productJson);

                if (product == null)
                {
                    return RedirectToAction("Index");
                }

                var categoryJson = await categoryResponse.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(categoryJson);
                ViewBag.Categories = new SelectList(categories, "CategoryID", "CategoryName", product.CategoryID);

                return View(product);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTO dto)
        {
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("api/Products", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(dto);

        }
    }
}
