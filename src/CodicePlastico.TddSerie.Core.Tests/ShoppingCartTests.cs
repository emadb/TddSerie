using System.Linq;
using Xunit;
using Moq;

namespace CodicePlastico.TddSerie.Core.Tests
{
    public class ShoppingCartTests
    {
        private Mock<IPriceListService> _priceListService;
        private ShoppingCart _cart;

        public ShoppingCartTests()
        {
            _priceListService = new Mock<IPriceListService>();
            _cart = new ShoppingCart(_priceListService.Object);
        }

        [Fact]
        public void AddItem_TheItemIsNotYetInTheBasket_ShouldAddItToTheBasket()
        {
            _cart.AddItem(99);

            Assert.Equal(1, _cart.ItemCount);
        }

        [Fact]
        public void AddSameItemTwice_TheItemCountShouldBe1()
        {
            _cart.AddItem(99);
            _cart.AddItem(99);

            Assert.Equal(1, _cart.ItemCount);
        }

        [Fact]
        public void AddSameItemTwice_TheItemQuantityShouldBe2()
        {
            _cart.AddItem(99);
            _cart.AddItem(99);

            Assert.Equal(2, _cart.Items.ElementAt(0).Quantity);
        }
		
		[Fact]
        public void GetTotal_OneItem_ShouldAskToPriceListServiceTheItemPrice()
        {
			_cart.AddItem(99);
			_priceListService.Verify(p => p.GetCurrentPriceFor(99));
        }

        [Fact]
        public void GetTotal_OneItem_ShouldSetTheTotalValue()
        {
            _priceListService.Setup(p => p.GetCurrentPriceFor(99)).Returns(100m);
            _cart.AddItem(99);

            Assert.Equal(100m, _cart.Total);
        }
		

		[Fact]
        public void GetTotal_TwoDifferentItems_ShouldReturnTheSum()
        {
			_priceListService.Setup(p => p.GetCurrentPriceFor(99)).Returns(100m);
			_priceListService.Setup(p => p.GetCurrentPriceFor(98)).Returns(50m);
            
			_cart.AddItem(99);
			_cart.AddItem(98);
            
			Assert.Equal(150m, _cart.Total);
        }

        [Fact]
        public void GetTotal_SameItemTwice_ShouldReturnTheSum()
        {
            _priceListService.Setup(p => p.GetCurrentPriceFor(99)).Returns(100m);
            
            _cart.AddItem(99);
            _cart.AddItem(99);

            Assert.Equal(200m, _cart.Total);
        }

        [Fact]
        public void ApplyCoupon_TotalPriceShouldBeDiscointedOf10Percent()
        {
            _priceListService.Setup(p => p.GetCurrentPriceFor(99)).Returns(150m);
            _priceListService.Setup(p => p.GetDiscountFor("SCONTO10")).Returns(0.10m);
            _cart.AddItem(99);
            
            _cart.ApplyCoupon("SCONTO10");

            Assert.Equal(135m, _cart.Total);
        }
    }
}