namespace StockSite.BusinessLogic.StockBuy
{
    public class RiskNotifier
    {
        public static void NotifyStockPlaced(string username, int StockId)
        {
            StockMarketService service = new StockMarketService();
            var details = service.GetStockDetailsById(StockId);
            string msg = $"{username} Stock on {details}";
            Console.WriteLine(msg);
        }
    }
}
