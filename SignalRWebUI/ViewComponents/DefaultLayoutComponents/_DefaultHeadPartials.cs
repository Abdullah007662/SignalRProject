using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.DefaultLayoutComponents
{
    public class _DefaultHeadPartials : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
