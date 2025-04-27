using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTO.ContactDTO;
using SignalRWebUI.DTO.SliderDTO;

namespace SignalRWebUI.ViewComponents.LayoutComponents
{
    public class _LayoutFooterPartials : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
