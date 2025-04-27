using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTO.AboutDTO;

namespace SignalRWebUI.ViewComponents.DefaultLayoutComponents
{
    public class _DefaultAboutPartials : ViewComponent
    {
        private readonly HttpClient _httpClient;

        public _DefaultAboutPartials(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyApiClient");
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var responseMessage = await _httpClient.GetAsync("api/Abouts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
