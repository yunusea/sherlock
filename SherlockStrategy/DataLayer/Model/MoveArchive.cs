using System.ComponentModel.DataAnnotations;

namespace Models.Model
{
    public class MoveArchive
    {
        [Key]
        public int Id { get; set; }
        public int EncounterId { get; set; }
        public string MoveCellId { get; set; }
    }
}
