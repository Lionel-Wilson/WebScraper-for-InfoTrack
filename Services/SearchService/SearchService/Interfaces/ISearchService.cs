namespace SearchService.Interfaces
{
    public interface ISearchService
    {
        public List<int>? WebScrapper(string keywords, int searchEngineId);
    }
}
