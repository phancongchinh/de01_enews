using De01_Enews.Models.Entities;
using De01_Enews.Repository.Configurations;
using Microsoft.EntityFrameworkCore;

namespace De01_Enews.Repository;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<Image> Images { get; set; }

    public static AppDbContext Init()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        var builder = new DbContextOptionsBuilder<AppDbContext>();
        builder.UseSqlServer(configuration.GetConnectionString("MSSqlServer"));
        var appDbContext = new AppDbContext(builder.Options);

        SeedRoles(appDbContext);

        return appDbContext;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserConfiguration());

        modelBuilder.Entity<Role>().HasData(
            new Role { Id = 1, Name = "Administrator" },
            new Role { Id = 2, Name = "Moderator" },
            new Role { Id = 3, Name = "Editor" },
            new Role { Id = 4, Name = "Reader" }
        );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("MSSqlServer"));
    }

    private static void SeedRoles(AppDbContext dbContext)
    {
        Console.WriteLine("Seeding...");
    }
}