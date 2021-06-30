using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetsFactory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetsFactory.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<PetsCategory> PetsCategory { get; set; }
        public DbSet<Pets> Pets { get; set; }
        public DbSet<Notifications> Notifications { get; set; }
    }
}
