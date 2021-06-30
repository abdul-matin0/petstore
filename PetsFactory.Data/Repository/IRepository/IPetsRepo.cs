using PetsFactory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetsFactory.Data.Repository.IRepository
{
    // Pets Repository Pattern

    public interface IPetsRepo : IRepository<Pets>
    {
        public void Update(Pets petsObj);
    }
}
