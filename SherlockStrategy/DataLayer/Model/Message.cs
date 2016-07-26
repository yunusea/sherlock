using System;
using System.ComponentModel.DataAnnotations;

namespace Models.Model
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public int SendUser { get; set; }
        public int ReceiverUser { get; set; }
        public string Subject { get; set; }
        public string MessageText { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
