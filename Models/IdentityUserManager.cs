using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace RssReader.Models
{
    public class IdentityUserManager : UserManager<User>
    {
        public IdentityUserManager(IUserStore<User> store)
            : base(store)
        { }

        public static IdentityUserManager Create(IdentityFactoryOptions<IdentityUserManager> options,
                                            IOwinContext context)
        {
            DataBaseContext db = context.Get<DataBaseContext>();
            IdentityUserManager manager = new IdentityUserManager(new UserStore<User>(db));
            return manager;
        }
    }
}