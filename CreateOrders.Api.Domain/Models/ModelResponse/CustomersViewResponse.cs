using System;
using System.Collections.Generic;
using System.Text;

namespace CreateOrders.Api.Domain.Models.ModelResponse
{
    public class CustomersViewResponse
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int IDCustomer { get; set; }
    }
}
