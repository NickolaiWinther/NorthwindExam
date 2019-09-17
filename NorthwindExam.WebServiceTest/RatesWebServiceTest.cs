using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthwindExam.WebService;

namespace NorthwindExam.WebServiceTest
{
    [TestClass]
    public class RatesWebServiceTest
    {
        [TestMethod]
        public void GetRates_ReturnTrueIfValidUrl()
        {
            //Arrange
            bool expected = true;
            bool actual;
            RatesWebService ratesWebService = new RatesWebService();

            //Act
            actual = ratesWebService.GetRates().isValid;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetRates_ReturnFalseIfInvalidUrl()
        {
            //Arrange
            bool expected = false;
            bool actual;
            RatesWebService ratesWebService = new RatesWebService();

            //Act
            actual = ratesWebService.GetRates("invalidUrl").isValid;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
