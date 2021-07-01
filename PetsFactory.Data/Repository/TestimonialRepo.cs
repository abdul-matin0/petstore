using PetsFactory.Data.Repository.IRepository;
using PetsFactory.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetsFactory.Data.Repository
{
    // implement Repository Pattern for Testimonial

    public class TestimonialRepo : Repository<Testimonial>, ITestimonialRepo
    {
        private readonly ApplicationDbContext _db;

        public TestimonialRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        // update testimonial properties database
        public void Update(Testimonial obj)
        {
            _db.Update(obj);
        }
    }
}
