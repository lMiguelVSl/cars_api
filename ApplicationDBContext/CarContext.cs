using cars_api.Model;
using Microsoft.EntityFrameworkCore;

namespace cars_api.ApplicationDBContext
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options) : base(options) { }
        public DbSet<Car> _Car { get; set; }
    }
}
