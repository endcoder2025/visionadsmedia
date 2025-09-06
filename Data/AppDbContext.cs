using Microsoft.EntityFrameworkCore;
using visionadsmedia.Models;

namespace visionadsmedia.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // DbSet for Contacts table
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contacts"); // Table name in SQL Server

                entity.HasKey(c => c.Id); // Primary Key

                entity.Property(c => c.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(c => c.Email)
                      .IsRequired()
                      .HasMaxLength(150);

                entity.Property(c => c.Phone)
                      .HasMaxLength(20);

                entity.Property(c => c.Message)
                      .HasMaxLength(1000);

                entity.Property(c => c.CreatedAt)
                      .HasDefaultValueSql("GETUTCDATE()"); // default timestamp
            });
        }
    }
}
