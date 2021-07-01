using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetsFactory.Data.Repository.IRepository;
using PetsFactory.Models;
using PetsFactory.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsFactory.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Utilities.AdminUser)]

    public class NotificationsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotificationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // view all notificaitons 
        public IActionResult Index()
        {
            IEnumerable<Notifications> allNotifications = _unitOfWork.Notifications.GetAll();

            return View(allNotifications);
        }

        // delete notification
        #region API
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Notifications.GetFirstOrDefault(u => u.Id == id);

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Something Went Wrong" });
            }

            _unitOfWork.Notifications.Remove(objFromDb);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Deleted Successfully" });

        }
        #endregion
    }
}
