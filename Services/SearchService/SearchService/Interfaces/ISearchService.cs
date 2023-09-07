namespace SearchService.Interfaces
{
    public interface ISearchService
    {
        List<int>? WebScrapper(string keywords, int searchEngineId);
    }
}
