using System;
using Xunit;

namespace CodicePlastico.TddSerie.Core.Tests
{
    public class BasketTests
    {
        [Fact]
        public void AddArticle_TheArticleIsNotYetInTheBasket_ShouldAddItToTheBasket()
        {
            var newProduct = new Product();
            var basket = new Basket();
            basket.AddProduct(newProduct);

            Assert.True(basket.Contains(newProduct));
        }

        [Fact]
        public void AddArticle_ArticleIsAlreadyInTheBasket_ShouldThrowAnExceptio()
        {
            var newProduct = new Product();
            var basket = new Basket();
            basket.AddProduct(newProduct);
            Assert.Throws<InvalidOperationException>(() => basket.AddProduct(newProduct));
        }
    }
}