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
    public class ProductsController : ControllerBase
    {
        private readonly IProductsApplication productsApplication;

        public ProductsController(IProductsApplication productsApplication)
        {
            this.productsApplication = productsApplication;
        }

        [HttpGet]
        public IEnumerable<ProductsViewModel> GetAll()
        {
            return productsApplication.GetAll();
        }

        [HttpGet("{id}")]
        public ProductsViewModel GetById(int id)
        {
            return productsApplication.GetById(id);
        }

        [HttpPost]
        public ActionResult<ProductsViewResponse> Create(ProductsViewModel product)
        {
            var result = productsApplication.Create(product);

            return result;
        }

        [HttpPut("{id}")]
        public ProductsViewModel Update(ProductsViewModel product)
        {
            return productsApplication.Update(product);
        }

        [HttpDelete("id")]
        public void Delete(int id)
        {
            productsApplication.Delete(id);
        }
    }
}
