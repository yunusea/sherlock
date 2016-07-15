using System.ComponentModel.DataAnnotations;


namespace Models.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Rol { get; set; }
        public bool Status { get; set; }
    }
}
