namespace RestaurantsWebApi.Dto
{
    public class AddMenuItemRequest
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public decimal Price  { get; set; }


    }
}
