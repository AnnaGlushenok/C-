using auth.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace auth.Config;
public class UserConfig : IEntityTypeConfiguration<User> {
	public void Configure(EntityTypeBuilder<User> builder) {
		builder.Property(u => u.UserName);
		builder.Property(u => u.Password);
		builder.HasMany(e => e.Roles)
			.WithOne(e => e.User)
			.HasForeignKey(e => e.UserId)
			.IsRequired();
	}
}
