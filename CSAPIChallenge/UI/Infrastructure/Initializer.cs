using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UI.Infrastructure;

namespace UI.Models {
    public class Initializer : DropCreateDatabaseAlways<ApplicationDbContext>, IDatabaseInit {
        //public class Initializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext> {

        protected override void Seed(ApplicationDbContext context) {
            InitializationData.Init(context, this);
        }

        public void AddCSUser(ApplicationDbContext context, string username, string email, string password)
        {
            context.CSUsers.Add(
                new CSUser
                {
                    UserName = username,
                    Email = email,
                    Password = password

                });
        }

       
        public void AddUser(ApplicationDbContext context, UserManager<ApplicationUser> manager, string userName) {
            var user = new ApplicationUser() {
                UserName = userName,
                Email = userName,
            };
            manager.Create(user, "Pa$$w0rd");
            context.SaveChanges();
        }
       
        

        
    }
}
