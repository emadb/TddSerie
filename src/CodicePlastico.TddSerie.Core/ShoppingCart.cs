using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CodicePlastico.TddSerie.Core
{
    public class ShoppingCart
    {
        private readonly List<CartItem> _items;

        public ShoppingCart()
        {
            _items = new List<CartItem>();
        }

        public IEnumerable<CartItem> Items
        {
            get { return new ReadOnlyCollection<CartItem>(_items); }
        }

        public int ItemCount { get { return _items.Count; } }

        public void AddItem(int itemId)
        {
            CartItem item = _items.SingleOrDefault(i => i.Id == itemId);
            if (item != null)
            {
                item.Quantity++;
            }
            else
            {
                item = new CartItem(itemId);
                item.Quantity = 1;
                _items.Add(item);
            }
        }
    }
}