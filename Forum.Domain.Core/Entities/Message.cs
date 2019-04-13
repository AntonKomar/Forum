using System;

namespace Forum.Domain.Core.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public Subject Subject { get; set; }
        public ClientProfile User { get; set; }
    }
}
