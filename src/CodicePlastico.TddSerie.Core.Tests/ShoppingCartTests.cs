using Xunit;

namespace CodicePlastico.TddSerie.Core.Tests
{
    public class ShoppingCartTests
    {
        [Fact]
        public void AddArticle_TheArticleIsNotYetInTheBasket_ShouldAddItToTheBasket()
        {
            var cart = new ShoppingCart();
            cart.AddItem(99);

            Assert.Equal(1, cart.ItemCount);
        }
    }
}