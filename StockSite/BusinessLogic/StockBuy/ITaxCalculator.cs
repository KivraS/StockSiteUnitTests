namespace StockSite.BusinessLogic.StockBuy
{
    public interface ITaxCalculator
    {
        decimal CalculateTax(decimal amount, string username);
    }
}