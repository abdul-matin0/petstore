using PetsFactory.Data.Repository.IRepository;
using PetsFactory.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetsFactory.Data.Repository
{
    // implement Repository Pattern for Notificaitons

    public class NotificationsRepo : Repository<Notifications>, INotificationsRepo
    {
        private readonly ApplicationDbContext _db;

        public NotificationsRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        // update notifications properties database
        public void Update(Notifications notifications)
        {
            _db.Update(notifications);
        }
    }
}
