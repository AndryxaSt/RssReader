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
        IRepository repository;

        public SubscriptionController()
        {

        }
        public SubscriptionController(IRepository rep)
        {
            //repository = rep;
            repository = new SubscriptionRepository();
        }

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
            var currentUserSubs = repository.ListSubscriptions(User.Identity.GetUserId());
            return View(currentUserSubs);
        }

        [AuthFilter]
        public PartialViewResult Add()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Add(Subscription newSubsciption)
        {
            repository.AddSubscription(newSubsciption, User.Identity.GetUserId());
            return RedirectToAction("List", "Subscription");
        }

        public ActionResult Delete(Subscription removeSubscription)
        {
            repository.DeleteSubscription(removeSubscription, User.Identity.GetUserId());
            return RedirectToAction("List", "Subscription");

        }

    }
}