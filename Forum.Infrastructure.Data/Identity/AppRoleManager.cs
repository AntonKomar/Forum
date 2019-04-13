using Forum.Domain.Core.Entities;
using Forum.Domain.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Forum.Infrastructure.Data.Identity
{
    public class AppRoleManager : RoleManager<ApplicationRole> , IAppIdentity
    {
        public AppRoleManager(RoleStore<ApplicationRole> store)
                    : base(store)
        { }
    }
}
