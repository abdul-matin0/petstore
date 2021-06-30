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
    // implement Repository Pattern for ApplicationUser

    public class ApplicationUserRepo : Repository<ApplicationUser>, IApplicationUserRepo
    {
        private readonly ApplicationDbContext _db;

        public ApplicationUserRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

    }
}
