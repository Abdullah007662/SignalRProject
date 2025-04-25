using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.DefaultLayoutComponents
{
    public class _DefaultScriptPartials : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
