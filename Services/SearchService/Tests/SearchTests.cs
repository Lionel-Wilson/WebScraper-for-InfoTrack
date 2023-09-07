using SearchService.Implementations;

namespace Tests
{
    public class Tests
    {
        private SearchService.Implementations.SearchService _searchService;
        [SetUp]
        public void Setup()
        {
            _searchService = new SearchService.Implementations.SearchService();
        }

        [Test]
        [TestCase("land registry search", 1)]
        [TestCase("infotrack", 1)]
        public async Task Should_Be_Able_To_Search_Web_Via_Search_Engine(string keywords, int searchEngineId)
        {
            var result = new List<int>();

            result = _searchService.WebScrapper(keywords, searchEngineId);


            if(result != null){
                for (int i = 0; i < result.Count; i++)
                {
                    Console.WriteLine(result[i]);
                }
            }

            Assert.IsNotEmpty(result);
        }
    }
}