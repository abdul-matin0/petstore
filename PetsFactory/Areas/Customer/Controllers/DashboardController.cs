using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetsFactory.Data.Repository.IRepository;
using PetsFactory.Models;
using PetsFactory.Models.ViewModels;
using PetsFactory.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PetsFactory.Areas.Customer.Controllers
{
    // customer dashboard for logged in users
    [Area("Customer")]
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public DashboardController(ILogger<DashboardController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        // view all pets in application
        public IActionResult Index()
        {
            IEnumerable<Pets> petsObj =_unitOfWork.Pets.GetAll(includeProperties: "PetCategory");

            return View(petsObj);
        }

        // pet details
        public IActionResult Details(int id)
        {
            Pets petObj = new Pets();
            petObj = _unitOfWork.Pets.GetFirstOrDefault(u => u.Id == id, includeProperties: "PetCategory");

            if(petObj == null)
            {
                return NotFound();
            }

            return View(petObj);
        }

        // call to process request
        public IActionResult RequestPet(int id)
        {
            Pets petObj = new Pets();
            petObj =_unitOfWork.Pets.GetFirstOrDefault(u => u.Id == id);

            if(petObj == null)
            {
                TempData["Error"] = "Not Found";
                return RedirectToAction(nameof(Index));
            }

            // get currenrly logged in user
            var identity = (ClaimsIdentity)User.Identity;
            var claims = identity.FindFirst(ClaimTypes.NameIdentifier);

            // requests obj
            Requests requestObj = new Requests();
            requestObj.PetId = id;
            requestObj.ApplicationUserId = claims.Value;
            requestObj.DateRequested = DateTime.Now;
            requestObj.Status = Utilities.RequestPending;

            // notifications obj
            Notifications notifications = new Notifications();
            notifications.DateAdded = DateTime.Now;
            notifications.Title = Utilities.RequestNotification;
            notifications.Message = "New Request Sent from user";
            notifications.Role = Utilities.AdminUser;


            // send request and notification
            _unitOfWork.Requests.Add(requestObj);
            _unitOfWork.Notifications.Add(notifications);

            _unitOfWork.Save();

            TempData["Success"] = "Request Sent! Our team would contact you soon";

            return RedirectToAction(nameof(Index));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
