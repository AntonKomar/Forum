using Forum.Domain.Core.Entities;
using Forum.Infrastructure.Data.Context;

namespace Forum.Infrastructure.Data.Repositories
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(ForumContext context) : base(context)
        {

        }
    }
}
