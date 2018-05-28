namespace JobPlatform.Migrations
{
    using JobPlatform.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<JobPlatform.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(JobPlatform.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var approle = Startup.RoleManagerFactory.Invoke();
            var userMgr = Startup.UserManagerFactory.Invoke();
            string Name = "JobCreateAdmin";
            string email = "admin@gmail.com";
            string password = "winifred";
            string role = "Admin";
            var appUser = new ApplicationUser()
            {
                UserName = Name,
                Email = email
            };
            var result = userMgr.Create(appUser, password);
            if (!approle.RoleExists(role))
            {
                var irole = new IdentityRole()
                {
                    Name = role
                };
                approle.Create<IdentityRole, string>(irole);
            }
            if (!userMgr.IsInRole<ApplicationUser, string>(appUser.Id, role))
            {
                userMgr.AddToRole<ApplicationUser, string>(appUser.Id, role);
            }
        }
    }
}
