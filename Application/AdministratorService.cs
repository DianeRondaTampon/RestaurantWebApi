using Microsoft.AspNetCore.Mvc;
using RestaurantsWebApi.Dto;
using RestaurantsWebApi.Models;
using RestaurantsWebApi.Repositories;
using System.IO;

namespace RestaurantsWebApi.Application
{
    public class AdministratorService
    {
        private readonly RestaurantRepository _restaurantRepository;
        private readonly MenuItemRepository _menuItemRepository;


        public AdministratorService(RestaurantRepository restaurantRepository, MenuItemRepository menuItemRepository)
        {
            _restaurantRepository = restaurantRepository;
            _menuItemRepository = menuItemRepository;
        }

        public List<GetRestaurantResponse> GetAllRestaurants()
        {
            List<GetRestaurantResponse> getRestaurantResponses = new List<GetRestaurantResponse>();
           
            List<Restaurant> restaurants = _restaurantRepository.GetAllRestaurant ();

            foreach (Restaurant restaurant in restaurants)
            {
                GetRestaurantResponse getRestaurantResponse = new GetRestaurantResponse()
                {
                    Id = restaurant.Id,
                    Name = restaurant.Name,
                    Location = restaurant.Location
                };
                getRestaurantResponses.Add(getRestaurantResponse);
            }

            return getRestaurantResponses;
        }

        private void AddRestaurant(AddRestaurantRequest restaurant)
        {
            /*
            _restaurantRepository.AddRestaurant(restaurant);
           */
        }

        public void UpdateRestaurant(Restaurant restaurant)
        {
            _restaurantRepository.UpdateRestaurant(restaurant);
        }

        public void AddMenuItem(MenuItem menuItem)
        {
            _menuItemRepository.AddMenuItem(menuItem);
        }


    }
}












