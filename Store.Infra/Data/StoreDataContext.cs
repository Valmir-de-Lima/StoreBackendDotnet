using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Infra.Mappings;

namespace Store.Infra.Data;

public class StoreDataContext : DbContext
{
    public StoreDataContext(DbContextOptions<StoreDataContext> options)
            : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<RefreshLoginUser> RefreshLoginUsers { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new RefreshLoginUserMap());
    }
}