using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PetsFactory.Models
{
    // class to view requests for pets
    public class Requests
    {
        [Key]
        public int Id { get; set; }
        // user who made request
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        // pets requested for
        public int PetId { get; set; }
        [ForeignKey("PetId")]
        public Pets Pets { get; set; }

        // date requested
        public DateTime DateRequested { get; set; }

    }
}
