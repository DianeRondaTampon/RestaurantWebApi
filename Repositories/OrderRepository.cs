using Microsoft.EntityFrameworkCore;
using RestaurantsWebApi.Models;


namespace RestaurantsWebApi.Repositories
{
    public class OrderRepository
    {
        private readonly RestaurantDbContext _context;

        public OrderRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public List<Order> GetAllOrder()
        {
            return _context.Order.ToList();
        }

        public Order? GetOrderById(int id)
        {
            return _context.Order.Find(id);
        }

        public void AddOrder(Order order)
        {
            _context.Order.Add(order);
            _context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            var order = _context.Order.Find(id);
            if (order != null)
            {
                _context.Order.Remove(order);
                _context.SaveChanges();
            }
        }


    }
}
