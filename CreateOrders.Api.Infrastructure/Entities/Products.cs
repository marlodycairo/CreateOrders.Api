using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CreateOrders.Api.Infrastructure.Entities
{
    public class Products
    {
        [ScaffoldColumn(false)]
        public int? Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
    }
}
