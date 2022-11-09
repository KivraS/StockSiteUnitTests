namespace StockSite.BusinessLogic.StockBuy
{
    public class UserDetails
    {
        public string Country { get; set; }
        public decimal Balance { get; set; }
        public UserDetails(string country,decimal balance)
        {
            Country = country;
            Balance = balance;
        }
    }
    public class UserDataProvider : IUserDataProvider
    {
        private static Dictionary<String, UserDetails> Database = new Dictionary<string, UserDetails>();
        internal UserDataProvider()
        {
            //i do weird stuff on creation only my assembly knows....it's dangerous to create me elsewhere
        }
        static UserDataProvider()
        {
            Random rnd = new Random();
            decimal balance = rnd.Next(100, 200);
            Database["akivranoglou@gmail.com"] = new UserDetails("gr", balance);
            //throw new Exception("Cannot connect to db");
        }
        public bool WithdrawMoney(decimal amount, string username)
        {
            Database[username].Balance -= amount;
            return true;
        }
        public decimal GetBalance(string username)
        {
            return Database[username].Balance;
        }
        public string GetUserCountry(string username)
        {
            return Database[username].Country;
        }
    }
}
