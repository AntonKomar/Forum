using Forum.Domain.Core.Entities;
using Forum.Infrastructure.Data.Context;

namespace Forum.Infrastructure.Data.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(ForumContext context) : base(context)
        {

        }
    }
}
