using StockSite.BusinessLogic.StockBuy;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;

namespace StockSite.Tests.BusinessLogic.StockBuy
{
    public class StockPurchaseHandlerTests
    {
        [Fact]
        public void UserBuysStockWithNotEnoughMoneyShouldFailAndNotPerformActions()
        {
            //Arange
            decimal taxToReturn = 100;
            decimal amountToPlace = 150;
            string username = "akivranoglou@gmail.com";
            int stockId = 2;
            var userDataProviderMock = new Mock<IUserDataProvider>();
            userDataProviderMock.Setup(m => m.GetBalance(It.IsAny<string>())).Returns(200);
            var taxCalculatorMock = new Mock<ITaxCalculator>();
            taxCalculatorMock.Setup(m => m.CalculateTax(It.IsAny<decimal>(), It.IsAny<string>())).Returns(taxToReturn);
            var stockMarketServiceMock = new Mock<IStockMarketService>();
            var handler = new StockPurchaseHandler(userDataProviderMock.Object,taxCalculatorMock.Object,stockMarketServiceMock.Object);
            //Act
            var result = handler.BuyStock(amountToPlace, stockId, username);
            //Assert
            Assert.False(result);
            userDataProviderMock.Verify(m => m.WithdrawMoney(170, username), Times.Never);
            stockMarketServiceMock.Verify(m => m.ReserveNewStock(username, stockId), Times.Never);
        }

        [Fact]
        public void UserBuysStockWithEnoughMoneyShouldPassAndPerformActions()
        {
            //Arange
            decimal taxToReturn = 20;
            decimal amountToPlace = 150;
            string username = "akivranoglou@gmail.com";
            int stockId = 2;
            var userDataProviderMock = new Mock<IUserDataProvider>();
            userDataProviderMock.Setup(m => m.GetBalance(It.IsAny<string>())).Returns(200);
            var taxCalculatorMock = new Mock<ITaxCalculator>();
            taxCalculatorMock.Setup(m => m.CalculateTax(It.IsAny<decimal>(), It.IsAny<string>())).Returns(taxToReturn);
            var stockMarketServiceMock = new Mock<IStockMarketService>();
            var handler = new StockPurchaseHandler(userDataProviderMock.Object, taxCalculatorMock.Object, stockMarketServiceMock.Object);
            //Act
            var result = handler.BuyStock(amountToPlace, stockId, username);
            //Assert
            Assert.True(result);
            userDataProviderMock.Verify(m => m.WithdrawMoney(170, username),Times.Once);
            stockMarketServiceMock.Verify(m => m.ReserveNewStock(username, stockId),Times.Once);
        }
        [Theory]
        [InlineData(-10,2,"anestis")]
        [InlineData(2, -1, "anestis")]
        [InlineData(2, 1, "")]
        public void UserBuysStockWithInvalidParamsShouldThrowException(decimal amount,int stockId,string? username)
        {
            //Arange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var purchaseHandler = fixture.Create<StockPurchaseHandler>();
            //Act && Assert
            Assert.Throws<InvalidOperationException>(() => purchaseHandler.BuyStock(amount,stockId,username));
        }
    }
}
