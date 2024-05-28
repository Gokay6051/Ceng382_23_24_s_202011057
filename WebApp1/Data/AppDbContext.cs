using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApp1.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : 
        base(options)
        {
        }
        public DbSet<Room> Rooms { get; set; }

        public DbSet<Reservation> Reservations { get; set; }
        
    }
}