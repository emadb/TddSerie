using System.Linq;
using Xunit;

namespace CodicePlastico.TddSerie.Core.Tests
{
    public class ShoppingCartTests
    {
        [Fact]
        public void AddItem_TheItemIsNotYetInTheBasket_ShouldAddItToTheBasket()
        {
            var cart = new ShoppingCart();
            cart.AddItem(99);

            Assert.Equal(1, cart.ItemCount);
        }

        [Fact]
        public void AddSameItemTwice_TheItemCountShouldBe1()
        {
            var cart = new ShoppingCart();
            cart.AddItem(99);
            cart.AddItem(99);

            Assert.Equal(1, cart.ItemCount);
        }
    }
}