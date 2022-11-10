namespace StockSite.BusinessLogic.StockBuy
{
    public class StockPurchaseHandler
    {
        private IUserDataProvider _userDataProvider;
        private ITaxCalculator _taxCalculator;
        private IStockMarketService _stockMarketService;

        public StockPurchaseHandler(IUserDataProvider userDataProvider, ITaxCalculator taxCalculator, IStockMarketService stockMarketService)
        {
            _userDataProvider = userDataProvider;
            _taxCalculator = taxCalculator;
            _stockMarketService = stockMarketService;
        }

        public bool BuyStock(decimal amount, int StockId,string? username)
        {
            if (amount <= 0 || StockId <= 0 || String.IsNullOrWhiteSpace(username))
                throw new InvalidOperationException();
            var balance = _userDataProvider.GetBalance(username);
            var tax = _taxCalculator.CalculateTax(amount, username);
            var total = tax + amount;
            
            if (balance >= total)
            {
                _userDataProvider.WithdrawMoney(total, username);
                _stockMarketService.ReserveNewStock(username, StockId);
                return true;
            }
            return false;
        }
    }
}
