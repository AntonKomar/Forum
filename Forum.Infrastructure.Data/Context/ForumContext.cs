using Forum.Domain.Core.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Forum.Infrastructure.Data.Context
{
    public class ForumContext : IdentityDbContext<ApplicationUser>
    {
        public ForumContext()
            : base("forum")
        { }
        
        public static ForumContext Create()
        {
            return new ForumContext();
        }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ClientProfile> ClientProfiles { get; set; }
        
    }
}
