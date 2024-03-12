using auth.Model;

namespace auth.DTO {
	internal class UserDTO {
		public string Surname { get; set; }
		public string Name { get; set; }
		public string Patronymic { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }

		public virtual ICollection<UserRole> Roles { get; set; }
	}
}
