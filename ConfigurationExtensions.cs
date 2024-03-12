using DAL.Models;
using DAL.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL;
public static class ConfigurationExtensions {
	public static void ConfigureDAL(this IServiceCollection services) {
		services.AddDbContext<DatabaseContext>(opt => opt.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=school;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));
		services.AddScoped<IRepository<Student>, StudentRepository>();
		services.AddScoped<IRepository<Subject>, SubjectRepository>();
		services.AddScoped<IRepository<Mark>, MarkRepository>();
	}
}
