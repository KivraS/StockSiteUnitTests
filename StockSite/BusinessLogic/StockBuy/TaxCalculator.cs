using System.Diagnostics.Metrics;

namespace StockSite.BusinessLogic.StockBuy
{
    public class TaxCalculator
    {
        //Tax per country is 10% for gr , 20% for ro , 30% for cy. Tax doubles if amount is >100
        public static decimal CalculateTax(decimal amount,string username)
        {
            string country = new UserDataProvider().GetUserCountry(username);
            decimal multiplier = amount >= 100 ? 2 : 1;
            decimal factor = 0;
            if (country == "gr")
                factor = 0.1m;
            else if (country == "ro")
                factor = 0.2m;
            else if (country == "cy")
                factor = 0.3m;
            else
                throw new NotImplementedException();

            return factor * multiplier * amount;
        }
    }
}
