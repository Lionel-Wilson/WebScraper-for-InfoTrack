using Microsoft.AspNetCore.Mvc;

namespace WebScrapper.API.Controllers
{
    public class SearchHistoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
