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

        void Save();
    }
}
