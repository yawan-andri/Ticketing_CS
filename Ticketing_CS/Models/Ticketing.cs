using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketing_CS.Models
{
    public class Ticketing
    {
        public int Id { get; set; }
        public string Ticket { get; set; }
        public int LevelId {  get; set; }
        [ForeignKey("LevelId")]
        public ChoiceList? Level { get; set; }
        public int IsUrgentId {  get; set; }
        [ForeignKey("IsUrgentId")]
        public ChoiceList? IsUrgent { get; set; }
        public int? StatusId { get; set; }
        [ForeignKey("StatusId")]
        public ChoiceList? Status { get; set; }
        public DateTime DateInput { get; set; }
        public int? UserId {  get; set; }
        [ForeignKey("UserId")]
        public bool IsActive { get; set; }
    }
}
