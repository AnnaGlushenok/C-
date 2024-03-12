using auth.Context;
using auth.Model;
using auth.Repos;
using auth.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace auth.Config;
public static class ConfigurationExtensions {
	public static void ConfigureIdentity(this IServiceCollection services) {
		services.AddDbContext<AuthContext>(opt => opt.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=school;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));
		services.AddTransient<IAuthRepository, AuthRepository>();
		services.AddTransient<AuthService>();
		services.AddIdentity<User, Role>()
		.AddEntityFrameworkStores<AuthContext>()
		.AddDefaultTokenProviders();
	}
}
