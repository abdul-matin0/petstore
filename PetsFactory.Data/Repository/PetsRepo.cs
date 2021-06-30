using PetsFactory.Data.Repository.IRepository;
using PetsFactory.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetsFactory.Data.Repository
{
    // implement Repository Pattern for Pets

    public class PetsRepo : Repository<Pets>, IPetsRepo
    {
        private readonly ApplicationDbContext _db;

        public PetsRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        // update Pets properties database
        public void Update(Pets petObj)
        {
            var objFromDb = _db.Pets.FirstOrDefault(u => u.Id == petObj.Id);

            if(objFromDb != null)
            {
                if(petObj.PetImage != null)
                {
                    objFromDb.PetImage = petObj.PetImage;
                }

                objFromDb.Name = petObj.Name;
                objFromDb.Details = petObj.Details;
                objFromDb.CategoryId = petObj.CategoryId;
            }
        }
    }
}
