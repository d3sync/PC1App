using Microsoft.EntityFrameworkCore;
using PC1.Models;

namespace PC1.Data;

public class DbContextDb : DbContext
{
    public DbContextDb(DbContextOptions<DbContextDb> options)
        : base(options)
    {
    }

    public DbSet<DeliveredModel> DeliveredModel { get; set; } = default!;

    public DbSet<AssignedtoModel> AssignedtoModel { get; set; } = default!;

    public DbSet<ReceivedParcels> ReceivedParcels { get; set; } = default!;
}