using RestaurantsWebApi.Application;
using RestaurantsWebApi.Dto;
using RestaurantsWebApi.Models;
using RestaurantsWebApi.Repositories;
using System.Security.Cryptography;

namespace RestaurantsWebApi.Application
{
    public class WorkerService
    {
        private readonly CustomerRepository _customerRepository;
        private readonly OrderRepository _orderRepository;
        private readonly OrderDetailRepository _orderDetailRepository;

        public WorkerService(CustomerRepository customerRepository, OrderDetailRepository orderDetailRepository, OrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _orderDetailRepository = orderDetailRepository;
            _orderRepository = orderRepository;
        }

        public AddCustomerResponse AddCustomer(AddCustomerRequest addCustomerRequest)
        {
            Customer customer = new Customer()
            {
                Name = addCustomerRequest.Name,
               
            };
            _customerRepository.AddCustomer(customer);
            AddCustomerResponse addCustomerResponse = new AddCustomerResponse()
            {
                Id = customer.Id,
            };
            return addCustomerResponse;
        }


        public AddOrderResponse AddOrder(AddOrderRequest addOrderRequest)
        {
            Order order = new Order()
            {
                Date = addOrderRequest.Date,
                Waiter = addOrderRequest.Waiter,
                CustomerId = addOrderRequest.CustomerId,
                Table = addOrderRequest.Table,

            };
            _orderRepository.AddOrder(order);
            AddOrderResponse addOrderResponse = new AddOrderResponse()
            {
                Id = order.Id,
            };
            return addOrderResponse;
        }

        public  FinishOrderResponse? FinishOrder(FinishOrderRequest finishOrderRequest)
        {
            Order? order = _orderRepository.GetOrderById(finishOrderRequest.OrderId);

            if (order == null)
            {
                return null;
            }

            order.Price = finishOrderRequest.Money;
             
            _orderRepository.UpdateOrder(order);

            FinishOrderResponse finishOrderResponse = new FinishOrderResponse()
            {
                Id = order.Id,

            };

            return finishOrderResponse;

        }

        public List <OrderNotFinishResponse> GetOrdersNotFinish (OrderNotFinishRequest orderNotFinishRequest)
        {

            /*
            List<Order> notfinishedOrders = _orderRepository.GetAllOrder().
           
            OrderNotFinishResponse = notfinishedOrders.
            {
                Id = orderNotFinishRequest.Id,
                Date = orderNotFinishRequest.Date,
                Waiter = orderNotFinishRequest.Waiter,
                CustomerId = orderNotFinishRequest.CustomerId,
                Table = orderNotFinishRequest.Table,
                Price = orderNotFinishRequest.Price,

            }).ToList();

            return orderNotFinishResponse;
            */

            return null;


        }











    }
}

    

