using PetsFactory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetsFactory.Data.Repository.IRepository
{
    // requests Repository Pattern

    public interface IRequestsRepo : IRepository<Requests>
    {
        public void Update(Requests obj);
    }
}
