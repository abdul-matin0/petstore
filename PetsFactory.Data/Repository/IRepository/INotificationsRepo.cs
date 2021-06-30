using PetsFactory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetsFactory.Data.Repository.IRepository
{
    // Pets Repository Pattern

    public interface INotificationsRepo : IRepository<Notifications>
    {
        public void Update(Notifications obj);
    }
}
