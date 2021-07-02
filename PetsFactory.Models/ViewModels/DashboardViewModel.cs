using System;
using System.Collections.Generic;
using System.Text;

namespace PetsFactory.Models.ViewModels
{
    // viewmodel for dashboard
    public class DashboardViewModel
    {
        public IEnumerable<Pets> PetsObj { get; set; }

        public IDictionary<string, int> DaysPetCount { get; set; }
    }
}
