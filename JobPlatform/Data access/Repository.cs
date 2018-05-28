using JobPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPlatform
{
    public interface IUserRepository
    {
        IEnumerable<ApplicationUser> GetUsers();

   }

    

    public class UserRepo : IUserRepository
    {
        private ApplicationDbContext context;

        public UserRepo()
        {
            context = new ApplicationDbContext();
        }
        public IEnumerable<ApplicationUser> GetUsers()
        {
           
                return context.Users.ToList();
         
        }
    }
}