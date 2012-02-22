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
            cart.AddItem(new CartItem{Id = 99});

            Assert.Equal(1, cart.ItemCount);
        }

        [Fact]
        public void AddSameItemTwice_TheItemCountShouldBe1()
        {
            var cart = new ShoppingCart();


            cart.AddItem(new CartItem { Id = 99 });
            cart.AddItem(new CartItem { Id = 99 });

            Assert.Equal(1, cart.ItemCount);
        }

        [Fact]
        public void AddSameItemTwice_TheItemQuantityShouldBe2()
        {
            var cart = new ShoppingCart();
            cart.AddItem(new CartItem { Id = 99 });
            cart.AddItem(new CartItem { Id = 99 });

            Assert.Equal(2, cart.Items.ElementAt(0).Quantity);
        }
    }
}