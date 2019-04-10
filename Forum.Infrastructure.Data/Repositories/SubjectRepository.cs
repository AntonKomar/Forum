using Forum.Domain.Core.Entities;
using Forum.Infrastructure.Data.Context;

namespace Forum.Infrastructure.Data.Repositories
{
    public class SubjectRepository : GenericRepository<Subject>
    {
        public SubjectRepository(ForumContext context) : base(context)
        {

        }
    }
}
