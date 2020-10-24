using RssReader.Models;
using Ninject.Modules;

namespace RssReader.Util
{
    public class NinjectRegistration : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository>().To<SubscriptionRepository>();
        }
    }
}