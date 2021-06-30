using PetsFactory.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetsFactory.Data.Repository
{
    // unit of work for repository data
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;

            
            PetsCategory = new PetsCategoryRepo(_db);
            Pets = new PetsRepo(_db);
            Notifications = new NotificationsRepo(_db);
            ApplicationUser = new ApplicationUserRepo(_db);
            Requests = new RequestsRepo(_db);
        }

        public IPetsCategoryRepo PetsCategory { get; private set; }
        public IPetsRepo Pets { get; private set; }
        public INotificationsRepo Notifications { get; private set; }
        public IApplicationUserRepo ApplicationUser { get; private set; }
        public IRequestsRepo Requests { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
