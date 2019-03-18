using Forum.DAL.Context;
using Forum.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.DAL.Repositories
{
    public class MessageRepository : GenericRepository<Message>
    {
        public MessageRepository(ForumContext context) : base(context)
        {

        }
    }
}
