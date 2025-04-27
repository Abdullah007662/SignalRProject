using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.DefaultLayoutComponents
{
    public class _DefaultBookATablePartials : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
