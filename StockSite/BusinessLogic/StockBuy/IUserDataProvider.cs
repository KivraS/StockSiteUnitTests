namespace StockSite.BusinessLogic.StockBuy
{
    public interface IUserDataProvider
    {
        decimal GetBalance(string username);
        string GetUserCountry(string username);
        bool WithdrawMoney(decimal amount, string username);
    }
}