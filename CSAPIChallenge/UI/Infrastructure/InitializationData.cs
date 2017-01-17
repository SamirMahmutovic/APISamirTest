using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UI.Models;

namespace UI.Infrastructure {

    public interface IDatabaseInit {
        void AddUser(ApplicationDbContext context, UserManager<ApplicationUser> manager, string name);

        void AddCSUser(ApplicationDbContext context, string username, string email, string password); // sm

        
    }
    public class InitializationData {

        public static void Init(ApplicationDbContext context, IDatabaseInit initMethods) {

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            // Add three users all with the same password and email = username
            string userName_David = "David";
            string userName_Admin = "Ben";
            string userName_Moderator = "Phil";
            string userDavid_Email = "David@abc.com";
            string userAdmin_Email = "Ben@abc.com";
            string userModerator_Email = "Phil@abcd.com";
            initMethods.AddUser(context, manager, userName_David);
            initMethods.AddUser(context, manager, userName_Admin);
            initMethods.AddUser(context, manager, userName_Moderator);

            string password1 = "Pa$$w0rd1";
            string password2 = "Pa$$w0rd2";
            string password3 = "Pa$$w0rd3";

            // hash passwords
            initMethods.AddCSUser(context, userName_David, userDavid_Email, PasswordHash.HashPassword(password1));
            initMethods.AddCSUser(context, userName_Moderator, userAdmin_Email, PasswordHash.HashPassword(password2));
            initMethods.AddCSUser(context, userName_Admin, userModerator_Email, PasswordHash.HashPassword(password3));


            context.SaveChanges();        

                 

            
        }
    }
}