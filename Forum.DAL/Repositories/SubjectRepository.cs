using Forum.DAL.Context;
using Forum.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.DAL.Repositories
{
    public class SubjectRepository : GenericRepository<Subject>
    {
        public SubjectRepository(ForumContext context) : base(context)
        {

        }
    }
}
