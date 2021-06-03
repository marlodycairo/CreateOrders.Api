using System;
using System.Collections.Generic;
using System.Text;

namespace CreateOrders.Api.Domain.Models
{
    public class CustomersViewModel
    {
        public int? Id { get; set; }
        public string FullName { get; set; }
        public int IDCustomer { get; set; }
        public string Adress { get; set; }
        public string EMail { get; set; }
        public int Phone { get; set; }
        public string City { get; set; }
    }
}
