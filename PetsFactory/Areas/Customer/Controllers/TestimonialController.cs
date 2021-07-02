using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetsFactory.Data.Repository.IRepository;
using PetsFactory.Models;
using PetsFactory.Models.ViewModels;
using PetsFactory.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PetsFactory.Areas.Customer.Controllers
{
    // only logged in user can view / add testimonials
    [Area("Customer")]
    [Authorize]
    public class TestimonialController : Controller
    {
        // database unitOfWork injection
        private readonly IUnitOfWork _unitOfWork;

        public TestimonialController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // view all testimonials
        public IActionResult Index()
        {
            IEnumerable<Testimonial> testimonials = _unitOfWork.Testimonial.GetAll(includeProperties: "ApplicationUser,Pets");

            return View(testimonials);
        }

        // add testimony
        public IActionResult AddTestimonial()
        {

            // pet dropdown and comment messsage
            TestimonialViewModel testimonialVM = new TestimonialViewModel()
            {
                TestimonialObj = new Testimonial(),
                PetSelectList = _unitOfWork.Pets.GetAll().Select(u => new SelectListItem { 
                    Text = u.Name,
                    Value = u.Id.ToString()
                })

            };

            return View(testimonialVM);
        }

        [HttpPost]
        public IActionResult AddTestimonial(TestimonialViewModel testimonialVM)
        {

            if (ModelState.IsValid)
            {
                
                if(testimonialVM.TestimonialObj.CommentMessage.Length > 100)
                {
                    // commment message is too long
                    TempData["Error"] = "Comment Message too long, should be less than 100";

                    // something went wrong
                    testimonialVM = new TestimonialViewModel()
                    {
                        TestimonialObj = new Testimonial(),
                        PetSelectList = _unitOfWork.Pets.GetAll().Select(u => new SelectListItem
                        {
                            Text = u.Name,
                            Value = u.Id.ToString()
                        })

                    };

                    return View(testimonialVM);
                }

                // get logged in user
                var identity = (ClaimsIdentity)User.Identity;
                var claims = identity.FindFirst(ClaimTypes.NameIdentifier);

                testimonialVM.TestimonialObj.ApplicationUserId = claims.Value;
                // add testimonial to db
                _unitOfWork.Testimonial.Add(testimonialVM.TestimonialObj);

                // add notification
                Notifications notifications = new Notifications();
                notifications.DateAdded = DateTime.Now;
                notifications.Title = Utilities.RequestNotification;
                notifications.Message = "New Testimonial Added by user";
                notifications.Role = Utilities.AdminUser;

                _unitOfWork.Notifications.Add(notifications);

                _unitOfWork.Save();

                TempData["Success"] = "Testimony Added Successfully";

                return RedirectToAction(nameof(Index));

            }

            // something went wrong
            testimonialVM = new TestimonialViewModel()
            {
                TestimonialObj = new Testimonial(),
                PetSelectList = _unitOfWork.Pets.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })

            };


            TempData["Error"] = "Empty Field, Invalid input state!";

            return View(testimonialVM);

        }
    }
}
