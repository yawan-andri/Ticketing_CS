namespace Ticketing_CS.Models
{
	public class User
	{
		public int Id { get; set; }
		public string UserName { get; set; } = null!;
		public string Password { get; set; } = null!;
		public bool IsActive { get; set; } = true;
	}
}
