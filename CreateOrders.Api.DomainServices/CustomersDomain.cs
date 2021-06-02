using AutoMapper;
using CreateOrders.Api.Domain;
using CreateOrders.Api.Domain.Models;
using CreateOrders.Api.Domain.Models.ModelResponse;
using CreateOrders.Api.Infrastructure.Entities;
using CreateOrders.Api.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreateOrders.Api.DomainServices
{
    public class CustomersDomain : ICustomersDomain
    {
        private readonly ICustomersRepository customersRepository;
        private readonly IMapper mapper;

        public CustomersDomain(ICustomersRepository customersRepository, IMapper mapper)
        {
            this.customersRepository = customersRepository;
            this.mapper = mapper;
        }

        public CustomersViewResponse Create(Customers customer)
        {
            customersRepository.Create(customer);

            var result = mapper.Map<CustomersViewResponse>(customer);

            return result;
        }

        public void Delete(int id)
        {
            customersRepository.Delete(id);
        }

        public IEnumerable<CustomersViewModel> GetAll()
        {
            var customers = customersRepository.GetAll();

            var result = mapper.Map<IEnumerable<CustomersViewModel>>(customers);

            return result;
        }

        public CustomersViewModel GetById(int id)
        {
            var customer = customersRepository.GetById(id);
            var customers = mapper.Map<CustomersViewModel>(customer);

            return customers;
        }

        public CustomersViewModel Update(CustomersViewModel customerModel)
        {
            var customers = mapper.Map<Customers>(customerModel);

            customersRepository.Update(customers);

            return customerModel;
        }
    }
}
