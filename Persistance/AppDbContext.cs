using Domain.DBSchemas;
using Microsoft.EntityFrameworkCore;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
	public DbSet<User> Users { get; set; }
	public DbSet<Items> Items { get; set; }
	public DbSet<OrderItems> OrderItems { get; set; }
	public DbSet<Order> Orders { get; set; }
}
