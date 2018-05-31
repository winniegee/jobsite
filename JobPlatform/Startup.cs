using System;
using System.Collections.Generic;
using System.Linq;
using JobPlatform.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(JobPlatform.Startup))]

namespace JobPlatform
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
            //app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
           // ConfigureOAuthTokenGeneration(app);
        }
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin rool   
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
                //Here we create an Admin user who will maintain the website                  

                var adminUser1 = new ApplicationUser();
            adminUser1.UserName = "ofure@gmail.com";
            adminUser1.Email = "ofure@gmail.com";
            adminUser1.Career = "Programmer";
            adminUser1.Date = DateTime.Now;
            adminUser1.State = "Lagos";


            string pwd = "Gwendolen1";

                var chkUserr = UserManager.Create(adminUser1, pwd);

                if (chkUserr.Succeeded)
                {
                    var adminResult = UserManager.AddToRole(adminUser1.Id, "Admin");
                }
             

            // creating Creating Manager role    
            if (!roleManager.RoleExists("User"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "User";
                roleManager.Create(role);

            }
        }


    }
}
