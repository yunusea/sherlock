using System.ComponentModel.DataAnnotations;

namespace Models.Model
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        public string GameName { get; set; }
        public string TempPath { get; set; }
    }
}
