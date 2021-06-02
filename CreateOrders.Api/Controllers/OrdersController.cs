using CreateOrders.Api.Application;
using CreateOrders.Api.Domain.Models;
using CreateOrders.Api.Domain.Models.ModelResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateOrders.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersApplication ordersApplication;

        public OrdersController(IOrdersApplication ordersApplication)
        {
            this.ordersApplication = ordersApplication;
        }

        [HttpGet]
        public IEnumerable<OrdersViewModel> GetAll()
        {
            return ordersApplication.GetAll();
        }

        [HttpGet("{id}")]
        public OrdersViewModel GetById(int id)
        {
            return ordersApplication.GetById(id);
        }

        [HttpPost]
        public ActionResult<OrdersViewResponse> Create(OrdersViewModel order)
        {
            var result = ordersApplication.Create(order);

            return result;
        }

        [HttpPut("{id}")]
        public OrdersViewModel Update(OrdersViewModel order)
        {
            return ordersApplication.Update(order);
        }

        [HttpDelete("id")]
        public void Delete(int id)
        {
            ordersApplication.Delete(id);
        }
    }
}
