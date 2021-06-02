using System;
using System.Collections.Generic;
using System.Text;

namespace CreateOrders.Api.Domain.Models
{
    public class ProductsViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
