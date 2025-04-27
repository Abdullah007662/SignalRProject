using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTO.SliderDTO;

namespace SignalRWebUI.ViewComponents.DefaultLayoutComponents
{
    public class _DefaultSliderPartials : ViewComponent
    {
        private readonly HttpClient _httpClient;

        public _DefaultSliderPartials(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyApiClient");
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var responseMessage = await _httpClient.GetAsync("api/Sliders");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSliderDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
