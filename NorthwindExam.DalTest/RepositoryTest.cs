using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthwindExam.Dal;
using NorthwindExam.Entities;

namespace NorthwindExam.DalTest
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public void GetAllOrders_TheLengthOfTheListShouldBeGreatherThatZero()
        {
            //Arrange
            int expectedOver = 0;
            int actual;
            Repository repository = new Repository();

            //Act
            actual = repository.GetAllOrders().Count;

            //Assert
            Assert.IsTrue(actual > expectedOver);
        }

        [TestMethod]
        public void GetAllInvoices_TheLengthOfTheListShouldBeGreatherThatZero()
        {
            //Arrange
            int expectedOver = 0;
            int actual;
            Repository repository = new Repository();
            List<Order> orders = repository.GetAllOrders();

            //Act
            actual = repository.GetInvoicesById(orders[0].OrderID).Count; //This order has 3 invoices

            //Assert
            Assert.IsTrue(actual > expectedOver);
        }
    }
}
