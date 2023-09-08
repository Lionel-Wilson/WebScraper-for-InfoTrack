using SearchHistoryService.Data;
using SearchHistoryService.Implementations;
namespace Test
{
    public class Tests
    {

        private SearchHistoryService.Implementations.SearchHistoryService _searchHistoryService;

        [SetUp]
        public void Setup()
        {
            _searchHistoryService = new SearchHistoryService.Implementations.SearchHistoryService();

        }

        [Test]
        [TestCase("land registry search", 1,"78,9")]
        [TestCase("infotrack", 1,"699,976")]
        public void Should_Be_Able_To_Add_To_Search_History(string keywords, int searchEngineId, string ranking)
        {

            _searchHistoryService.addToSearchHistory(keywords, searchEngineId, ranking);

            using SearchHistoryContext searchHistoryContext = new SearchHistoryContext();

            var SearchHistory = searchHistoryContext.SearchHistories.Where(history => history.Keywords.Contains(keywords) && history.Ranking.Contains(ranking) && history.SearchEngineId.Equals(searchEngineId));
            Assert.NotNull(SearchHistory);




        }
    }
}