using API.DataStore.Models;
using Microsoft.EntityFrameworkCore;

namespace API.DataStore;

public class ContextDB : DbContext
{
    public ContextDB() : base()
    {
        
    }

    #region Tables

    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Location> Locations { get; set; }

    #endregion
}
