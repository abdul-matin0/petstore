using PetsFactory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetsFactory.Data.Repository.IRepository
{
    // Applicaiton Repository Pattern

    public interface IApplicationUserRepo : IRepository<ApplicationDbContext, ApplicationUser>
    {
    }
}
