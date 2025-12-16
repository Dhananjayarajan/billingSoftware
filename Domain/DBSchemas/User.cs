
using Domain.enums;

namespace Domain.DBSchemas;

public class User
{
	public string UserId { get; set; } = Guid.NewGuid().ToString();
	public required string Name { get; set; }
	public required string Company { get; set; }
	public required string Email { get; set; }
	public required byte[] PasswordHash { get; set; }
	public required byte[] PasswordSalt { get; set; }
	public Plans PlanType { get; set; } = Plans.Basic;
	public ICollection<Items>? Items { get; set; }
	public DateTime CreatedAt { get; set; } = DateTime.Now;
	public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
