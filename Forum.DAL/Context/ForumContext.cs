using Forum.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.DAL.Context
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
