using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTO.BasketDTO;
using SignalRWebUI.DTO.MenuTableDTO;
using SignalRWebUI.DTO.ProductDTO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Controllers
{
    public class MenüController : Controller
    {
        private readonly HttpClient _httpClient;

        public MenüController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyApiClient");
        }

        public async Task<IActionResult> Index()
        {
            // Get Products and MenuTables
            var productResponse = await _httpClient.GetAsync("api/Products");
            var tableResponse = await _httpClient.GetAsync("api/MenuTables");

            if (productResponse.IsSuccessStatusCode && tableResponse.IsSuccessStatusCode)
            {
                // Deserialize the responses into DTOs
                var productJson = await productResponse.Content.ReadAsStringAsync();
                var tableJson = await tableResponse.Content.ReadAsStringAsync();

                var products = JsonConvert.DeserializeObject<List<ResultProductDTO>>(productJson);
                var tables = JsonConvert.DeserializeObject<List<MenuTableDTO>>(tableJson);

                ViewBag.Tables = tables;
                return View(products);
            }

            var responseMessage = await _httpClient.GetAsync("api/Products");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDTO>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBasket(int id, int menuTableId)
        {
            if (menuTableId == 0)
            {
                TempData["ErrorMessage"] = "Masa seçilmeden ürün eklenemez.";
                return RedirectToAction("Index");
            }

            var createBasketDto = new CreateBasketDTO
            {
                ProductID = id,
                MenuTableID = menuTableId
            };

            var jsonData = JsonConvert.SerializeObject(createBasketDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Sepete ürün ekleme
            var basketResponse = await _httpClient.PostAsync("api/Baskets", stringContent);

            // Masa durumunu aktif hale getirme
            var tableResponse = await _httpClient.GetAsync($"api/MenuTables/ChangeMenuTableStatusToTrue?id={menuTableId}");

            if (basketResponse.IsSuccessStatusCode && tableResponse.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Ürün başarıyla sepete eklendi.";
                return RedirectToAction("Index");
            }

            TempData["ErrorMessage"] = "Ürün sepete eklenirken bir hata oluştu.";
            return RedirectToAction("Index");
        }
    }
}
