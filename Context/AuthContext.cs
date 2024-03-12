using auth.Config;
using auth.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace auth.Context;
public class AuthContext : IdentityDbContext<User, Role, string> {
	public AuthContext(DbContextOptions<AuthContext> options) : base(options) {
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
		base.OnConfiguring(optionsBuilder);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder) {
		base.OnModelCreating(modelBuilder);

		if (Database.IsRelational()) {
			modelBuilder.ApplyConfiguration(new RoleConfig());
			modelBuilder.ApplyConfiguration(new UserConfig());
		}
	}
}
