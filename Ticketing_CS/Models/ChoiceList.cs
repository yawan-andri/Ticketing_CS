namespace Ticketing_CS.Models
{
    public class ChoiceList
    {
        public int Id { get; set; }
        public string Choice { get; set; }
        public string Option { get; set; }
        public bool IsActive { get; set; }
        public List<Ticketing>? Ticketings { get; set; }
    }
}
