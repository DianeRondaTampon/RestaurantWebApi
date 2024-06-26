﻿namespace RestaurantsWebApi.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }  
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }

        //Navigation Property 

        public virtual Order Order { get; set; }

        public virtual MenuItem MenuItem { get; set; }


    }
}
