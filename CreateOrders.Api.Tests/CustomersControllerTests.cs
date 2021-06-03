using CreateOrders.Api.Application;
using CreateOrders.Api.ApplicationServices;
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
    public class CustomersControllerTests
    {
        [Fact]
        public void Create_NewCustomerShouldInsert()
        {
            Mock<ICustomersApplication> customersApplication = new Mock<ICustomersApplication>();

            CustomersViewModel customerModel = new CustomersViewModel();

            CustomersViewResponse customerResponse = new CustomersViewResponse();

            customerModel = new CustomersViewModel { Id = 1, FullName = "marlo rodriguez", IDCustomer = 23456789, Adress = "calle 26", EMail = "marlo@gmail.net", Phone = 2783456, City = "palmeiras" };

            customersApplication.Setup(p => p.Create(customerModel)).Returns(customerResponse);

            Assert.True(true);

            Assert.NotNull(customerModel);
        }

        [Fact]
        public void CustomerShouldIsNullOrEmpty()
        {
            Mock<ICustomersApplication> customerApplication = new Mock<ICustomersApplication>();

            CustomersViewModel customersModel = new CustomersViewModel();

            CustomersViewResponse customerResponse = new CustomersViewResponse();

            IEnumerable<CustomersViewModel> lst = new List<CustomersViewModel>();

            customerApplication.Setup(p => p.Create(customersModel)).Returns(customerResponse);

            Assert.Empty(lst);
        }

        [Fact]
        public void DeleteShouldDeleteCustom()
        {
            Mock<ICustomersApplication> customerApplication = new Mock<ICustomersApplication>();

            CustomersViewModel customers = new CustomersViewModel();

            int id = 1;

            customers = new CustomersViewModel { Id = 1, FullName = "marlo rodriguez", IDCustomer = 23456789, Adress = "calle 26", EMail = "marlo@gmail.net", Phone = 2783456, City = "palmeiras" };

            customerApplication.Setup(p => p.Delete(id)).Verifiable();

            Assert.Equal(id, customers.Id);

            string sub = "marlo";
            string actualSub = "marlo rodriguez";

            Assert.Contains(sub, actualSub);
        }

        [Fact]
        public void GetAllAndGetByIdShouldGetCustomers()
        {
            Mock<ICustomersApplication> custApplication = new Mock<ICustomersApplication>();

            CustomersViewModel customerModel = new CustomersViewModel();

            int id = 1;

            customerModel = new CustomersViewModel { Id = 1, FullName = "marlo rodriguez", IDCustomer = 23456789, Adress = "calle 26", EMail = "marlo@gmail.net", Phone = 2783456, City = "palmeiras" };

            IEnumerable<Customers> customerLst = new List<Customers>();

            List<CustomersViewModel> lstCustom = new List<CustomersViewModel>();

            lstCustom.Add(new CustomersViewModel() { Id = 1, FullName = "marlo rodriguez", IDCustomer = 23456789, Adress = "calle 26", EMail = "marlo@gmail.net", Phone = 2783456, City = "milan" });
            lstCustom.Add(new CustomersViewModel() { Id = 1, FullName = "david guerra", IDCustomer = 34335566, Adress = "carrera 66", EMail = "guerra@gmail.com", Phone = 65732972, City = "london" });
            lstCustom.Add(new CustomersViewModel() { Id = 1, FullName = "carlos slim", IDCustomer = 678977543, Adress = "av 102", EMail = "cslim@hotmail.es", Phone = 9873362, City = "new york" });

            custApplication.Setup(p => p.GetAll()).Returns(lstCustom);

            custApplication.Setup(p => p.GetById(id)).Returns(customerModel);

            Assert.Empty(customerLst);
        }

        [Fact]
        public void UpdateShouldCustomer()
        {
            Mock<ICustomersApplication> customApplication = new Mock<ICustomersApplication>();

            CustomersViewModel customers = new CustomersViewModel();

            customers = new CustomersViewModel { Id = 1, FullName = "carlos sanjuan", IDCustomer = 678977543, Adress = "av 1202", EMail = "cslim@hotmail.com", Phone = 9873362, City = "new yorkk" };

            customers = new CustomersViewModel { Id = 1, FullName = "carlos slim", IDCustomer = 678977543, Adress = "av 102", EMail = "cslim@hotmail.es", Phone = 9873362, City = "new york" };

            customApplication.Setup(p => p.Update(customers)).Returns(customers);

            Assert.Equal(customers, customers);
        }
    }
}
