using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols;
using RestaurantsWebApi.Application;
using RestaurantsWebApi.Dto;

namespace RestaurantsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class WorkerController : ControllerBase
    {
        private readonly WorkerService _workerService;

        public WorkerController(WorkerService workerService)
        {
            _workerService = workerService;
        }

        [HttpPost("AddCustomer")]

        public ActionResult<AddCustomerResponse> AddCustomer(AddCustomerRequest addCustomerRequest)
        {
            return Ok(_workerService.AddCustomer(addCustomerRequest));
        }

        [HttpPost("AddOrder")]

        public ActionResult<AddOrderResponse> AddOrder(AddOrderRequest addOrderRequest)
        {
            return Ok(_workerService.AddOrder(addOrderRequest));
        }

        [HttpPut("FinishOrder")]
        public ActionResult<FinishOrderResponse> FinishOrder(FinishOrderRequest finishOrderRequest)
        {
            //Retrieve the data from function and storage it so you can use it
            //the name of var can be any
            //for storage the return of the function into a var you need to use the same type that returns the function
            //to know the return odf a function you put the mouse over the function name

          
            FinishOrderResponse? finishOrderResponse = _workerService.FinishOrder(finishOrderRequest);

            if(finishOrderResponse == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(finishOrderRequest);
            }
        }



       






    }
}
