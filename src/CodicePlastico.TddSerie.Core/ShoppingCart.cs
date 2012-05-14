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

        public decimal ShipmentCost { get; private set; }

        public ShoppingCart(IPriceListService priceListService, IShippingService shippingService)
        {
            _priceListService = priceListService;
            _items = new List<CartItem>();
        }

        public void AddItem(int itemId)
        {
            var item = _items.SingleOrDefault(i => i.Id == itemId);
            var unitPrice = _priceListService.GetCurrentPriceFor(itemId);
            if (item != null)
            {
                item.AddOne();
            }
            else
            {
               _items.Add(new CartItem(itemId, unitPrice));
            }
            Total += unitPrice;
        }

        public void ApplyCoupon(string coupon)
        {
            var discount = _priceListService.GetDiscountFor(coupon);
            Total -= Total * discount;
        }

        public void RemoveOneItem(int itemId)
        {
            var cartItem = _items.Single(i => i.Id == itemId);
            
            if (cartItem.Quantity == 1)
            {
                _items.Remove(cartItem);
            }
            else
            {
                cartItem.RemoveOne();
            }
            
            Total -= cartItem.UnitPrice;
            
        }

        public void SetShipAddress(string address, string city, string zipCode, string country)
        {
        }
    }
}