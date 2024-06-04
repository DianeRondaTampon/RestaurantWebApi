using Microsoft.EntityFrameworkCore;
using RestaurantsWebApi.Models;

namespace RestaurantsWebApi.Repositories
{
    public class OrderDetailRepository
    {
        private readonly RestaurantDbContext _context;

        public OrderDetailRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public List<OrderDetail> GetAllOrderDetail()
        {
            return _context.OrderDetail.ToList();
        }

        public OrderDetail? GetOrderDetailById(int id)
        {
            return _context.OrderDetail.Find(id);
        }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            _context.OrderDetail.Add(orderDetail);
            _context.SaveChanges();
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            _context.Entry(orderDetail).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteOrderDetail(int id)
        {
            var orderDetail = _context.OrderDetail.Find(id);
            if (orderDetail != null)
            {
                _context.OrderDetail.Remove(orderDetail);
                _context.SaveChanges();
            }
        }


    }
}
