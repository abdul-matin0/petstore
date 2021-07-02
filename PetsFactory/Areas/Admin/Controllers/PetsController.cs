using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetsFactory.Data.Repository.IRepository;
using PetsFactory.Models;
using PetsFactory.Models.ViewModels;
using PetsFactory.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PetsFactory.Areas.Admin.Controllers
{
    // Admin Pets CRUD Operations

    [Area("Admin")]
    [Authorize(Roles = Utilities.AdminUser)]
    public class PetsController : Controller
    {
        // dbContext unitOfWork
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PetsController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        // view all pets products
        public IActionResult Index()
        {
            IEnumerable<Pets> allPetsObj = _unitOfWork.Pets.GetAll(includeProperties: "PetCategory");

            return View(allPetsObj);
        }

        // create and update pets
        public IActionResult Upsert(int? id)
        {
            PetsViewModel petVM = new PetsViewModel() { 
                PetsObj = new Pets(),
                // category dropdown list
                CategoryList = _unitOfWork.PetsCategory.GetAll().Select(u => new SelectListItem { 
                    Text = u.CategoryName,
                    Value = u.Id.ToString()
                })
            };

            if (id == null)
            {
                // create new Pet
                return View(petVM);
            }

            // edit pet details
            petVM.PetsObj = _unitOfWork.Pets.GetFirstOrDefault(u => u.Id == id.Value);

            if (petVM.PetsObj == null)
            {
                return NotFound();
            }

            return View(petVM);
        }

        // on form submit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(PetsViewModel petVM)
        {
            if (ModelState.IsValid)
            {
                Pets objFromDb = _unitOfWork.Pets.Get(petVM.PetsObj.Id);

                string webRootPath = _hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                // check if a file was selected
                if (files.Count > 0)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images\pets");
                    var extension = Path.GetExtension(files[0].FileName);

                    if (petVM.PetsObj.PetImage != null)
                    {
                        // for update, image url is not null
                        var imagePath = Path.Combine(webRootPath, petVM.PetsObj.PetImage.TrimStart('\\'));

                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }
                    }
                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStreams);
                    }

                    petVM.PetsObj.PetImage = @"\images\pets\" + fileName + extension;

                    // delete image if obj is for update and image url is not null
                    if (petVM.PetsObj.Id != 0)
                    {
                        if (objFromDb.PetImage != null)
                        {
                            var filePath = Path.Combine(webRootPath, objFromDb.PetImage.TrimStart('\\'));

                            if (System.IO.File.Exists(filePath))
                            {
                                System.IO.File.Delete(filePath);
                            }
                        }
                    }
                }
                else
                {
                    // no image was selected

                    // for update
                    if (petVM.PetsObj.Id != 0)
                    {
                        // get image from db and assign to view model
                        petVM.PetsObj.PetImage = objFromDb.PetImage;
                    }
                }

                // create new pet if Id == 0
                if (petVM.PetsObj.Id == 0)
                {
                    petVM.PetsObj.DateAdded = DateTime.Now;

                    _unitOfWork.Pets.Add(petVM.PetsObj);
                    TempData["Created"] = "Created Successfully";
                }
                else
                {
                    // update pet
                    _unitOfWork.Pets.Update(petVM.PetsObj);
                    TempData["Created"] = "Updated Successfully";
                }

                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                // something went wrong
                // load ProductViewModel and pass to view

                petVM.CategoryList = _unitOfWork.PetsCategory.GetAll().Select(s => new SelectListItem
                {
                    Text = s.CategoryName,
                    Value = s.Id.ToString()
                });

                if (petVM.PetsObj.Id != 0)
                {
                    // for update
                    petVM.PetsObj = _unitOfWork.Pets.Get(petVM.PetsObj.Id);
                }
            }

            return View(petVM);
        }

        #region API
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Pets.GetFirstOrDefault(u => u.Id == id);

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Something Went Wrong" });
            }

            // delete image from file folder
            string webRootPath = _hostEnvironment.WebRootPath;
            var imagePath = Path.Combine(webRootPath, objFromDb.PetImage.TrimStart('\\'));

            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            _unitOfWork.Pets.Remove(objFromDb);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Deleted Successfully" });
        }
        #endregion
    }
}
