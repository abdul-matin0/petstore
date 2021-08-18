using PetsFactory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetsFactory.Data.Repository.IRepository
{
    // Testimonial Repository Pattern

    public interface ITestimonialRepo : IRepository<ApplicationDbContext, Testimonial>
    {
        public void Update(Testimonial obj);
    }
}
