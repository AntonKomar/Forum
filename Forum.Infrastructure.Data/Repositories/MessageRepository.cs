using Forum.Domain.Core.Entities;
using Forum.Infrastructure.Data.Context;

namespace Forum.Infrastructure.Data.Repositories
{
    public class MessageRepository : GenericRepository<Message>
    {
        public MessageRepository(ForumContext context) : base(context)
        {

        }
    }
}
