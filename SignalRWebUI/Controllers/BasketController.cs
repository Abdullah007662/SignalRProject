using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTO.BasketDTO;
using System.Net.Http;

namespace SignalRWebUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly HttpClient _httpClient;

        public BasketController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyApiClient"); // Ensures you're using a configured HttpClient instance
        }

        // Action to display the basket items with product names for a specific menu table
        public async Task<IActionResult> Index(int id)
        {
            TempData["id"] = id;
            var responseMessage = await _httpClient.GetAsync($"api/Baskets/ListWithProducts/{id}"); // Correct endpoint
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBasketDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        // Action to delete a basket item
        [HttpPost]
        public async Task<IActionResult> DeleteBasket(int basketItemId, int menuTableId)
        {
            var response = await _httpClient.PostAsync($"api/Baskets/DeleteBasket?basketItemId={basketItemId}&menuTableId={menuTableId}", null);

            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Sepet öğesi başarıyla silindi."; // Success message
            }
            else
            {
                TempData["ErrorMessage"] = "Silme işlemi başarısız oldu."; // Failure message
            }

            return RedirectToAction("Index", new { id = menuTableId }); // Sepet sayfasına yönlendir
        }
    }
}
