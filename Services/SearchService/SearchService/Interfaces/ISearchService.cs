using SearchService.Models;

namespace SearchService.Interfaces
{
    public interface ISearchService
    {
        public List<int>? WebScrapper(string keywords, int searchEngineId);
        public List<SearchEngine> getSearchEngines();
    }
}
