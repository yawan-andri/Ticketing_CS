namespace Ticketing_CS.Models
{
    public class ChoiceList
    {
        public int Id { get; set; }
        public string Choice { get; set; } = null!;
        public string Option { get; set; } = null!;
        public bool IsActive { get; set; } = true;
    }
}
