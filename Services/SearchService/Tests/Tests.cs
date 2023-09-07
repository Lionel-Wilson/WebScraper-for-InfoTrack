using SearchService.Implementations;
namespace SearchServiceTests
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
        [TestCase("land registry search", "Google")]
        [TestCase("infotrack", "Google")]
        public async Task Should_Be_Able_To_Search_Web_Via_Search_Engine(string keywords, string url)
        {
            var result = new List<int>();

            result = _searchService.WebScrapper(keywords, url);


            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine(result[i]);
            }

            Assert.IsNotEmpty(result);
        }
    }
}