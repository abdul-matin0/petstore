using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetsFactory.Models
{
    /**
     * Model class for PetsCategory properties
     */
    public class PetsCategory
    {
        // primary key
        [Key]
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}
