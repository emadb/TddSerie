using System;

namespace CodicePlastico.TddSerie.Core
{
    public class CartItem
    {
        public int Id { get; private set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; private set; }
        
        public CartItem(int id, decimal unitPrice)
        {
            Id = id;
            UnitPrice = unitPrice;
            Quantity = 1;
        }

        public void AddOne()
        {
            Quantity++;
        }
    }
}