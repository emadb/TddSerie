namespace CodicePlastico.TddSerie.Core
{
    public interface IPriceListService
    {
        decimal GetCurrentPriceFor(int itemId);
        decimal GetDiscountFor(string coupon);
    }
}
