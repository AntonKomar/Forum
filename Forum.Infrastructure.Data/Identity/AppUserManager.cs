using Forum.Domain.Core.Entities;
using Forum.Domain.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Infrastructure.Data.Identity
{
    public class AppUserManager : UserManager<ApplicationUser>, IAppIdentity
    {
        public AppUserManager(IUserStore<ApplicationUser> store)
                : base(store)
        {
        }
    }
}
