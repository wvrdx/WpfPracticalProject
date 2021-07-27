using System.Data.Entity;

namespace WpfPracticalProject.Models
{
    public class AppDataBaseContext : DbContext
    {
        public AppDataBaseContext(): base ("DefaultConnection")
        {

        }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
