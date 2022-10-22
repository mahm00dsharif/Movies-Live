using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoviesLive.Domain.Entities;
using MoviesLive.Infrasturcture.Configuration;

namespace MoviesLive.Infrasturcture
{
    public class EFContext : IdentityDbContext<IdentityUser>
    {
        public EFContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasOne(a => a.Parent)
                .WithMany(a => a.SubCategories).HasForeignKey(a => a.ParentId).IsRequired(false)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
    }
}
