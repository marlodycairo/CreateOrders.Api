using AutoMapper;
using CreateOrders.Api.Application;
using CreateOrders.Api.Domain;
using CreateOrders.Api.Domain.Models;
using CreateOrders.Api.Domain.Models.ModelResponse;
using CreateOrders.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreateOrders.Api.ApplicationServices
{
    public class CustomersApplication : ICustomersApplication
    {
        private readonly ICustomersDomain customersDomain;
        private readonly IMapper mapper;

        public CustomersApplication(ICustomersDomain customersDomain, IMapper mapper)
        {
            this.customersDomain = customersDomain;
            this.mapper = mapper;
        }

        public CustomersViewResponse Create(CustomersViewModel customer)
        {
            //customersDomain.GetById(customer.Id);

            //if (CustomerExists(customer.Id))
            //{
            //    throw new Exception("El Cliente ya existe.");
            //}

            var result = mapper.Map<Customers>(customer);
            var products = customersDomain.Create(result);

            return products;
        }

        public void Delete(int id)
        {
            customersDomain.Delete(id);
        }

        public IEnumerable<CustomersViewModel> GetAll()
        {
            return customersDomain.GetAll();
        }

        public CustomersViewModel GetById(int id)
        {
            return customersDomain.GetById(id);
        }

        public CustomersViewModel Update(CustomersViewModel customer)
        {
            return customersDomain.Update(customer);
        }

        private bool CustomerExists(int id)
        {
            return customersDomain.GetAll().Any(p => p.Id == id);
        }
    }
}
