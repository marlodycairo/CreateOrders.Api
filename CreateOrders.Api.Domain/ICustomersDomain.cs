using CreateOrders.Api.Domain.Models;
using CreateOrders.Api.Domain.Models.ModelResponse;
using CreateOrders.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreateOrders.Api.Domain
{
    public interface ICustomersDomain
    {
        IEnumerable<CustomersViewModel> GetAll();
        CustomersViewModel GetById(int id);
        CustomersViewResponse Create(Customers customer);
        CustomersViewModel Update(CustomersViewModel customer);
        void Delete(int id);
    }
}
