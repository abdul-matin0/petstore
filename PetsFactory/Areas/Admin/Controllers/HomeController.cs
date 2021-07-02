using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetsFactory.Data.Repository.IRepository;
using PetsFactory.Models;
using PetsFactory.Models.ViewModels;
using PetsFactory.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsFactory.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Utilities.AdminUser)]
    public class HomeController : Controller
    {
        // dbContext unitOfWork
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // method to view analysis of Pets and Application
        public IActionResult Index()
        {
            AdminViewModel adminViewModel = new AdminViewModel() {
                PetsCount = _unitOfWork.Pets.GetAll().Count(),
                NotificationsCount = _unitOfWork.Notifications.GetAll().Count(),
                UsersCount = _unitOfWork.ApplicationUser.GetAll().Count(),
                TestimonialsList = _unitOfWork.Testimonial.GetAll(includeProperties: "ApplicationUser,Pets").OrderByDescending(u => u.Id),
                DaysPetCount = new Dictionary<string, int>() {
                    { "Monday", 0},
                    { "Tuesday", 0},
                    { "Wednesday", 0},
                    { "Thursday", 0},
                    { "Friday", 0},
                    { "Saturday", 0},
                    { "Sunday", 0}
                }
            };

            IEnumerable<Pets> allPet = _unitOfWork.Pets.GetAll().Where(u => u.DateAdded != null);

            // if Pets have been created
            if(allPet != null)
            {
                foreach (var item in allPet)
                {
                    foreach (var kvp in adminViewModel.DaysPetCount.ToList())
                    {
                        if (item.DateAdded.DayOfWeek.ToString().Equals(kvp.Key))
                        {
                            adminViewModel.DaysPetCount[kvp.Key]++;
                            break;
                        }
                    }
                }
            }

            return View(adminViewModel);
        }

        
    }
}
