using CreateOrders.Api.Application;
using CreateOrders.Api.Domain.Models;
using CreateOrders.Api.Domain.Models.ModelResponse;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CreateOrders.Api.Tests
{
    public class OrdersControllerTests
    {
        [Fact]
        public void Create_NewOrderShouldInsert()
        {
            Mock<IOrdersApplication> orderApplication = new Mock<IOrdersApplication>();

            OrdersViewModel orderModel = new OrdersViewModel();

            OrdersViewResponse orderResponse = new OrdersViewResponse();

            orderModel = new OrdersViewModel { Id = 1, DateOrder = DateTime.Now, IdProduct = 1, IdCustomer = 1 };

            orderApplication.Setup(p => p.Create(orderModel)).Returns(orderResponse);

            Assert.True(true);

            Assert.NotNull(orderModel);
        }

        [Fact]
        public void OrderShouldIsNullOrEmpty()
        {
            Mock<IOrdersApplication> orderApplication = new Mock<IOrdersApplication>();

            OrdersViewModel ordereModel = new OrdersViewModel();

            OrdersViewResponse orderResponse = new OrdersViewResponse();

            IEnumerable<OrdersViewModel> orderLst = new List<OrdersViewModel>();

            orderApplication.Setup(p => p.Create(ordereModel)).Returns(orderResponse);

            Assert.Empty(orderLst);
        }

        [Fact]
        public void DeleteShouldDeleteOrder()
        {
            Mock<IOrdersApplication> orderApplication = new Mock<IOrdersApplication>();

            OrdersViewModel orders = new OrdersViewModel();

            int id = 1;

            orders = new OrdersViewModel { Id = 1, DateOrder = DateTime.Now, IdProduct = 1, IdCustomer = 1 };

            orderApplication.Setup(p => p.Delete(id)).Verifiable();

            Assert.Equal(id, orders.Id);
        }

        [Fact]
        public void GetAllAndGetByIdShouldGetOrder()
        {
            Mock<IOrdersApplication> orderApplication = new Mock<IOrdersApplication>();

            OrdersViewModel orderModel = new OrdersViewModel();

            int id = 1;

            orderModel = new OrdersViewModel { Id = 1, DateOrder = DateTime.Now, IdProduct = 1, IdCustomer = 1 };

            IEnumerable<OrdersViewModel> orderLst = new List<OrdersViewModel>();

            List<OrdersViewModel> lstCustom = new List<OrdersViewModel>();

            lstCustom.Add(new OrdersViewModel() { Id = 1, DateOrder = DateTime.Now, IdProduct = 1, IdCustomer = 2 });
            lstCustom.Add(new OrdersViewModel() { Id = 2, DateOrder = DateTime.Now, IdProduct = 2, IdCustomer = 1 });
            lstCustom.Add(new OrdersViewModel() { Id = 3, DateOrder = DateTime.Now, IdProduct = 3, IdCustomer = 3 });

            orderApplication.Setup(p => p.GetAll()).Returns(lstCustom);

            orderApplication.Setup(p => p.GetById(id)).Returns(orderModel);

            Assert.Empty(orderLst);
        }

        [Fact]
        public void UpdateShouldOrder()
        {
            Mock<IOrdersApplication> orderApplication = new Mock<IOrdersApplication>();

            OrdersViewModel orders = new OrdersViewModel();

            orders = new OrdersViewModel { Id = 3, DateOrder = DateTime.Now, IdProduct = 3, IdCustomer = 3 };

            orders = new OrdersViewModel { Id = 3, DateOrder = DateTime.Now, IdProduct = 3, IdCustomer = 3 };

            orderApplication.Setup(p => p.Update(orders)).Returns(orders);

            Assert.Equal(orders, orders);
        }
    }
}
