using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetsFactory.Models.ViewModels;
using PetsFactory.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PetsFactory.Areas.Customer.Controllers
{
    [Area("Customer")]
    // all users , including visitors
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (User.IsInRole(Utilities.AdminUser))
            {
                // logged in admin user
                // redirect to admin dashboard
                return RedirectToAction(actionName: "Index", controllerName: "Home", new { Area = "Admin"});
            }else if (User.IsInRole(Utilities.CustomerUser))
            {
                // logged in customer user
                // redirect to customer dashboard
                return RedirectToAction(actionName: "Index", controllerName: "Dashboard", new { Area = "Customer" });
            }

            // visitor

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
