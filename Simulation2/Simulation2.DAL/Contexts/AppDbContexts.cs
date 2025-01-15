using Microsoft.EntityFrameworkCore;
using Simulation2.DAL.Models;

namespace Simulation2.DAL.Contexts;

public class AppDbContexts : DbContext
{
    public AppDbContexts(DbContextOptions options) : base(options) { }

    public DbSet<Technician> Technicians { get; set; }
    public DbSet<Service> Services { get; set; }    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Technician>()
            .HasOne(t => t.Service)
            .WithMany(t => t.Technicians)
            .HasForeignKey(t => t.ServiceId)
            .OnDelete(DeleteBehavior.Restrict); 
    }
}
