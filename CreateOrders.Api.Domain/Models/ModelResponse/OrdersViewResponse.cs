using System;
using System.Collections.Generic;
using System.Text;

namespace CreateOrders.Api.Domain.Models.ModelResponse
{
    public class OrdersViewResponse
    {
        public int Id { get; set; }
        public DateTime DateOrder { get; set; }
    }
}
