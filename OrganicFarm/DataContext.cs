using Microsoft.EntityFrameworkCore;
using OrganicFarm.Models;

namespace OrganicFarm
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options) 
        {

        }
        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Shop> shops { get; set; }
        public DbSet<Product> products { get; set; }
    }
}
