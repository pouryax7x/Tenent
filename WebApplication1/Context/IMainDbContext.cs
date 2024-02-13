using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.Context;

public interface IMainDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    public DbSet<Book> Books { get; set; }
}