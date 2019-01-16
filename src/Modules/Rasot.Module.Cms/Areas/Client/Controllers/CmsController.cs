using Microsoft.AspNetCore.Mvc;

namespace Rasot.Module.Cms.Areas.Client.Controllers
{


    [Route("{contoller}/{action}")]
    public class CmsController:Controller
    {

        public IActionResult Detail()
        {
            return View();
        }
    }
}
