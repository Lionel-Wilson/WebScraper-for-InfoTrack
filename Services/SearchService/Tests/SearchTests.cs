using SearchService.Implementations;
using SearchHistoryService.Implementations;
using SearchHistoryService.Interfaces;
using SearchService.Models;
namespace Tests
{
    public class Tests
    {
        private SearchService.Implementations.SearchService _searchService;
        private SearchHistoryService.Implementations.SearchHistoryService _searchHistoryService;

        [SetUp]
        public void Setup()
        {
            _searchHistoryService = new SearchHistoryService.Implementations.SearchHistoryService();    
            _searchService = new SearchService.Implementations.SearchService(_searchHistoryService);
        }

        [Test]
        [TestCase("land registry search", 1)]
        [TestCase("infotrack", 1)]
        public async Task Should_Be_Able_To_Search_Web_Via_Search_Engine(string keywords, int searchEngineId)
        {
            var result = new List<int>();

            result = _searchService.WebScrapper(keywords, searchEngineId);


            if(result != null && result.Count > 0)
            {
                for (int i = 0; i < result.Count; i++)
                {
                    Console.WriteLine(result[i]);
                }
            }

            Assert.IsTrue(result != null && result.Count > 0);
        }

        [Test]
        public void Should_Be_Able_To_Get_Search_Engines()
        {
            var result = new List<SearchEngine>();

            result = _searchService.getSearchEngines();

            if (result != null && result.Count > 0)
            {
                for (int i = 0; i < result.Count; i++)
                {
                    Console.WriteLine(result[i].Name);
                }
            }

            Assert.IsNotEmpty(result);
        }
    }
}