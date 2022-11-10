using Moq;
using StockSite.BusinessLogic.StockBuy;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSite.Tests.BusinessLogic.StockBuy
{
    public class TaxCalculatorTests
    {
        [Theory]
        [InlineData("gr", 10, 1)]
        [InlineData("ro", 10, 2)]
        [InlineData("cy", 10, 3)]
        [InlineData("gr", 100, 20)]
        [InlineData("ro", 100, 40)]
        [InlineData("cy", 100, 60)]
        public void TestTaxationByCountry(string country, decimal amount, decimal expectedTax)
        {
            //Arange
            var userDataProviderMock = new Mock<IUserDataProvider>();
            userDataProviderMock.Setup(d => d.GetUserCountry(It.IsAny<string>())).Returns(country);
            var taxCalculator = new TaxCalculator(userDataProviderMock.Object);
            //Act
            var calculatedTax = taxCalculator.CalculateTax(amount, "idontcare");
            //Assert
            Assert.Equal(expectedTax, calculatedTax);
        }
    }
}
