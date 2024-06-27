using Microsoft.EntityFrameworkCore;
using RestaurantsWebApi.Models;


namespace RestaurantsWebApi
{
    public class RestaurantDbContext : DbContext
  
    {

        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options) { }


        public DbSet<Customer> Customer { get; set; }
        public DbSet<MenuItem> MenuItem { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 

        }

    }
}

