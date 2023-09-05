using WebScrapper.Services;

namespace WebScrapper.Tests
{
    public class WebScrapperSearchTests
    {
        private _searchService;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("land registry search", "Google")];
        [TestCase("land registry search", "Bing")];
        public async void Should_Be_Able_To_Search_Web_Via_Search_Engine(string keywords, string url)
        {
            await Assert.IsNotNull()
        }
    }
}