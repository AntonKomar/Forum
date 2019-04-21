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

        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ClientProfile> ClientProfiles { get; set; }

        private void FixEfProviderServicesProblem()
        {
            // The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
            // for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
            // Make sure the provider assembly is available to the running application. 
            // See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}
