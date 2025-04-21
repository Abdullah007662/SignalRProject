using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTO.DiscountDTO;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class DiscountController : Controller
    {

        private readonly HttpClient _httpClient;

        public DiscountController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyApiClient");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("api/Discounts");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultDiscountDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateDiscount()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateDiscount(CreateDiscountDTO dTO)
        {
            var jsonData = JsonConvert.SerializeObject(dTO);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var reponse = await _httpClient.PostAsync("api/Abouts", content);
            if (reponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateDiscount(int id)
        {
            var response = await _httpClient.GetAsync($"api/Discounts/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateDiscountDTO>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateDiscount(UpdateDiscountDTO dTO)
        {
            var jsonData = JsonConvert.SerializeObject(dTO);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("api/Discounts", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteDiscount(int id)
        {
            var responseMessage = await _httpClient.DeleteAsync($"api/Discounts/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
