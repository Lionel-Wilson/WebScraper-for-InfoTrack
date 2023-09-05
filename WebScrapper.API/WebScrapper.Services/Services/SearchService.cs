﻿using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;
using System.Web;
using WebScrapper.Services.Interfaces;

namespace WebScrapper.Services.Services
{
    public class SearchService: ISearchService
    {
        public List<int>? WebScrapper(string keywords, string url)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    if (url == "Google")
                    {
                        var keywordsToSearchFor = keywordFormatter(keywords);
                        var baseUrl = "https://www.google.co.uk/search?num=100&q="; //Todo - Make Search Engine Model
                        var searchUrl = baseUrl + keywordsToSearchFor;

          
                        httpClient.DefaultRequestHeaders.Add("Cookie", "CONSENT=YES+42");
                        string response = HttpUtility.HtmlDecode(httpClient.GetStringAsync(searchUrl).Result);
                        var links = extractLinksFromResponse(response);
                        var rankingList = (from link in links where link.Contains("www.infotrack.co.uk", StringComparison.OrdinalIgnoreCase) select links.IndexOf(link)).Distinct().ToList();

         
                        return rankingList;
                    }
                    else
                    {
                        return null;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return null;

        }

        private string keywordFormatter(string keyword)
        {
            return keyword.Replace(" ", "+");
        }

        private List<string> extractLinksFromResponse(string response) //To-do add pattern as a parameter after you make the models.
        {
            List<string> links = new List<string>();

            // Define the regular expression pattern to match URLs
            string pattern = @"/url\?q=(.*?)&sa=U&ved="; 

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
    }
    }

