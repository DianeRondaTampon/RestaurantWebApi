namespace RestaurantsWebApi.Dto
{
    public class UpdateRestaurantRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
