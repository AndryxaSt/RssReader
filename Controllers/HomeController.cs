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


        [AuthFilter]
        public ActionResult Index()
        {
            return View();

        }

        [AuthFilter]
        public ActionResult News()
        {

            using (db = new DataBaseContext())
            {
                string userId = User.Identity.GetUserId();
                var currentUser = db.Users.Where(u => u.Id == userId).Include(s => s.Subscriptions).FirstOrDefault();

                return View(new Connection().GetRss(/*currentUser.Subscriptions.ToList<Subscription>()*/"https://www.liga.net/tech/gadgets/rss.xml"));
            }
        }
    }
}