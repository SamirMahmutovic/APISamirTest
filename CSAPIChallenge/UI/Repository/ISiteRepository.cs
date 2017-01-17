using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public interface ISiteRepository : IDisposable
    {
        // Get All CS Users(s)
        IQueryable<CSUser> GetAllCSUsers();

        CSUser GetCSUserByID(int CSUserID);
       

        // Get User(s)
        ApplicationUser GetUserByID(string UserID);


        void AddCSUser(CSUser csUser);
        void DeleteCSUser(CSUser csUser);


    }
}
