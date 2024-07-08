namespace RestaurantsWebApi.Dto
{
    public class OrderNotFinishResponse
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Waiter { get; set; }
        public int CustomerId { get; set; }
        public string Table { get; set; }
        public decimal? Price { get; set; }
        public int RestaurantId { get; set; }
    }
}
