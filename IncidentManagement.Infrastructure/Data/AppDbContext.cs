using IncidentManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IncidentManagement.Infrastructure.Data;

public class AppDbContext : DbContext
{
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    
    // Definimos las tablas en la base de datos
    public DbSet<User> Users { get; set; }
    public DbSet<Technician> Technicians { get; set; } 
    public DbSet<Incident> Incidents { get; set; }
    public DbSet<Comment> Comments { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Si AuthorType se almacena como string en la base de datos
        modelBuilder.Entity<Comment>()
            .Property(c => c.AuthorType)
            .HasConversion<string>();
    }
    
}