using System.Reflection;

namespace RestaurantsWebApi.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        //navigation Properties

        public virtual Restaurant Restaurant { get; set; }

        public virtual List<OrderDetail> OrderDetail { get; set; }

    }
}
