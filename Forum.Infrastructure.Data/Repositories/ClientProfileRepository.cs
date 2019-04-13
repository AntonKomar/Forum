using Forum.Domain.Core.Entities;
using Forum.Infrastructure.Data.Context;

namespace Forum.Infrastructure.Data.Repositories
{
    public class ClientProfileRepository : GenericRepository<ClientProfile>
    {
        public ClientProfileRepository(ForumContext context) : base(context)
        {

        }
    }
}
