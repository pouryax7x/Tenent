using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection;
using TenantAuthenticator.Context;
using TenantAuthenticator.Interface;
using WebApplication1.Controllers;
using WebApplication1.Entities;

namespace WebApplication1.Context;

public class MainDBContext : TenantBaseContext, IMainDbContext
{

    public MainDBContext(DbContextOptions<MainDBContext> options, ICurrentTenantService currentTenantService) : base(options, currentTenantService)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("Book");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Book> Books { get; set; }
}
