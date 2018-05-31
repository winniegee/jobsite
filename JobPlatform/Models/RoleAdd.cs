using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPlatform.Models
{
    public static class RoleAdd
    {
        public static void CreateRolesandUsers(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User     
            if (!roleManager.RoleExists("AdminRole"))
            {

                // first we create Admin rool    
                var role = new IdentityRole();
                role.Name = "AdminRole";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                   

                var user = new ApplicationUser();
                user.UserName = "winifred";
                user.Email = "winifred@gmail.com";

                string password = "password";

                var chkUser = UserManager.Create(user, password);

                //Add default User to Role Admin    
                if (chkUser.Succeeded)
                {
                    UserManager.AddToRoleAsync(user.Id, "AdminRole").Wait();
                    context.SaveChanges();
                }
            }
        }

    }
}