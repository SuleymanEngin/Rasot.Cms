
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rasot.Service.Services.Authentications;
using Rasot.Web.Framework.Controllers;
using Rasot.Web.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace Rasot.Web.Controllers
{

    public class HomeController : BaseController
    {


        private readonly IAuthenticationService _authenticationService;
   
        public HomeController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
           
        }
        public IActionResult Index()
        {

            var loginResponse = _authenticationService.Login(new Service.Services.Authentications.Models.LoginRequest() {
                 Email="cngz.gur@gmail.com",
                 Password="001453"
            });

            _authenticationService.SigIn(loginResponse.ValidCustomer);

            var loginUser = _authenticationService.GetAuthentication();
          
            return View();
        }

        public dynamic Dynamics(List<string> includes)
        {

            return null;
        }

        [Authorize(Roles ="Admine")]
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
