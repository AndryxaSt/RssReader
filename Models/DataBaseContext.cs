using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using RssReader.Models;

namespace RssReader.Models
{
    public class DataBaseContext : IdentityDbContext<User>
    {
        public DataBaseContext() : base("DataBaseContext")
        {

        }

        public static DataBaseContext Create()
        {
            return new DataBaseContext();
        }

        public DbSet<Subscription> Subscriptions { get; set; }



    }
}