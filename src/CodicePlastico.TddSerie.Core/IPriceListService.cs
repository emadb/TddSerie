namespace CodicePlastico.TddSerie.Core
{
    public interface IPriceListService
    {
        decimal GetCurrentPriceFor(int itemId);
        decimal GetDiscountFor(string coupon);
    }

    public interface IShippingService
    {
        decimal GetCostsFor(string adrdress, string city, string zipCode, string country);
    }
}
