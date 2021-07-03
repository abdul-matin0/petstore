using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetsFactory.Models;
using PetsFactory.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetsFactory.Data.DbDeployment
{
    // automatically execute migrations to database on first deployment execution
    public class DbDeployment : IDbDeployment
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbDeployment(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    // migrate to db automatically
                    _db.Database.Migrate();
                }
            }
            catch
            {

            }

            if (_db.Roles.Any(r => r.Name == Utilities.AdminUser)) return;

            // create all roles
            _roleManager.CreateAsync(new IdentityRole(Utilities.AdminUser)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(Utilities.CustomerUser)).GetAwaiter().GetResult();

            // create admin user
            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "tu050@live.mdx.ac.uk",
                Email = "tu050@live.mdx.ac.uk",
                EmailConfirmed = true,
                Name = "Admin Tracy"
            }, "Tracy2002$").GetAwaiter().GetResult();

            ApplicationUser user = _db.ApplicationUser.Where(u => u.Email == "tu050@live.mdx.ac.uk").FirstOrDefault();

            // set user to admin role
            _userManager.AddToRoleAsync(user, Utilities.AdminUser).GetAwaiter().GetResult();
        }
    }
}
