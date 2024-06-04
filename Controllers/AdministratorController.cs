using Microsoft.AspNetCore.Mvc;
using RestaurantsWebApi.Application;
using RestaurantsWebApi.Dto;
using RestaurantsWebApi.Models;

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
            return _administratorService.GetAllRestaurants();
        }

        


    }
}
