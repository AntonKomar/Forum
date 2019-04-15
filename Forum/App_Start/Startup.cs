using Forum.Infrastructure.Business.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.App_Start
{
    public class Startup
    {
        IUserService userService;
        public void Configuration(IAppBuilder app)
        {
            //Error 
            //app.CreatePerOwinContext<IUserService>(userService); 
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Login"),
            });
        }
    }
}