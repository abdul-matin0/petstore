using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PetsFactory.Models
{
    // pets testimonials
    public class Testimonial
    {
        public int Id { get; set; }

        [Required]
        public int PetId { get; set; }
        [ForeignKey("PetId")]
        public Pets Pets { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        [MaxLength(80)]
        public string CommentMessage { get; set; }
    }
}
