using PetsFactory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetsFactory.Data.Repository.IRepository
{
    // Notifications Repository Pattern

    public interface INotificationsRepo : IRepository<ApplicationDbContext, Notifications>
    {
        public void Update(Notifications obj);
    }
}
