using System;
using System.Collections.Generic;
using System.Text;

namespace PetsFactory.Data.DbDeployment
{
    // interface to auto deploy database components - migrations
    public interface IDbDeployment
    {
        void Initialize();
    }
}
