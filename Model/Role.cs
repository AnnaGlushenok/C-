using Microsoft.AspNetCore.Identity;

namespace auth.Model;
public class Role : IdentityRole<string> {
	public int Id { get; set; }
	public virtual ICollection<UserRole> UserRoles { get; set; }
}
