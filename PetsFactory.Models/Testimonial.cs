using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PetsFactory.Models
{
    // pets testimonials
    public class Testimonial
    {
        public int Id { get; set; }

        public int PetId { get; set; }
        [ForeignKey("PetId")]
        public Pets Pets { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        public string CommentMessage { get; set; }
    }
}
