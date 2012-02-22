using System;
using System.Collections.Generic;

namespace CodicePlastico.TddSerie.Core
{
    public class ShoppingCart
    {
        private readonly List<int> _items;

        public ShoppingCart()
        {
            _items = new List<int>();
        }

        public int ItemCount { get { return _items.Count; } }

        public void AddItem(int itemId)
        {
            _items.Add(itemId);
        }
    }
}