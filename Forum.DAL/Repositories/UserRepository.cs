using Forum.DAL.Context;
using Forum.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(ForumContext context) : base(context)
        {

        }
    }
}
