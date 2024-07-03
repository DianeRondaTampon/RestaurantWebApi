using Microsoft.AspNetCore.Mvc;
using RestaurantsWebApi.Application;
using RestaurantsWebApi.Dto;
using RestaurantsWebApi.Models;
using RestaurantsWebApi.Repositories;

namespace RestaurantsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AdministratorController : ControllerBase
    {
        private readonly AdministratorService _administratorService;

        public AdministratorController(AdministratorService administratorService)
        {
            _administratorService = administratorService;
        }

        [HttpGet("GetAllRestaurants")]
        public ActionResult<List<GetRestaurantResponse>> GetAllRestaurants()
        {
            return Ok(_administratorService.GetAllRestaurants());
        }

        [HttpPost("Restaurant")]
        public ActionResult<AddRestaurantResponse> AddRestaurant(AddRestaurantRequest addRestaurantRequest)
        {
            return Ok(_administratorService.AddRestaurant(addRestaurantRequest));
        }

        [HttpPut("Restaurant")]
        public ActionResult<UpdateRestaurantRequest> UpdateRestaurant(UpdateRestaurantRequest updateRestaurantRequest)
        {
            if (_administratorService.UpdateRestaurant(updateRestaurantRequest))
            {
                return Ok(updateRestaurantRequest);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("MenuItem")]
        public ActionResult<AddMenuItemResponse> AddMenuItem(AddMenuItemRequest addMenuItemRequest)
        {
            return Ok(_administratorService.AddMenuItem(addMenuItemRequest));
        }


        [HttpPut("MenuItem")]
        public ActionResult<UpdateMenuItemRequest> UpdateMenuItem(UpdateMenuItemRequest updateMenuItemRequest)
        {
            if (_administratorService.UpdateMenuItem(updateMenuItemRequest))
            {
                return Ok(updateMenuItemRequest);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("Menu/{restaurantId}")]
        public ActionResult<List<GetMenuResponse>> GetMenu([FromRoute] int restaurantId)
        {
            return Ok(_administratorService.GetMenu(restaurantId));
        }

        
        [HttpDelete("Menu/{id}")]
        public  ActionResult<DeleteMenuItemRequest> DeleteMenuItem([FromRoute] int id)
        {
            DeleteMenuItemRequest deleteMenuItemRequest = new DeleteMenuItemRequest() { MenuItemId = id };
            if (_administratorService.DeleteMenuItem(deleteMenuItemRequest) != null) 
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }


      







        }
}
