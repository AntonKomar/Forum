using Forum.Domain.Interfaces;
using Forum.Infrastructure.Business.Interfaces;
using Forum.Infrastructure.Business.Services;
using Forum.Infrastructure.Data;
using Forum.Infrastructure.Data.Context;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Framework
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>().WithConstructorArgument("uow", new UnitOfWork());
        }
    }
}
