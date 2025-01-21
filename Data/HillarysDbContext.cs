using Microsoft.EntityFrameworkCore;

public class HillarysDbContext : DbContext
{
    public HillarysDbContext(DbContextOptions<HillarysDbContext> options) : base(options) { }

    public DbSet<Stylist> Stylists { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<AppointmentService> AppointmentServices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure relationships
        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Customer)
            .WithMany(c => c.Appointments)
            .HasForeignKey(a => a.CustomerId);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Stylist)
            .WithMany(s => s.Appointments)
            .HasForeignKey(a => a.StylistId);

        modelBuilder.Entity<AppointmentService>()
            .HasOne(aps => aps.Appointment)
            .WithMany(a => a.AppointmentServices)
            .HasForeignKey(aps => aps.AppointmentId);

        modelBuilder.Entity<AppointmentService>()
            .HasOne(aps => aps.Service)
            .WithMany(s => s.AppointmentServices)
            .HasForeignKey(aps => aps.ServiceId);

        // Seed Data
        modelBuilder.Entity<Stylist>().HasData(
            new Stylist { 
                Id = 1, 
                Name = "Hillary Smith", 
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            },
            new Stylist { 
                Id = 2, 
                Name = "John Doe", 
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            },
            new Stylist { 
                Id = 3, 
                Name = "Jane Wilson", 
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            }
        );

        modelBuilder.Entity<Service>().HasData(
            new Service { Id = 1, Name = "Haircut", Price = 30.00M, Description = "Basic haircut service" },
            new Service { Id = 2, Name = "Color", Price = 75.00M, Description = "Hair coloring service" },
            new Service { Id = 3, Name = "Style", Price = 45.00M, Description = "Hair styling service" },
            new Service { Id = 4, Name = "Beard Trim", Price = 20.00M, Description = "Beard trimming service" }
        );

        modelBuilder.Entity<Customer>().HasData(
            new Customer { 
                Id = 1, 
                Name = "Alice Johnson", 
                Email = "alice@email.com", 
                Phone = "555-0101",
                CreatedAt = DateTime.UtcNow
            },
            new Customer { 
                Id = 2, 
                Name = "Bob Smith", 
                Email = "bob@email.com", 
                Phone = "555-0102",
                CreatedAt = DateTime.UtcNow
            }
        );
    }
} 