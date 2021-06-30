using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PetsFactory.Models
{
    // model class for pets
    public class Pets
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string PetImage { get; set; }
        public string Details { get; set; }

        // foreign key
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public PetsCategory PetCategory { get; set; }
    }
}
