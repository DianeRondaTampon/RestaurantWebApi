using Microsoft.EntityFrameworkCore;
using RestaurantsWebApi.Application;
using RestaurantsWebApi.Repositories;


namespace RestaurantsWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            //dependency injection:

            // Add DbContext
            builder.Services.AddDbContext<RestaurantDbContext>(options =>
                         options.UseSqlServer("Server=localhost;Database=Restaurant;User Id=UserRestaurant;Password=UserRestaurant;TrustServerCertificate=True;"));

            // Add Repositories
            builder.Services.AddScoped<CustomerRepository>();
            builder.Services.AddScoped<MenuItemRepository>();
            builder.Services.AddScoped<OrderDetailRepository>();
            builder.Services.AddScoped<OrderRepository>();
            builder.Services.AddScoped<RestaurantRepository>();
            // Add other repositories if needed

            // Add Services
            builder.Services.AddScoped<AdministratorService>();
            builder.Services.AddScoped<WorkerService>();
            
            // Add other services if needed






            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

