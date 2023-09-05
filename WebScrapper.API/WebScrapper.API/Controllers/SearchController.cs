using Microsoft.AspNetCore.Mvc;

namespace WebScrapper.API.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
