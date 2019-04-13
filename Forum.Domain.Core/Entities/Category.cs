using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Domain.Core.Entities
{
    public class Category
    {
        public Category()
        {
            ChildCategories = new HashSet<Category>();
            Subjects = new HashSet<Subject>();
        }

        [Key]
        public int ID { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [ForeignKey("ParentId")]
        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<Category> ChildCategories { get; private set; }
        public virtual ICollection<Subject> Subjects { get; private set; }
    }
}
