using System;
using System.Collections.Generic;

namespace CodicePlastico.TddSerie.Core
{
    public class Basket
    {
        private readonly List<Product> _products;

        public Basket()
        {
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            if (Contains(product))
                throw new InvalidOperationException(product  + " is already in the basket");
            _products.Add(product);
        }

        public bool Contains(Product product)
        {
            return _products.Contains(product);
        }
    }
}