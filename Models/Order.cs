namespace RestaurantsWebApi.Models
{
    public class Order
    {
          public int Id { get; set; }
          public int Date { get; set; }
          public string? Waiter { get; set; }
          public int   CustomerId { get; set; }
          public string Table { get; set;}
          
    }
}
