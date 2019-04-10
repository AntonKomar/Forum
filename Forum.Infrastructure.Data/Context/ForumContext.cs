using Forum.Domain.Core.Entities;
using System.Data.Entity;

namespace Forum.Infrastructure.Data.Context
{
    public class ForumContext : DbContext
    {

        public ForumContext()
            : base("forum")
        { }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
