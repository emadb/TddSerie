using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
            if (!_items.Contains(itemId))
                _items.Add(itemId);
        }
    }
}