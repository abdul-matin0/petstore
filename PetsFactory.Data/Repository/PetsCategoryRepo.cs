using Microsoft.EntityFrameworkCore;
using PetsFactory.Data.Repository.IRepository;
using PetsFactory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetsFactory.Data.Repository
{
    //
    // implement Repository Pattern for PetsCategory

    public class PetsCategoryRepo : Repository<PetsCategory>, IPetsCategoryRepo
    {
        private readonly ApplicationDbContext _db;

        public PetsCategoryRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        //update for PetsCategory
        public void Update(PetsCategory categoryObj)
        {
            var objFromDb = _db.PetsCategory.FirstOrDefault(u => u.Id == categoryObj.Id);

            if(objFromDb != null)
            {
                objFromDb.CategoryName = categoryObj.CategoryName;
            }
        }
    }
}
