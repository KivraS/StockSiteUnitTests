namespace StockSite.BusinessLogic.StockBuy
{
    public class StockPurchaseHandler
    {
        public bool BuyStock(decimal amount, int StockId,string? username)
        {
            if (amount <= 0 || StockId <= 0 || String.IsNullOrWhiteSpace(username))
                throw new InvalidOperationException();
            var _userDataProvider = new UserDataProvider();
            var balance = _userDataProvider.GetBalance(username);
            var tax = TaxCalculator.CalculateTax(amount, username);
            var total = tax + amount;
            
            if (balance >= total)
            {
                _userDataProvider.WithdrawMoney(total, username);
                var stockMarketService = new StockMarketService();
                stockMarketService.ReserveNewStock(username, StockId);
                return true;
            }
            return false;
        }
    }
}
