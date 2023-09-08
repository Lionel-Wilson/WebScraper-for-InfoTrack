using Microsoft.AspNetCore.Mvc;
using SearchService.Interfaces;

namespace WebScrapper.API.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet("Search")]
        public List<int>? SearchWeb([FromQuery] string keywords, int searchEngineId)
        {
            return _searchService.WebScrapper(keywords, searchEngineId);
        }
    }

}

