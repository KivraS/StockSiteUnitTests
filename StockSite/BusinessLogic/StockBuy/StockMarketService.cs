namespace StockSite.BusinessLogic.StockBuy
{
    public class StockMarketService
    {
        public readonly static Dictionary<int, string> Stocks = new Dictionary<int, string> 
        {
            {1,"Tesla"},
            {2,"Facebook"},
            {3,"Amazon"},
            {4,"Microsoft"},
        };
        public string GetStockDetailsById(int id)
        {
            return StockMarketService.Stocks[id];
            //throw new Exception("Connection error stock market is down");
        }
        public bool ReserveNewStock(string userName, int stockId)
        {
            //throw new Exception("Connection error");
            RiskNotifier.NotifyStockPlaced(userName, stockId);
            return true;
        }
    }
}
