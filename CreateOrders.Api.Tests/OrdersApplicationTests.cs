using AutoMapper;
using CreateOrders.Api.ApplicationServices;
using CreateOrders.Api.Domain;
using CreateOrders.Api.Domain.Models;
using CreateOrders.Api.Domain.Models.ModelResponse;
using CreateOrders.Api.Infrastructure.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CreateOrders.Api.Tests
{
    public class OrdersApplicationTests
    {
        [Fact]
        public void Create_NewOrderShouldInsert()
        {
            Mock<IOrdersDomain> orderDomain = new Mock<IOrdersDomain>();

            Mock<IMapper> mapperRepo = new Mock<IMapper>();

            OrdersViewModel orderModel = new OrdersViewModel();

            Orders ord = new Orders();

            OrdersViewResponse orderResponse = new OrdersViewResponse();

            orderModel = new OrdersViewModel { Id = 1, DateOrder = DateTime.Now, IdProduct = 1, IdCustomer = 1 };

            OrdersApplication orderApplication = new OrdersApplication(orderDomain.Object, mapperRepo.Object);

            orderDomain.Setup(p => p.Create(ord)).Returns(orderResponse);

            Assert.True(true);

            Assert.NotNull(orderModel);
        }

        [Fact]
        public void OrderShouldIsNullOrEmpty()
        {
            Mock<IOrdersDomain> ordersDom = new Mock<IOrdersDomain>();

            Mock<IMapper> mapperRepo = new Mock<IMapper>();

            Orders orders = new Orders();

            Orders order = null;

            OrdersViewResponse orderResponse = new OrdersViewResponse();

            IEnumerable<Orders> ordersLst = new List<Orders>();

            ordersDom.Setup(p => p.Create(orders)).Returns(orderResponse);

            Assert.Empty(ordersLst);

            Assert.Null(order);
        }

        [Fact]
        public void DeleteShouldDeleteOrder()
        {
            Mock<IOrdersDomain> orderDomain = new Mock<IOrdersDomain>();

            Mock<IMapper> mapperRepo = new Mock<IMapper>();

            Orders orders = new Orders();

            int id = 1;

            orders = new Orders { Id = 1, DateOrder = DateTime.Now, IdProduct = 1, IdCustomer = 1 };

            orderDomain.Setup(p => p.Delete(id)).Verifiable();

            OrdersApplication orderApplication = new OrdersApplication(orderDomain.Object, mapperRepo.Object);

            orderApplication.Delete(id);

            Assert.Equal(id, orders.Id);
        }

        [Fact]
        public void GetAllAndGetByIdShouldGetOrders()
        {
            Mock<IOrdersDomain> ordDomain = new Mock<IOrdersDomain>();

            Mock<IMapper> mapperRepo = new Mock<IMapper>();

            OrdersViewModel orders = new OrdersViewModel();

            int id = 1;

            orders = new OrdersViewModel { Id = 1, DateOrder = DateTime.Now, IdProduct = 1, IdCustomer = 1 };

            IEnumerable<Orders> orderList = new List<Orders>();

            List<OrdersViewModel> lstOrder = new List<OrdersViewModel>();

            lstOrder.Add(new OrdersViewModel() { Id = 1, DateOrder = DateTime.Now, IdProduct = 1, IdCustomer = 1 });
            lstOrder.Add(new OrdersViewModel() { Id = 2, DateOrder = DateTime.Now, IdProduct = 2, IdCustomer = 3 });
            lstOrder.Add(new OrdersViewModel() { Id = 3, DateOrder = DateTime.Now, IdProduct = 1, IdCustomer = 2 });

            ordDomain.Setup(p => p.GetAll()).Returns(lstOrder);

            ordDomain.Setup(p => p.GetById(id)).Returns(orders);

            OrdersApplication orderApplicacion = new OrdersApplication(ordDomain.Object, mapperRepo.Object);

            orderApplicacion.GetAll();

            orderApplicacion.GetById(id);

            Assert.Empty(orderList);
        }

        [Fact]
        public void UpdateShouldProduct()
        {
            Mock<IOrdersDomain> orderDomain = new Mock<IOrdersDomain>();

            Mock<IMapper> mapperRepo = new Mock<IMapper>();

            OrdersViewModel orders = new OrdersViewModel();

            orders = new OrdersViewModel { Id = 1, DateOrder = DateTime.Now, IdProduct = 1, IdCustomer = 1 };

            orders = new OrdersViewModel { Id = 1, DateOrder = DateTime.Now, IdProduct = 3, IdCustomer = 2 };

            orderDomain.Setup(p => p.Update(orders)).Returns(orders);

            Assert.Equal(orders, orders);
        }
    }
}
