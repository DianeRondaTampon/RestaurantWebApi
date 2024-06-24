namespace RestaurantsWebApi.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        //navigation property
        public virtual List<MenuItem> MenuItem { get; set; }
    }
}
