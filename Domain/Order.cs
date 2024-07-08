namespace RestaurantsWebApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Waiter { get; set; }
        public int CustomerId { get; set; }
        public string Table { get; set;}
        public decimal? Price { get; set; }
        public int RestaurantId { get; set; }

        //Navigation Property

        public virtual List<OrderDetail> OrderDetail { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Restaurant Restaurant { get; set; }

    }
}
