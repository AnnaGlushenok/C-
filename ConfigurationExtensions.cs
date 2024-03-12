using BLL.Profiles;
using BLL.Services;
using DAL;
using Microsoft.Extensions.DependencyInjection;

namespace BLL;
public static class ConfigurationExtensions {
	public static void ConfigureBLL(this IServiceCollection services) {		
		services.ConfigureDAL();
		services.AddAutoMapper(typeof(StudentProfile));
		services.AddAutoMapper(typeof(SubjectProfile));
		services.AddAutoMapper(typeof(MarkProfile));
		services.AddTransient<StudentService>();
		services.AddTransient<SubjectService>();
		services.AddTransient<MarkService>();
	}
}
