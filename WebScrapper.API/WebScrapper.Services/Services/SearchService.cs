namespace WebScrapper.Services.Services
{
    public class SearchService
    {
        public string? WebScrapper(string keywords, string url)
        {
            if (url == "Google")
            {
                var keywordsToSearchFor = keywordFormatter(keywords);
                var baseUrl = "https://www.google.co.uk/search?num=100&q=" + keywordsToSearchFor;
                var httpClient = new HttpClient();

                var html = httpClient.GetStringAsync(baseUrl).Result;

                return html;
            }
            else
            {
                return null;
            }

        }

        private string keywordFormatter(string keyword)
        {
            return keyword.Replace(" ", "+");
        }
    }
}
