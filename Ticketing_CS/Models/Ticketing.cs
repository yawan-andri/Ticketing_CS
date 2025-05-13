using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketing_CS.Models
{
    public class Ticketing
    {
        public int Id { get; set; }
        public string Ticket { get; set; } = null!;
        public int LevelId {  get; set; }
        [ForeignKey("LevelId")]
        public ChoiceList? Level { get; set; }
        public int UrgencyId {  get; set; }
        [ForeignKey("UrgencyId")]
        public ChoiceList? Urgency { get; set; }
        public int? StatusId { get; set; }
        [ForeignKey("StatusId")]
        public ChoiceList? Status { get; set; }
        public DateTime DateInput { get; set; }
        public int UserId {  get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
        public bool IsActive { get; set; } = true;  
    }
}
