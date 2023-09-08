using SearchHistoryService.Data;
using SearchHistoryService.Interfaces;
using SearchHistoryService.Models;

namespace SearchHistoryService.Implementations
{
    public class SearchHistoryService: ISearchHistoryService
    {
        
        public List<SearchHistory> GetSearchHistory()
        {
            using SearchHistoryContext searchHistoryContext = new SearchHistoryContext();

            var SearchHistory = searchHistoryContext.SearchHistories.ToList();

            return SearchHistory;

        }

        public void addToSearchHistory(string keywords, int searchEngineId, string ranking)
        {
            using (var searchHistoryContext = new SearchHistoryContext())
            {
                SearchHistory newSearchHistory = new SearchHistory()
                {
                    Keywords = keywords,
                    SearchEngineId = searchEngineId,
                    Ranking = ranking,
                    SearchDate = DateTime.Now,
                };

                searchHistoryContext.Add(newSearchHistory);
                searchHistoryContext.SaveChanges();
            }
        }




    }
}