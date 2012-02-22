using System;

namespace CodicePlastico.TddSerie.Core
{
    public class CartItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) 
                return false;
            if (ReferenceEquals(this, obj)) 
                return true;
            if (obj.GetType() != typeof (CartItem)) 
                return false;
            return Equals((CartItem) obj);
        }

        public bool Equals(CartItem other)
        {
            if (ReferenceEquals(null, other)) 
                return false;
            if (ReferenceEquals(this, other)) 
                return true;
            return other.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}