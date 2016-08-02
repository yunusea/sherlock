using System.ComponentModel.DataAnnotations;

namespace Models.Model
{
    public class MoveArchive
    {
        [Key]
        public int Id { get; set; }
        public int EncounterId { get; set; }
        public int MoveCellx { get; set; }
        public int MoveCelly { get; set; }
        public string CellValue { get; set; }
    }
}
