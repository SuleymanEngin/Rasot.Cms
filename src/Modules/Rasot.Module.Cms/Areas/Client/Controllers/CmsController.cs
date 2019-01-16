using Microsoft.AspNetCore.Mvc;
using Rasot.Service.Services.Customers;
using Rasot.Web.Framework.Controllers;

namespace Rasot.Module.Cms.Areas.Client.Controllers
{

   
    public class CmsController: ModuleController
    {
        private readonly ICustomerService _customerService;
        public CmsController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public IActionResult Detail()
        {
            return View();
        }
    }
}
