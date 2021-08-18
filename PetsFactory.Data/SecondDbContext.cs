using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PetsFactory.Data.Repository.IRepository;
using PetsFactory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetsFactory.Data
{
    // https://stackoverflow.com/questions/54490808/configure-connection-string-from-controller-asp-net-core-mvc-2-1
    public class DbConnectionInfo
    {

        public string SecondConnection { get; set; }

        private readonly ApplicationDbContext _db;

        // Example injecting IHttpContextAccessor
        // On creating this class DI will inject 
        // the HttpContextAccessor as parameter
        public DbConnectionInfo(IHttpContextAccessor httpContextAccessor, ApplicationDbContext db)
        {
            _db = db;

            // Access the current request
            var request = httpContextAccessor.HttpContext.Request;

            // Access the current user (if authenticated)
            var user = httpContextAccessor.HttpContext.User;

            // Now you could get a value from a header, claim,
            // querystring or path and use that to set the value:

            if (user == null)
            {
                SecondConnection = @"Server=(localdb)\mssqllocaldb;Database=PetDB;Trusted_Connection=True;MultipleActiveResultSets=true";
            }
            else
            {
                ApplicationUser applicationUser = new ApplicationUser();

                foreach(var item in user.Claims)
                {
                    // loop once
                    applicationUser = db.ApplicationUser.FirstOrDefault(u => u.Id == item.Value);
                    break;
                }

                SecondConnection = applicationUser.ConnectionString;
            }
        }

    }

    public class SecondDbContext : DbContext
    {
        private readonly string _connectionString;

        public SecondDbContext(DbContextOptions<SecondDbContext> options)
            : base(options)
        {
        }

        public SecondDbContext(DbConnectionInfo dbConnectionInfo)
        {
            _connectionString = dbConnectionInfo.SecondConnection;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        // define database objects
        public DbSet<PetsCategory> PetsCategory { get; set; }
        
    }
}
