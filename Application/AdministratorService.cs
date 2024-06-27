using Microsoft.AspNetCore.Mvc;
using RestaurantsWebApi.Dto;
using RestaurantsWebApi.Models;
using RestaurantsWebApi.Repositories;
using System.IO;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

            List<Restaurant> restaurants = _restaurantRepository.GetAllRestaurant();

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


        public AddRestaurantResponse AddRestaurant(AddRestaurantRequest addRestaurantRequest)
        {
            Restaurant restaurant = new Restaurant()
            {
                Name = addRestaurantRequest.Name,
                Location = addRestaurantRequest.Location
            };
            _restaurantRepository.AddRestaurant(restaurant);
            AddRestaurantResponse addRestaurantResponse = new AddRestaurantResponse()
            {
                Id = restaurant.Id,
               
            };
            return addRestaurantResponse;
        }


        public bool UpdateRestaurant(UpdateRestaurantRequest updateRestaurantRequest)
        {
            Restaurant? getRestaurant = _restaurantRepository.GetRestaurantById(updateRestaurantRequest.Id);
            
            if (getRestaurant == null)
            {
                return false;
            }
            getRestaurant.Id = updateRestaurantRequest.Id;
            getRestaurant.Name = updateRestaurantRequest.Name;
            getRestaurant.Location = updateRestaurantRequest.Location;


            _restaurantRepository.UpdateRestaurant(getRestaurant);

            return true;
        }

        public AddMenuItemResponse AddMenuItem(AddMenuItemRequest addMenuItemRequest)
        {
            MenuItem menuItem = new MenuItem()
            {
                RestaurantId = addMenuItemRequest.RestaurantId,
                Name = addMenuItemRequest.Name,
                Price = addMenuItemRequest.Price,
            };
            _menuItemRepository.AddMenuItem(menuItem);
            AddMenuItemResponse addMenuItemResponse = new AddMenuItemResponse()
            {
                Id = menuItem.Id
            };
            return addMenuItemResponse;
        }

        public bool UpdateMenuItem(UpdateMenuItemRequest updateMenuItemRequest)
        {
            MenuItem? getMenuItem = _menuItemRepository.GetMenuItemById(updateMenuItemRequest.Id);
            if (getMenuItem == null)
            {
                return false;
            }

            getMenuItem.Id = updateMenuItemRequest.Id;
            getMenuItem.RestaurantId = updateMenuItemRequest.RestaurantId;
            getMenuItem.Name = updateMenuItemRequest.Name;
            getMenuItem.Price = updateMenuItemRequest.Price;

            _menuItemRepository.UpdateMenuItem(getMenuItem);
            return true;

        }


        //public GetMenuRequest MenuRequest(GetMenuRequest getMenuRequest)
       







        }
    }













