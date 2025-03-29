using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebUI.ViewComponets
{
    public class _NavbarDefaultComponetPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
