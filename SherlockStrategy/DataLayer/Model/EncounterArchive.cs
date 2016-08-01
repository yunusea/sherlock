using System;
using System.ComponentModel.DataAnnotations;

namespace Models.Model
{
    public class EncounterArchive
    {
        [Key]
        public int Id { get; set; }
        public int GameId { get; set; }
        public DateTime StartDate { get; set; }
        public int MoveCount { get; set; }
        public int EncounterType { get; set; }
        public int PlayerId { get; set; }
    }
}
