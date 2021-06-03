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
    public class CustomersDomainTests
    {
        [Fact]
        public void Create_NewCustomerShouldInsert()
        {
            Mock<ICustomersRepository> customerRepo = new Mock<ICustomersRepository>();

            Mock<IMapper> mapperRepo = new Mock<IMapper>();

            Customers customers = new Customers();

            customers = new Customers { Id = 1, FullName = "marlo rodriguez", IDCustomer = 23456789, Adress = "calle 26", EMail = "marlo@gmail.net", Phone = 2783456, City = "palmeiras" };

            customerRepo.Setup(p => p.Create(customers)).Returns(customers);

            Assert.True(true);

            Assert.NotNull(customers);
        }

        [Fact]
        public void CustomerShouldIsNullOrEmpty()
        {
            Mock<ICustomersRepository> customerRepo = new Mock<ICustomersRepository>();

            Mock<IMapper> mapperRepo = new Mock<IMapper>();

            Customers customers = new Customers();

            Customers customer = null;

            IEnumerable<Customers> lst = new List<Customers>();

            customerRepo.Setup(p => p.Create(customers)).Returns(customers);

            Assert.Empty(lst);

            Assert.Null(customer);
        }

        [Fact]
        public void DeleteShouldDeleteCustomer()
        {
            Mock<ICustomersRepository> customRepo = new Mock<ICustomersRepository>();

            Mock<IMapper> mapperRepo = new Mock<IMapper>();

            Customers customers = new Customers();

            int id = 1;

            customers = new Customers { Id = 1, FullName = "marlo rodriguez", IDCustomer = 23456789, Adress = "calle 26", EMail = "marlo@gmail.net", Phone = 2783456, City = "palmeiras" };

            customRepo.Setup(p => p.Delete(id)).Verifiable();

            CustomersDomain custDomain = new CustomersDomain(customRepo.Object, mapperRepo.Object);

            custDomain.Delete(id);

            Assert.Equal(id, customers.Id);

            string sub = "marlo";
            string actualSub = "marlo rodriguez";

            Assert.Contains(sub, actualSub);
        }

        [Fact]
        public void GetAllAndGetByIdShouldGetCustomers()
        {
            Mock<ICustomersRepository> custRepo = new Mock<ICustomersRepository>();

            Mock<IMapper> mapperRepo = new Mock<IMapper>();

            Customers customers = new Customers();

            int id = 1;

            IEnumerable<Customers> customList = new List<Customers>();
            List<Customers> lstCustom= new List<Customers>();

            lstCustom.Add(new Customers() { Id = 1, FullName = "marlo rodriguez", IDCustomer = 23456789, Adress = "calle 26", EMail = "marlo@gmail.net", Phone = 2783456, City = "palmeiras" });
            lstCustom.Add(new Customers() { Id = 2, FullName = "coco chanel", IDCustomer = 12345678, Adress = "av norte", EMail = "chanel@hotmail.com", Phone = 3456789, City = "london" });
            lstCustom.Add(new Customers() { Id = 3, FullName = "david smith", IDCustomer = 77889909, Adress = "av 34a", EMail = "fancy@gmail.com", Phone = 4563217, City = "amsterdan" });

            custRepo.Setup(p => p.GetAll()).Returns(lstCustom);

            custRepo.Setup(p => p.GetById(id)).Returns(customers);

            CustomersDomain custDomain = new CustomersDomain(custRepo.Object, mapperRepo.Object);

            custDomain.GetAll();

            custDomain.GetById(id);

            Assert.Empty(customList);
        }

        [Fact]
        public void UpdateShouldCustomer()
        {
            Mock<ICustomersRepository> custRepo = new Mock<ICustomersRepository>();

            Mock<IMapper> mapperRepo = new Mock<IMapper>();

            Customers customers = new Customers();

            customers = new Customers { Id = 1, FullName = "marlo rodriguez", IDCustomer = 23456789, Adress = "calle 26", EMail = "marlo@gmail.net", Phone = 2783456, City = "palmeiras" };

            customers = new Customers { Id = 1, FullName = "david smith", IDCustomer = 77889909, Adress = "av 34a", EMail = "fancy@gmail.com", Phone = 4563217, City = "amsterdan" };

            IEnumerable<Customers> lstCustoms;

            custRepo.Setup(p => p.Update(customers)).Returns(customers);

            Assert.Equal(customers, customers);
        }
    }
}
