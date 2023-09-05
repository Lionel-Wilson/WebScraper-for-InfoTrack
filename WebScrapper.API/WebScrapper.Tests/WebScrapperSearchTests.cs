using WebScrapper.Services.Services;
using System.Threading.Tasks;

namespace WebScrapper.Tests
{
    public class WebScrapperSearchTests
    {
        private SearchService _searchService;
        [SetUp]
        public void Setup()
        {
            _searchService = new SearchService();
        }

        [Test]
        //[TestCase("land registry search", "Google")]
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