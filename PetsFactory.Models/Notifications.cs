using System;
using System.Collections.Generic;
using System.Text;

namespace PetsFactory.Models
{
    // item notifications
    public class Notifications
    {
        public int Id { get; set; }

        public string Title { get; set; }
        // roles to receive notification
        public string Role { get; set; }
        public string Message { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
