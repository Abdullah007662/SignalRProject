using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.LayoutComponents
{
	public class _LayoutHeaderPartials : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
