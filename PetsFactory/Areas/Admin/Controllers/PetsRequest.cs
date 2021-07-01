using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetsFactory.Data.Repository.IRepository;
using PetsFactory.Models;
using PetsFactory.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PetsFactory.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PetsRequest : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PetsRequest(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //admin view all pets requests
        // customer view only personal requests
        public IActionResult Index()
        {
            IEnumerable<Requests> allRequests;

            // get currenrly logged in user
            var identity = (ClaimsIdentity)User.Identity;
            var claims = identity.FindFirst(ClaimTypes.NameIdentifier);

            // if user is a customer, only show customer list
            if (User.IsInRole(Utilities.CustomerUser))
            {
                allRequests =_unitOfWork.Requests.GetAll(u => u.ApplicationUserId == claims.Value, includeProperties: "Pets");
            }else
            {
                allRequests = _unitOfWork.Requests.GetAll(includeProperties: "Pets");
            }

            return View(allRequests);
        }

        // view
        public IActionResult Upsert(int id)
        {
            var requestObj =_unitOfWork.Requests.GetFirstOrDefault(u => u.Id == id, includeProperties: "ApplicationUser,Pets");

            if(requestObj == null)
            {
                return NotFound();
            }

            return View(requestObj);
        }

        // accept
        public IActionResult Accept(int id)
        {
            var requestObj = _unitOfWork.Requests.GetFirstOrDefault(u => u.Id == id, includeProperties: "Pets");

            if (requestObj == null)
            {
                return NotFound();
            }

            // accept request, and add to notification
            requestObj.Status = Utilities.Accept;

            _unitOfWork.Requests.Update(requestObj);

            Notifications notifications = new Notifications();
            notifications.DateAdded = DateTime.Now;
            notifications.Message = "Pet Request Accepted";
            notifications.Title = Utilities.RequestAcceptedNotification;
            notifications.Role = Utilities.AdminUser;

            _unitOfWork.Notifications.Add(notifications);
            _unitOfWork.Save();

            TempData["Created"] = "Accepted";

            return RedirectToAction(nameof(Index));
        }

        // delete request
        #region API
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Requests.GetFirstOrDefault(u => u.Id == id);

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Something Went Wrong" });
            }

            _unitOfWork.Requests.Remove(objFromDb);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Deleted Successfully" });

        }
        #endregion
    }
}
