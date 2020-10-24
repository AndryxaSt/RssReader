using System.Collections.Generic;

namespace RssReader.Models

{
    public interface IRepository
    {
        void AddSubscription(Subscription subs, string userId);
        void DeleteSubscription(Subscription subs, string userId);
        IEnumerable<Subscription> ListSubscriptions(string userId);
    }
}