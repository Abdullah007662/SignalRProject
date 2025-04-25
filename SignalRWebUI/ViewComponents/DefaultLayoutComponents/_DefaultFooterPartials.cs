using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.DefaultLayoutComponents
{
    public class _DefaultFooterPartials : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
