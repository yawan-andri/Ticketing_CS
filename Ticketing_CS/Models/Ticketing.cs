using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketing_CS.Models
{
    public class Ticketing
    {
        public int Id { get; set; }
        public string Ticket { get; set; }
        public int LevelId {  get; set; }
        [ForeignKey("LevelId")]
        public int IsUrgentId {  get; set; }
        [ForeignKey("IsUrgentId")]
        public int? StatusId { get; set; }
        [ForeignKey("StatusId")]
        public DateTime DateInput { get; set; }
        public int UserInput {  get; set; }
        [ForeignKey("UserInput")]
        public bool IsActive { get; set; }
        public ChoiceList? ChoiceList { get; set; }
    }
}
