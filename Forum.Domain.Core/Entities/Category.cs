using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Domain.Core.Entities
{
    public class Category
    {
        public int ID { get; set; }
        public Category ParentID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
