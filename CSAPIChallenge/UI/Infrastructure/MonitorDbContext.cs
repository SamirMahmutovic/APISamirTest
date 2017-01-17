using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UI.Models;

namespace UI.Infrastructure
{
    public class MonitorDbContext : DbContext
    {
        public MonitorDbContext()
            : base(ApplicationDbContext.CSApiTestForumConnectionName)
        { }

        public DbSet<Diagnostic> Diagnostics { get; set; }
    }

}