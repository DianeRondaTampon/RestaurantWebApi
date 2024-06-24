namespace RestaurantsWebApi.Dto
{
    public class AddOrderRequest
    {
        public DateTime Date { get; set; }
        public string? Waiter { get; set; }
        public int CustomerId { get; set; }
        public string Table { get; set; }


    }
}
