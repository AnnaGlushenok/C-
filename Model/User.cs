using Microsoft.AspNetCore.Identity;

namespace auth.Model;
public class User : IdentityUser<string> {
	public string Surname { get; set; }
	public string Name { get; set; }
	public string Patronymic { get; set; }
	//public string Login { get; set; }
	//public string UserName { get; set; }

	public virtual ICollection<UserRole> Roles { get; set; }
}
