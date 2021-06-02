using CreateOrders.Api.Domain.Models;
using CreateOrders.Api.Domain.Models.ModelResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreateOrders.Api.Application
{
    public interface ICustomersApplication
    {
        IEnumerable<CustomersViewModel> GetAll();
        CustomersViewModel GetById(int id);
        CustomersViewResponse Create(CustomersViewModel product);
        CustomersViewModel Update(CustomersViewModel product);
        void Delete(int id);
    }
}
