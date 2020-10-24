using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RssReader.Models
{
    public class SubscriptionRepository : IDisposable, IRepository
    {
        private DataBaseContext db;

        public SubscriptionRepository()
        {
            db = new DataBaseContext();
        }

        public IEnumerable<Subscription> ListSubscriptions(string userId)
        {
            var currentUser = db.Users.Where(u => u.Id == userId).Include(s => s.Subscriptions).FirstOrDefault();
            return currentUser.Subscriptions;
        }

        public void AddSubscription(Subscription subs, string userId)
        {
            User currentUser = db.Users.FirstOrDefault(x => x.Id == userId);
            subs.Users.Add(currentUser);
            currentUser.Subscriptions.Add(subs);
            db.SaveChanges();
        }

        public void DeleteSubscription(Subscription subs, string userId)
        {
            var currentUser = db.Users.Where(u => u.Id == userId).Include(s => s.Subscriptions).FirstOrDefault();
            currentUser.Subscriptions.Remove(subs);
            db.Subscriptions.Find(subs.SubscriptionId).Users.Remove(currentUser);
            db.SaveChanges();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}