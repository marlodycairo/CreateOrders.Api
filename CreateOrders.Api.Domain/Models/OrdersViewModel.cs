using System;
using System.Collections.Generic;
using System.Text;

namespace CreateOrders.Api.Domain.Models
{
    public class OrdersViewModel
    {
        public int Id { get; set; }
        public DateTime DateOrder { get; set; }
        public int IdProduct { get; set; }
        public int IdCustomer { get; set; }
    }
}
