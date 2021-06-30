using System;
using System.Collections.Generic;
using System.Text;

namespace PetsFactory.Data.Repository.IRepository
{
    // unitOfWork method interface
    public interface IUnitOfWork : IDisposable
    {
        public IPetsCategoryRepo PetsCategory { get; }
        public IPetsRepo Pets { get; }
        public INotificationsRepo Notifications { get; }
        public IApplicationUserRepo ApplicationUser { get; }
        public IRequestsRepo Requests { get; }

        void Save();
    }
}
