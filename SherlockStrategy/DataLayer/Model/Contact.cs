using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
    }
}
