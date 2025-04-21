using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTO.SocialMediaDTO;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class SocialMediaController : Controller
    {
        private readonly HttpClient _httpClient;

        public SocialMediaController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyApiClient");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("api/SocialMedias");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateocialMedia(CreateSocialMediaDTO dTO)
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
        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var response = await _httpClient.GetAsync($"api/SocialMedias/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateSocialMediaDTO>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDTO dTO)
        {
            var jsonData = JsonConvert.SerializeObject(dTO);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("api/SocialMedias", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            var responseMessage = await _httpClient.DeleteAsync($"api/SocialMedias/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
