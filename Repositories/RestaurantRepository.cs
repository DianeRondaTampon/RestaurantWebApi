using Microsoft.EntityFrameworkCore;
using RestaurantsWebApi.Models;

namespace RestaurantsWebApi.Repositories
{
    public class RestaurantRepository
    {
        private readonly RestaurantDbContext _context;

        public RestaurantRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public List<Restaurant> GetAllRestaurant()
        {
            return _context.Restaurant.ToList();
        }

        public Restaurant? GetRestaurantById(int id)
        {
            return _context.Restaurant.Find(id);
        }

        public void AddRestaurant(Restaurant restaurant)
        {
            _context.Restaurant.Add(restaurant);
            _context.SaveChanges();
        }

        public void UpdateRestaurant(Restaurant restaurant)
        {
            _context.Entry(restaurant).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteRestaurant(int id)
        {
            var restaurant = _context.Restaurant.Find(id);
            if (restaurant != null)
            {
                _context.Restaurant.Remove(restaurant);
                _context.SaveChanges();
            }
        }


    }
}

   