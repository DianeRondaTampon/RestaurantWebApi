namespace RestaurantsWebApi.Dto
{
    public class UpdateMenuItemRequest
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public  decimal Price { get; set; }


    }
}
