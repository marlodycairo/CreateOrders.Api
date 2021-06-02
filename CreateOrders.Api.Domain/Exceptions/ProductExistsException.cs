using System;
using System.Collections.Generic;
using System.Text;

namespace CreateOrders.Api.Domain.Exceptions
{
    public class ProductExistsException : Exception
    {
        public override string Message => "Ese producto ya existe.";
        public override string Source { get => base.Source; set => base.Source = value; }
    }
}
