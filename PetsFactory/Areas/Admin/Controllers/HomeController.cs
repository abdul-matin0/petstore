using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetsFactory.Data.Repository.IRepository;
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
            return View();
        }

        
    }
}
