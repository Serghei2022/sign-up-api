using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using sign_up_api.Entities;
using System.IO;

namespace sign_up_api.DbContexts;

public class SignUpDbContext : DbContext
{
    public DbSet<Company> Companies { get; set; } = null!;
    public DbSet<Industry> Industries { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public SignUpDbContext(DbContextOptions<SignUpDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Industry>().HasData(
            new Industry(Guid.NewGuid(), "Healthcare"),
            new Industry(Guid.NewGuid(), "Finance and Banking"),
            new Industry(Guid.NewGuid(), "Retail and E-commerce"),
            new Industry(Guid.NewGuid(), "Manufacturing"),
            new Industry(Guid.NewGuid(), "Telecommunications")
        );

        modelBuilder.Entity<User>()
            .HasOne(u => u.Company)
            .WithMany(c => c.Users)
            .HasForeignKey(u => u.CompanyId);

        modelBuilder.Entity<Company>()
            .HasOne(c => c.Industry)
            .WithMany(i => i.Companies)
            .HasForeignKey(c => c.IndustryId);

        // modelBuilder.Entity<Company>()
        //     .HasIndex(c => c.Name)
        //     .IsUnique();
    }
}
