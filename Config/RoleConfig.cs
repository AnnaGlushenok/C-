using auth.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace auth.Config;
public class RoleConfig : IEntityTypeConfiguration<Role> {
	public void Configure(EntityTypeBuilder<Role> builder) {
		builder.HasMany(b => b.UserRoles)
			.WithOne(b => b.Role)
			.HasForeignKey(b => b.RoleId)
			.IsRequired();
	}
}
