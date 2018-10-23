namespace RealtorCMS.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RealtorCMS.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RealtorCMS.Models.ApplicationDbContext context)
        {


            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                roleManager.Create(new IdentityRole { Name = "admin" });

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new ApplicationUserManager(userStore);

                var user = new ApplicationUser { UserName = "admin@abv.bg", Name = "admin", Email = "admin@abv.bg", Phone = "666", };
                userManager.Create(user, "password");

                var usr = context.Users.Where(x => x.Name == "Admin").FirstOrDefault();
                var role = context.Roles.SingleOrDefault(m => m.Name == "admin");
                userManager.AddToRole(usr.Id, "admin");
            }

        }
    }
}
