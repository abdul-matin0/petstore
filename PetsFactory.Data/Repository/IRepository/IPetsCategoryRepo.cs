using PetsFactory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetsFactory.Data.Repository.IRepository
{
    // repository pattern for amenities
    public interface IPetsCategoryRepo : IRepository<ApplicationDbContext, PetsCategory>
    {
        public void Update(PetsCategory categoryObj);
    }
}
