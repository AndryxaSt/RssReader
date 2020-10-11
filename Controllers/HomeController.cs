using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.Mvc.Filters;
using System.Xml.Serialization;
using System.IO;
using RssReader.Models;
using Microsoft.AspNet.Identity;
using RssReader.Filters;

namespace RssReader.Controllers
{
    public class HomeController : Controller
    {
        static DataBaseContext db;

        private IEnumerable<Subscription> GetAllSubscriptions ()
        {
            string userId = User.Identity.GetUserId();
            var currentUserSubscriptions = db.Users.Where(u => u.Id == userId).Include(s => s.Subscriptions).FirstOrDefault().Subscriptions.ToList<Subscription>();
            return currentUserSubscriptions;
        }

        [AuthFilter]
        public ActionResult Index()
        {
            using (db = new DataBaseContext())
            {
                var currentUserSubscriptions = GetAllSubscriptions();

                return View(new Connection().GetRss(currentUserSubscriptions));
            }
        }

        [AuthFilter]
        public ActionResult News()
        {
            using (db = new DataBaseContext())
            {
                var currentUserSubscriptions = GetAllSubscriptions();

                return View(new Connection().GetRss(currentUserSubscriptions));
            }
        }
    }
}