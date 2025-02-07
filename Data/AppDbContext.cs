using Microsoft.EntityFrameworkCore;

namespace MyVulnerableApp.Data
{
    public class AppDbContext : DbContext
    {
        // Questa è la definizione del DbSet per la classe User
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // La classe User è definita qui dentro
        public class User
        {
            public int Id { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
