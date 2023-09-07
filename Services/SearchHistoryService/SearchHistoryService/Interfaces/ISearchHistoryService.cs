using SearchHistoryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchHistoryService.Interfaces
{
    public interface ISearchHistoryService
    {
        public List<SearchHistory> GetSearchHistory();
        public void addToSearchHistory(string keywords, int searchEngineId, string ranking);
    }
}
