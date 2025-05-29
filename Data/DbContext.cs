using Microsoft.EntityFrameworkCore;
using WebServicesNenadExam5063.Models;

namespace WebServicesNenadExam5063.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Client> Client { get; set; }
        public DbSet<Movie> Movie { get; set; }


    }
}
