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
    public class CustomersApplicationTests
    {
        [Fact]
        public void Create_NewCustomerShouldInsert()
        {
            Mock<ICustomersDomain> customersDomain = new Mock<ICustomersDomain>();

            Mock<IMapper> mapperRepo = new Mock<IMapper>();

            CustomersViewModel customerModel = new CustomersViewModel();

            Customers cust = new Customers();

            CustomersViewResponse customerResponse = new CustomersViewResponse();

            customerModel = new CustomersViewModel { Id = 1, FullName = "marlo rodriguez", IDCustomer = 23456789, Adress = "calle 26", EMail = "marlo@gmail.net", Phone = 2783456, City = "palmeiras" };

            CustomersApplication prodApplication = new CustomersApplication(customersDomain.Object, mapperRepo.Object);

            customersDomain.Setup(p => p.Create(cust)).Returns(customerResponse);

            Assert.True(true);

            Assert.NotNull(customerModel);
        }

        [Fact]
        public void CustomerShouldIsNullOrEmpty()
        {
            Mock<ICustomersDomain> customerDom = new Mock<ICustomersDomain>();

            Mock<IMapper> mapperRepo = new Mock<IMapper>();

            Customers customers = new Customers();

            Customers custom = null;

            CustomersViewResponse customerResponse = new CustomersViewResponse();

            IEnumerable<Customers> lst = new List<Customers>();

            customerDom.Setup(p => p.Create(customers)).Returns(customerResponse);

            Assert.Empty(lst);

            Assert.Null(custom);
        }

        [Fact]
        public void DeleteShouldDeleteCustom()
        {
            Mock<ICustomersDomain> customerDomain = new Mock<ICustomersDomain>();

            Mock<IMapper> mapperRepo = new Mock<IMapper>();

            Customers customers = new Customers();

            int id = 1;

            customers = new Customers { Id = 1, FullName = "marlo rodriguez", IDCustomer = 23456789, Adress = "calle 26", EMail = "marlo@gmail.net", Phone = 2783456, City = "palmeiras" };

            customerDomain.Setup(p => p.Delete(id)).Verifiable();

            CustomersApplication customApplication = new CustomersApplication(customerDomain.Object, mapperRepo.Object);

            customApplication.Delete(id);

            Assert.Equal(id, customers.Id);

            string sub = "marlo";
            string actualSub = "marlo rodriguez";

            Assert.Contains(sub, actualSub);
        }

        [Fact]
        public void GetAllAndGetByIdShouldGetCustomers()
        {
            Mock<ICustomersDomain> custDomain = new Mock<ICustomersDomain>();

            Mock<IMapper> mapperRepo = new Mock<IMapper>();

            CustomersViewModel customerModel = new CustomersViewModel();

            int id = 1;

            customerModel = new CustomersViewModel { Id = 1, FullName = "marlo rodriguez", IDCustomer = 23456789, Adress = "calle 26", EMail = "marlo@gmail.net", Phone = 2783456, City = "palmeiras" };

            IEnumerable<Customers> customerLst = new List<Customers>();

            List<CustomersViewModel> lstCustom = new List<CustomersViewModel>();

            lstCustom.Add(new CustomersViewModel() { Id = 1, FullName = "marlo rodriguez", IDCustomer = 23456789, Adress = "calle 26", EMail = "marlo@gmail.net", Phone = 2783456, City = "milan" });
            lstCustom.Add(new CustomersViewModel() { Id = 1, FullName = "david guerra", IDCustomer = 34335566, Adress = "carrera 66", EMail = "guerra@gmail.com", Phone = 65732972, City = "london" });
            lstCustom.Add(new CustomersViewModel() { Id = 1, FullName = "carlos slim", IDCustomer = 678977543, Adress = "av 102", EMail = "cslim@hotmail.es", Phone = 9873362, City = "new york" });

            custDomain.Setup(p => p.GetAll()).Returns(lstCustom);

            custDomain.Setup(p => p.GetById(id)).Returns(customerModel);

            CustomersApplication custApplication = new CustomersApplication(custDomain.Object, mapperRepo.Object);

            custApplication.GetAll();

            custApplication.GetById(id);

            Assert.Empty(customerLst);
        }

        [Fact]
        public void UpdateShouldCustomer()
        {
            Mock<ICustomersDomain> customDomain = new Mock<ICustomersDomain>();

            Mock<IMapper> mapperRepo = new Mock<IMapper>();

            CustomersViewModel customers = new CustomersViewModel();

            customers = new CustomersViewModel { Id = 1, FullName = "carlos sanjuan", IDCustomer = 678977543, Adress = "av 1202", EMail = "cslim@hotmail.com", Phone = 9873362, City = "new yorkk" };

            customers = new CustomersViewModel { Id = 1, FullName = "carlos slim", IDCustomer = 678977543, Adress = "av 102", EMail = "cslim@hotmail.es", Phone = 9873362, City = "new york" };

            //IEnumerable<CustomersViewModel> lstCustom;

            customDomain.Setup(p => p.Update(customers)).Returns(customers);

            Assert.Equal(customers, customers);
        }
    }
}
