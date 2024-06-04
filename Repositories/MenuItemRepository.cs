using Microsoft.EntityFrameworkCore;
using RestaurantsWebApi.Models;


namespace RestaurantsWebApi.Repositories
{
    public class MenuItemRepository
    {

        private readonly RestaurantDbContext _context;

        public MenuItemRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public List<MenuItem> GetAllMenuItem()
        {
            return _context.MenuItem.ToList();
        }

        public MenuItem? GetMenuItemById(int id)
        {
            return _context.MenuItem.Find(id);
        }

        public void AddMenuItem(MenuItem menuItem)
        {
            _context.MenuItem.Add(menuItem);
            _context.SaveChanges();
        }

        public void UpdateMenuItem(MenuItem menuItem)
        {
            _context.Entry(menuItem).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteMenuItem(int id)
        {
            var menuItem = _context.MenuItem.Find(id);
            if (menuItem != null)
            {
                _context.MenuItem.Remove(menuItem);
                _context.SaveChanges();
            }
        }


    }
}
