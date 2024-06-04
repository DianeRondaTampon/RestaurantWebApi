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
            if (!optionsBuilder.IsConfigured)
            {
                // Replace "YourServer", "YourDatabase", "YourUsername", and "YourPassword" with your actual database details
                optionsBuilder.UseSqlServer("Server=DESKTOP-9998B8S\\SQLEXPRESS;Database=Restaurant;User Id=UserRestaurant;Password=UserRestaurant;TrustServerCertificate=True;");
            }


        }

    }
}

