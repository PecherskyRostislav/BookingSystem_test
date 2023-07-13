using API.DataStore.Models;
using Microsoft.EntityFrameworkCore;

namespace API.DataStore;

public class ContextDb : DbContext
{
    public ContextDb()
    {
    }

    public ContextDb(DbContextOptions<ContextDb> options)
        : base(options)
    {
    }

    #region Tables

    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Location> Locations { get; set; }

    #endregion

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql("name=ConnectionStrings:default", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));
        }
    }
}
