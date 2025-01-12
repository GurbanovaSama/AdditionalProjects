using Logistica.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Logistica.DAL.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options ) : base(options) { }

        public DbSet<SliderItem> SliderItems { get; set; }  
        public DbSet<Member> Members { get; set; }  
        public DbSet<Client> Clients { get; set; }  
        public DbSet<Service> Services { get; set; }
        public DbSet<MembersClients> MembersClients { get; set; }       

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MembersClients>()
                .HasKey(x => new { x.ClientId, x.MemberId });
            builder.Entity<MembersClients>()
                .HasOne(c => c.Member)
                .WithMany(c => c.MembersClients)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<MembersClients>()
                .HasOne(c => c.Client)
                .WithMany(C => C.MembersClients)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }

    }
}
