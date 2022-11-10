namespace StockSite.BusinessLogic.StockBuy
{
    public interface IStockMarketService
    {
        string GetStockDetailsById(int id);
        bool ReserveNewStock(string userName, int stockId);
    }
}