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


            // Determine the environment
            var environment = builder.Environment.EnvironmentName;
            environment ="localhost";

            // Configure the application to use environment-specific appsettings.json file
            builder.Configuration
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // base configuration
                .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true) // environment-specific configuration
                .AddEnvironmentVariables(); // Add environment variables


            //dependency injection:

            // Register the DbContext with DI, injecting IConfiguration
            builder.Services.AddDbContext<RestaurantDbContext>((serviceProvider, options) =>
            {
                var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });


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

