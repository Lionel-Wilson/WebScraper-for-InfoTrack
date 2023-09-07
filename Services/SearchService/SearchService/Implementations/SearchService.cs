using System.Text.RegularExpressions;
using System.Web;
using SearchService.Data;
using SearchService.Interfaces;
using SearchService.Models;

namespace SearchService.Implementations
{
    public class SearchService: ISearchService
    {
        public List<int>? WebScrapper(string keywords, int searchEngineId)
        {
            try
            {
                SearchEngine searchEngine = getSearchEnginebyId(searchEngineId);
                using (HttpClient httpClient = new HttpClient())
                {
 
                    var keywordsToSearchFor = keywordFormatter(keywords);
                    var baseUrl = searchEngine.BaseUrl;
                    var searchUrl = baseUrl + keywordsToSearchFor;

                    //Make search request
                    httpClient.DefaultRequestHeaders.Add("Cookie", searchEngine.HeaderValue);
                    string response = HttpUtility.HtmlDecode(httpClient.GetStringAsync(searchUrl).Result);

                    //Extract links and create Ranking List
                    var links = extractLinksFromResponse(searchEngine, response);
                    var rankingList = (from link in links where link.Contains("www.infotrack.co.uk", StringComparison.OrdinalIgnoreCase) select links.IndexOf(link)).Distinct().ToList();
                    rankingList = convertToRankedList(rankingList);

                    return rankingList;
            
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return null;

        }

        private SearchEngine getSearchEnginebyId(int searchEngineId)
        {
            using SearchServiceContext searchServiceContext = new SearchServiceContext();

            var searchEngine = searchServiceContext.SearchEngines.Where(searchEngine => searchEngine.Id == searchEngineId).First();
            
            return searchEngine;
        }

        private string keywordFormatter(string keyword)
        {
            return keyword.Replace(" ", "+");
        }

        private List<string> extractLinksFromResponse(SearchEngine searchEngine,string response) //To-do add pattern as a parameter after you make the models.
        {
            List<string> links = new List<string>();

            // Define the regular expression pattern to match URLs
            string pattern = @$"{searchEngine.RegexPattern}";

            // Create a regular expression object
            Regex regex = new Regex(pattern);

            // Match URLs in the HTML response
            MatchCollection matches = regex.Matches(response);

            // Extract and add matched URLs to the list
            foreach (Match match in matches)
            {
                string url = match.Groups[1].Value;
                links.Add(Uri.UnescapeDataString(url)); // Unescape URL encoding
            }

            return links;
        }

        private List<int> convertToRankedList(List<int> listOfIndexes)
        {
            List<int> rankedList = new List<int>();
            if (listOfIndexes.Count > 0)
            {
                // Increase each number in the list by 1
                for (int i = 0; i < listOfIndexes.Count; i++)
                {
                    listOfIndexes[i] += 1;
                }
                rankedList = listOfIndexes;

                return rankedList;
            }
            else
            {
                rankedList = new List<int>() { 0 };
                return rankedList;
            }

        }
    }
}