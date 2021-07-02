using System;
using System.Collections.Generic;
using System.Text;

namespace PetsFactory.Models.ViewModels
{
    // view model to display pets details, notifications, testimonials, no of users, recent notification
    public class AdminViewModel
    {
        public int PetsCount { get; set; }
        public int NotificationsCount { get; set; }
        public IEnumerable<Testimonial> TestimonialsList { get; set; }
        public int UsersCount { get; set; }
        public IDictionary<string, int> DaysPetCount { get; set; }
    }
}
