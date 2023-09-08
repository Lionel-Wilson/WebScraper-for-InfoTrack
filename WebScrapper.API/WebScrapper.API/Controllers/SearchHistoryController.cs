using Microsoft.AspNetCore.Mvc;
using SearchService.Interfaces;
using SearchHistoryService.Interfaces;
using SearchHistoryService.Models;

namespace WebScrapper.API.Controllers
{
    public class SearchHistoryController : Controller
    {
     
        private readonly ISearchHistoryService _searchHistoryService;

        public SearchHistoryController(ISearchHistoryService searchHistoryService)
        {
            _searchHistoryService = searchHistoryService;
        }

        [HttpGet("History")]
        public List<SearchHistory>? GetSearchHistory()
        {
            return _searchHistoryService.GetSearchHistory();
        }
        
    }
}
