using Microsoft.Owin;
using Owin;
using RssReader.Models;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(RssReader.Startup))]
namespace RssReader
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // настраиваем контекст и менеджер
            app.CreatePerOwinContext<DataBaseContext>(DataBaseContext.Create);
            app.CreatePerOwinContext<IdentityUserManager>(IdentityUserManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }
    }
}