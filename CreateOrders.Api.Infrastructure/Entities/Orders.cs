using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CreateOrders.Api.Infrastructure.Entities
{
    public class Orders
    {
        [ScaffoldColumn(false)]
        public int? Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateOrder { get; set; }

        public int? IdProduct { get; set; }

        public int? IdCustomer { get; set; }
    }
}
