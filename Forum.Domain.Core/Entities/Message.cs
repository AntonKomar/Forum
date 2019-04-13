using System;

namespace Forum.Domain.Core.Entities
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
