using Microsoft.EntityFrameworkCore;
namespace PIApi.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Car> Cars { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Mark> Marks { get; set; }
    public DbSet<Model> Models { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Konfiguracja relacji
        modelBuilder.Entity<Model>()
            .HasOne(m => m.Mark)
            .WithMany()
            .HasForeignKey(m => m.MarkaId);

        modelBuilder.Entity<Car>()
            .HasOne(c => c.Model)
            .WithMany()
            .HasForeignKey(c => c.ModelId);

        modelBuilder.Entity<Contract>()
            .HasOne(k => k.Car)
            .WithMany()
            .HasForeignKey(k => k.CarId);
    }
    public static void EnsureSeedData(ApplicationDbContext context)
    {
        if (!context.Marks.Any())
        {
            context.Marks.AddRange(
                new Mark { Id = 1, Name = "Toyota" },
                new Mark { Id = 2, Name = "BMW" }
            );
            context.SaveChanges();
        }

        if (!context.Models.Any())
        {
            context.Models.AddRange(
                new Model { Id = 1, Name = "Corolla", MarkaId = 1 },
                new Model { Id = 2, Name = "Camry", MarkaId = 1 },
                new Model { Id = 3, Name = "X5", MarkaId = 2 }
            );
            context.SaveChanges();
        }

        if (!context.Cars.Any())
        {
            context.Cars.AddRange(
                new Car { Id = 1, LicensePlate = "ABC123", ModelId = 1, Year = 2020 },
                new Car { Id = 2, LicensePlate = "XYZ789", ModelId = 2, Year = 2018 },
                new Car { Id = 3, LicensePlate = "LMN456", ModelId = 3, Year = 2022 }
            );
            context.SaveChanges();
        }

        if (!context.Contracts.Any())
        {
            context.Contracts.AddRange(
                new Contract { Id = 1, CarId = 1, StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(1), Price = 1200.00m },
                new Contract { Id = 2, CarId = 2, StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(2), Price = 2200.00m }
            );
            context.SaveChanges();
        }
    }
}
