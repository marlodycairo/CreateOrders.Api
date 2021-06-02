using AutoMapper;
using CreateOrders.Api.Domain.Models;
using CreateOrders.Api.Domain.Models.ModelResponse;
using CreateOrders.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreateOrders.Api.Domain.Mappers
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Customers, CustomersViewModel>();
            CreateMap<CustomersViewModel, Customers>();

            CreateMap<Customers, CustomersViewResponse>();
            CreateMap<CustomersViewResponse, Customers>();

            CreateMap<Orders, OrdersViewModel>();
            CreateMap<OrdersViewModel, Orders>();

            CreateMap<Orders, OrdersViewResponse>();
            CreateMap<OrdersViewResponse, Orders>();

            CreateMap<Products, ProductsViewModel>();
            CreateMap<ProductsViewModel, Products>();

            CreateMap<Products, ProductsViewResponse>();
            CreateMap<ProductsViewResponse, Products>();
        }
    }
}
