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
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersApplication customersApplication;

        public CustomersController(ICustomersApplication customersApplication)
        {
            this.customersApplication = customersApplication;
        }

        [HttpGet]
        public IEnumerable<CustomersViewModel> GetAll()
        {
            return customersApplication.GetAll();
        }

        [HttpGet("{id}")]
        public CustomersViewModel GetById(int id)
        {
            return customersApplication.GetById(id);
        }

        [HttpPost]
        public ActionResult<CustomersViewResponse> Create(CustomersViewModel customer)
        {
            var result = customersApplication.Create(customer);

            return result;
        }

        [HttpPut("{id}")]
        public CustomersViewModel Update(CustomersViewModel customer)
        {
            return customersApplication.Update(customer);
        }

        [HttpDelete("id")]
        public void Delete(int id)
        {
            customersApplication.Delete(id);
        }
    }
}
