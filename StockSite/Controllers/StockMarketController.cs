using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockSite.BusinessLogic.StockBuy;

namespace StockSite.Controllers
{
    [Authorize]
    public class StockMarketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult PurchaseStock(int stockId,decimal amount)
        {
            StockPurchaseHandler handler = new StockPurchaseHandler();
            string? username = HttpContext?.User?.Identity?.Name;
            var result = handler.BuyStock(amount, stockId, username);
            return Json("Success = "+ result);
        }
    }
}
