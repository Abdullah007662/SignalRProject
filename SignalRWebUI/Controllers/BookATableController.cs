using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SignalRWebUI.DTO.BookingDTO;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class BookATableController : Controller
    {
        private readonly HttpClient _httpClient;

        public BookATableController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyApiClient"); // Configured named client
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("api/Contact");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var items = JArray.Parse(responseBody);
            var location = items[0]["location"]?.ToString();
            ViewBag.location = location;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateBookingDTO createBookingDto)
        {
            // Tekrar location çekiyoruz (sayfa yenilenince kaybolmaması için)
            var contactResponse = await _httpClient.GetAsync("api/Contact");
            contactResponse.EnsureSuccessStatusCode();
            var contactBody = await contactResponse.Content.ReadAsStringAsync();
            var contacts = JArray.Parse(contactBody);
            var location = contacts[0]["location"]?.ToString();
            ViewBag.location = location;

            // Formdan gelen CreateBookingDto üzerine Description ekliyoruz
            createBookingDto.Description = "b";

            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var bookingResponse = await _httpClient.PostAsync("api/Booking", content);

            if (bookingResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            else
            {
                var errorContent = await bookingResponse.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, errorContent);
                return View();
            }
        }
    }
}
