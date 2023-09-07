using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchService.Models;

namespace SearchHistoryService.Models
{
    public class SearchHistory
    {
        public int Id { get; set; }

        public string Keywords { get; set; }
        public string SearchEngineId { get; set; }
        public SearchEngine SearchEngine { get; set; } = null!;

        public string Ranking { get; set; }

        public DateTime SearchDate { get; set; }
    }
}
