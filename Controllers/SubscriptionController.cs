using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using RssReader.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using RssReader.Filters;

namespace RssReader.Controllers
{
    public class SubscriptionController : Controller
    {
        static DataBaseContext db;
        private IdentityUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IdentityUserManager>();
            }
        }

        [AuthFilter]
        public ActionResult List()
        {
            using (db = new DataBaseContext())
            {
                string userId = User.Identity.GetUserId();
                var currentUser = db.Users.Where(u => u.Id == userId).Include(s => s.Subscriptions).FirstOrDefault();

                return View(currentUser);
            }


        }

        [AuthFilter]
        public PartialViewResult Add()
        {

            return PartialView();

        }

        [HttpPost]
        public ActionResult Add(Subscription newSubsciption)
        {
            using (db = new DataBaseContext())
            {
                string userId = User.Identity.GetUserId();
                User currentUser = db.Users.FirstOrDefault(x => x.Id == userId);
                newSubsciption.Users.Add(currentUser);
                currentUser.Subscriptions.Add(newSubsciption);
                db.SaveChanges();
            }
            return RedirectToAction("List", "Subscription");
        }

        public ActionResult Delete(Subscription removeSubscription)
        {
            using (db = new DataBaseContext())
            {
                string userId = User.Identity.GetUserId();
                var currentUser = db.Users.Where(u => u.Id == userId).Include(s => s.Subscriptions).FirstOrDefault();
                currentUser.Subscriptions.Remove(removeSubscription);
                db.Subscriptions.Find(removeSubscription.SubscriptionId).Users.Remove(currentUser);
                db.SaveChanges();

                return RedirectToAction("List", "Subscription");
            }


        }

    }
}