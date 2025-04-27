using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTO.AboutDTO;
using SignalRWebUI.DTO.ProductDTO;

namespace SignalRWebUI.ViewComponents.DefaultLayoutComponents
{
    public class _DefaultOurMenüPartials : ViewComponent
    {
        private readonly HttpClient _httpClient;

        public _DefaultOurMenüPartials(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyApiClient");
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var responseMessage = await _httpClient.GetAsync("api/Products");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
