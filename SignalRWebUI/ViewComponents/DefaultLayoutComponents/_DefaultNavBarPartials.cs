using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.DefaultLayoutComponents
{
    public class _DefaultNavBarPartials : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
