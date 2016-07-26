using System.ComponentModel.DataAnnotations;

namespace Models.Model
{
    public class GeneralSetting
    {
        [Key]
        public int Id { get; set; }
        public string ContractText { get; set; }
    }
}
