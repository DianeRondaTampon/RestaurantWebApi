using Microsoft.EntityFrameworkCore;
using RestaurantsWebApi.Models;


namespace RestaurantsWebApi.Repositories
{
    public class CustomerRepository
    {
        private readonly RestaurantDbContext _context;

        public CustomerRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public List<Customer> GetAllCustomer()
        {
            return _context.Customer.ToList();
        }

        public Customer? GetCustomerById(int id)
        {
            return _context.Customer.Find(id);
        }

        public void AddCustomer(Customer customer)
        {
            _context.Customer.Add(customer);
            _context.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteCustomer(int id)
        {
            var customer = _context.Customer.Find(id);
            if (customer != null)
            {
                _context.Customer.Remove(customer);
                _context.SaveChanges();
            }
        }


    }
}
