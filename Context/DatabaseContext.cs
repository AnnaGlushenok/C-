using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL;
public class DatabaseContext : DbContext {
	public DatabaseContext(DbContextOptions<DatabaseContext> options)
		: base(options) {
	}

	//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
	//	optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=school;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

	public DbSet<Student> Students { get; set; }
	public DbSet<Subject> Subjects { get; set; }
	public DbSet<Mark> Marks { get; set; }
}
