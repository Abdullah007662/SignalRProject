using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTO.DiscountDTO;
using SignalRWebUI.DTO.SliderDTO;

namespace SignalRWebUI.ViewComponents.DefaultLayoutComponents
{
    public class _DefaultOfferPartials : ViewComponent
    {
        private readonly HttpClient _httpClient;

        public _DefaultOfferPartials(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyApiClient");
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var responseMessage = await _httpClient.GetAsync("api/Discounts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultDiscountDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
