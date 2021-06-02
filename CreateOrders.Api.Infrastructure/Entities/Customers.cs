using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CreateOrders.Api.Infrastructure.Entities
{
    public class Customers
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public string FullName { get; set; }

        [Required(ErrorMessage = "Ingrese una identificación válida.")]
        public int IDCustomer { get; set; }

        public string Adress { get; set; }

        public string EMail { get; set; }

        public int Phone { get; set; }

        public string City { get; set; }
    }
}
