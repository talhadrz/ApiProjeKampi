using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebUI.ViewComponets
{
    public class _HeadDefaultComponetPartial :ViewComponent
    {
         public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
