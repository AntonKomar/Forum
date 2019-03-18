using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.DAL.Models
{
    public class Message
    {
        public int ID { get; set; }
        public Subject SubjectID { get; set; }
        public User UserID { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

    }
}
