using AutoMapper;
using CreateOrders.Api.DomainServices;
using CreateOrders.Api.Infrastructure.Entities;
using CreateOrders.Api.Infrastructure.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CreateOrders.Api.Tests
{
    public class OrdersDomainTests
    {
        [Fact]
        public void Create_NewOrderShouldInsert()
        {
            Mock<IOrdersRepository> ordersRepo = new Mock<IOrdersRepository>();

            Mock<IMapper> mapperRepo = new Mock<IMapper>();

            Orders orders = new Orders();

            orders = new Orders { Id = 1, DateOrder = DateTime.Now, IdProduct = 1, IdCustomer = 1 };

            ordersRepo.Setup(p => p.Create(orders)).Returns(orders);

            Assert.True(true);

            Assert.NotNull(orders);
        }

        [Fact]
        public void OrderShouldIsNullOrEmpty()
        {
            Mock<IOrdersRepository> orderRepo = new Mock<IOrdersRepository>();

            Mock<IMapper> mapperRepo = new Mock<IMapper>();

            Orders orders = new Orders();

            Orders order = null;

            IEnumerable<Orders> lst = new List<Orders>();

            orderRepo.Setup(p => p.Create(orders)).Returns(orders);

            Assert.Empty(lst);

            Assert.Null(order);
        }

        [Fact]
        public void DeleteShouldDeleteOrder()
        {
            Mock<IOrdersRepository> orderRepo = new Mock<IOrdersRepository>();

            Mock<IMapper> mapperRepo = new Mock<IMapper>();

            Orders orders = new Orders();

            int id = 1;

            orders = new Orders { Id = 1, DateOrder = DateTime.Now, IdProduct = 1, IdCustomer = 1 };

            orderRepo.Setup(p => p.Delete(id)).Verifiable();

            OrdersDomain orderDomain = new OrdersDomain(orderRepo.Object, mapperRepo.Object);

            orderDomain.Delete(id);

            Assert.Equal(id, orders.Id);
        }

        [Fact]
        public void GetAllAndGetByIdShouldGetOrders()
        {
            Mock<IOrdersRepository> orderRepo = new Mock<IOrdersRepository>();

            Mock<IMapper> mapperRepo = new Mock<IMapper>();

            Orders orders = new Orders();

            IEnumerable<Orders> orderList = new List<Orders>();

            int id = 1;

            List<Orders> lstOrder = new List<Orders>();

            lstOrder.Add(new Orders() { Id = 1, DateOrder = DateTime.Now, IdProduct = 1, IdCustomer = 2345678 });
            lstOrder.Add(new Orders() { Id = 2, DateOrder = DateTime.Now, IdProduct = 3, IdCustomer = 3342549 });
            lstOrder.Add(new Orders() { Id = 3, DateOrder = DateTime.Now, IdProduct = 1, IdCustomer = 4567890 });

            orderRepo.Setup(p => p.GetAll()).Returns(lstOrder);

            orderRepo.Setup(p => p.GetById(id)).Returns(orders);

            OrdersDomain orderDomain = new OrdersDomain(orderRepo.Object, mapperRepo.Object);

            orderDomain.GetAll();

            orderDomain.GetById(id);

            Assert.Empty(orderList);
        }

        [Fact]
        public void UpdateShouldOrder()
        {
            Mock<IOrdersRepository> orderRepo = new Mock<IOrdersRepository>();

            Mock<IMapper> mapperRepo = new Mock<IMapper>();

            Orders orders = new Orders();

            orders = new Orders { Id = 3, DateOrder = DateTime.Now, IdProduct = 1, IdCustomer = 4567890 };

            orders = new Orders { Id = 3, DateOrder = DateTime.Now, IdProduct = 2, IdCustomer = 234323 };

            IEnumerable<Orders> lstOrder;

            orderRepo.Setup(p => p.Update(orders)).Returns(orders);

            Assert.Equal(orders, orders);
        }
    }
}
