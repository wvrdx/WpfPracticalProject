using System.Data.Entity;
using WpfPracticalProject.Models;

namespace WpfPracticalProject
{
    public class AppDataBaseContext : DbContext
    {
        public AppDataBaseContext() : base("DefaultConnection")
        {
        }

        public DbSet<Table> Tables { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<TableStatus> TableStatuses { get; set; }
        public DbSet<TableType> TableTypes { get; set; }
    }
}