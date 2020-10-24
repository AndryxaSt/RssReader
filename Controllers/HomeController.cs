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
using Ninject;

namespace RssReader.Controllers
{
    public class HomeController : Controller
    {
        IRepository repository;

        public HomeController()
        {
        }
        public HomeController(IRepository rep)
        {
            repository = rep;
        }

        [AuthFilter]
        public ActionResult Index()
        {
            //repository = new SubscriptionRepository();
            var currentUserSubscriptions = repository.ListSubscriptions(User.Identity.GetUserId());
            return View(new Connection().GetRss(currentUserSubscriptions));

        }

        [AuthFilter]
        public ActionResult News()
        {
            var currentUserSubscriptions = repository.ListSubscriptions(User.Identity.GetUserId());
            return View(new Connection().GetRss(currentUserSubscriptions));

        }
    }
}