using Microsoft.AspNetCore.Mvc;
using Rasot.Core.Caching;
using Rasot.Web.Factories;
using Rasot.Web.Models;
using System.Diagnostics;

namespace Rasot.Web.Controllers
{

    public class HomeController : Controller
    {


        private readonly ICustomerModelFactory _customerModelFactory;
        private readonly ICacheManager _cacheManager;
        public HomeController(ICustomerModelFactory customerModelFactory,ICacheManager cacheManager)
        {
            _customerModelFactory = customerModelFactory;
            _cacheManager = cacheManager;
        }
        public IActionResult Index()
        {
             string cacheKey = "customer.first";
             var customerModel = _cacheManager.Get(cacheKey, () =>
             {
                 return _customerModelFactory.PrepareCustomerShortModel(1);
             }, 10);
            

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
