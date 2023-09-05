namespace WebScrapper.Services.Interfaces
{
    public interface ISearchService
    {
        List<int>? WebScrapper(string keywords, string url);
    }
}
