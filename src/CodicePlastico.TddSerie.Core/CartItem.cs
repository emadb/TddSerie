using System;

namespace CodicePlastico.TddSerie.Core
{
    public class CartItem
    {
        public int Id { get; private set; }
        public int Quantity { get; private set; }

        public CartItem(int id)
        {
            Id = id;
            Quantity = 1;
        }

        public void AddOne()
        {
            Quantity++;
        }
    }
}