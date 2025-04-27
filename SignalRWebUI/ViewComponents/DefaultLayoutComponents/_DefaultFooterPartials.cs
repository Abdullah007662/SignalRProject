using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTO.ContactDTO;

namespace SignalRWebUI.ViewComponents.DefaultLayoutComponents
{
    public class _DefaultFooterPartials : ViewComponent
    {
        private readonly HttpClient _httpClient;

        public _DefaultFooterPartials(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyApiClient");
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var responseMessage = await _httpClient.GetAsync("api/Contacts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

    }
}
