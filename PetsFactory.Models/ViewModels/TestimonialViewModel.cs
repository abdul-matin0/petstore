using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetsFactory.Models.ViewModels
{
    public class TestimonialViewModel
    {
        public Testimonial TestimonialObj { get; set; }
        public IEnumerable<SelectListItem> PetSelectList { get; set; }

    }
}
