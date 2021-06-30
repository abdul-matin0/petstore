using Microsoft.AspNetCore.Mvc;
using PetsFactory.Data.Repository.IRepository;
using PetsFactory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsFactory.Areas.Admin.Controllers
{
    // Pets category controller

    [Area("Admin")]
    public class CategoryController : Controller
    {
        // dbContext unitOfWork
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // view all pets categories
        public IActionResult Index()
        {
            IEnumerable<PetsCategory> allPetCategoriesObj = _unitOfWork.PetsCategory.GetAll();

            return View(allPetCategoriesObj);
        }

        // create and update categories
        public IActionResult Upsert(int? id)
        {
            PetsCategory categoryObj = new PetsCategory();

            if (id == null)
            {
                // create new category
                return View(categoryObj);
            }

            // edit category
            categoryObj = _unitOfWork.PetsCategory.GetFirstOrDefault(u => u.Id == id.Value);
            
            if (categoryObj == null)
            {
                return NotFound();
            }

            return View(categoryObj);
        }

        // on form submit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(PetsCategory categoryObj)
        {
            if (ModelState.IsValid)
            {
                if (categoryObj.Id == 0)
                {
                    // create
                    _unitOfWork.PetsCategory.Add(categoryObj);
                    TempData["Created"] = "Created Successfully";
                }
                else
                {
                    // update
                    _unitOfWork.PetsCategory.Update(categoryObj);
                    TempData["Created"] = "Updated Successfully";
                }
                _unitOfWork.Save();


                return RedirectToAction(nameof(Index));
            }
            // something went wrong

            return View(categoryObj);
        }

        #region API
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.PetsCategory.GetFirstOrDefault(u => u.Id == id);

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Something Went Wrong" });
            }

            _unitOfWork.PetsCategory.Remove(objFromDb);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Deleted Successfully" });
        }
        #endregion
    }
}
