using Microsoft.AspNetCore.Mvc;
using Rasot.Web.Factories;
using Rasot.Web.Models;
using System.Diagnostics;

namespace Rasot.Web.Controllers
{

    public class HomeController : Controller
    {

    
        public IActionResult Index()
        {
          
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
