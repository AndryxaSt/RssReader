using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using RssReader.Models;

namespace RssReader.Models
{
    public class User : IdentityUser
    {
        public DateTime RegistrationDate { get; set; }
        public List<Subscription> Subscriptions { get; set; }
        public User()
        {
            RegistrationDate = DateTime.Now;
            Subscriptions = new List<Subscription>();
        }

    }
}