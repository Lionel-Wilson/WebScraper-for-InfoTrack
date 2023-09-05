using Microsoft.AspNetCore.Mvc;

namespace WebScrapper.API.Controllers
{
    public class SearchController : Controller
    {
        [HttpGet("Search")]
        public string SearchWeb([FromBody] string keywords, string url)
        {
            return "test";
        }
    }

}

