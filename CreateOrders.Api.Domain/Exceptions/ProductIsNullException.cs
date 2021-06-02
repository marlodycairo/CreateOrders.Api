using System;
using System.Collections.Generic;
using System.Text;

namespace CreateOrders.Api.Domain.Exceptions
{
    public class ProductIsNullException : Exception
    {
        public override string Message => "Producto no encontrado. Ingrese un producto.";
    }
}
