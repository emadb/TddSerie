using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CodicePlastico.TddSerie.Core
{
    public class ShoppingCart
    {
        private readonly IPriceListService _priceListService;
        private readonly List<CartItem> _items;

        public IEnumerable<CartItem> Items
        {
            get { return new ReadOnlyCollection<CartItem>(_items); }
        }

        public int ItemCount { get { return _items.Count; } }
        public decimal Total { get; private set; }

        public ShoppingCart(IPriceListService priceListService)
        {
            _priceListService = priceListService;
            _items = new List<CartItem>();
        }

        public void AddItem(int itemId)
        {
            CartItem item = _items.SingleOrDefault(i => i.Id == itemId);
            if (item != null)
            {
                item.AddOne();
            }
            else
            {
                _items.Add(new CartItem(itemId));
            }
            //Total += _priceListService.GetCurrentPriceFor(itemId);
        }
    }
}