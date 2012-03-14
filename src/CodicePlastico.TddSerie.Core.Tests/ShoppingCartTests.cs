using System.Linq;
using Xunit;
using Moq;

namespace CodicePlastico.TddSerie.Core.Tests
{
    public class ShoppingCartTests
    {
        [Fact]
        public void AddItem_TheItemIsNotYetInTheBasket_ShouldAddItToTheBasket()
        {
            var priceListService = new Mock<IPriceListService>();
            var cart = new ShoppingCart(priceListService.Object);

            cart.AddItem(99);

            Assert.Equal(1, cart.ItemCount);
        }

        [Fact]
        public void AddSameItemTwice_TheItemCountShouldBe1()
        {
            var priceListService = new Mock<IPriceListService>();
            var cart = new ShoppingCart(priceListService.Object);

            cart.AddItem(99);
            cart.AddItem(99);

            Assert.Equal(1, cart.ItemCount);
        }

        [Fact]
        public void AddSameItemTwice_TheItemQuantityShouldBe2()
        {
            var priceListService = new Mock<IPriceListService>();
            var cart = new ShoppingCart(priceListService.Object);

            cart.AddItem(99);
            cart.AddItem(99);

            Assert.Equal(2, cart.Items.ElementAt(0).Quantity);
        }
		
		[Fact]
        public void GetTotal_OneItem_ShouldAskToPriceListServiceTheItemPrice()
        {
			var priceListService = new Mock<IPriceListService>();
            var cart = new ShoppingCart(priceListService.Object);
            
			cart.AddItem(99);
            
			priceListService.Verify(p => p.GetCurrentPriceFor(99));
        }
		
		[Fact]
        public void GetTotal_TwoDifferentItems_ShouldReturnTheSum()
        {
			var priceListService = new Mock<IPriceListService>();
			priceListService.Setup(p => p.GetCurrentPriceFor(99)).Returns(100m);
			priceListService.Setup(p => p.GetCurrentPriceFor(98)).Returns(50m);
            
			var cart = new ShoppingCart(priceListService.Object);
            
			cart.AddItem(99);
			cart.AddItem(98);
            
			Assert.Equal(150m, cart.Total);
        }
    }
}