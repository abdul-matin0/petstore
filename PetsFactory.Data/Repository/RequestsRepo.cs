using PetsFactory.Data.Repository.IRepository;
using PetsFactory.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetsFactory.Data.Repository
{
    // implement Repository Pattern for Requests

    public class RequestsRepo : Repository<ApplicationDbContext, Requests>, IRequestsRepo
    {
        private readonly ApplicationDbContext _db;

        public RequestsRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        // update requests properties database
        public void Update(Requests requests)
        {
            _db.Update(requests);
        }
    }
}
