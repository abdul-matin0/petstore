using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetsFactory.Models.ViewModels
{
    // view model class for Pets
    public class PetsViewModel
    {
        // pets category dropdown list
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        // pets obj
        public Pets PetsObj { get; set; }
    }
}
