using System.IO;

namespace RestaurantsWebApi.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        //navigation Properties

        public virtual List<Order> Order { get; set; }

    }
}
