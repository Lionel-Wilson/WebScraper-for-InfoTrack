using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchHistoryService.Models;

namespace SearchHistoryService.Models
{
    public class SearchHistory
    {
        public int Id { get; set; }

        public string Keywords { get; set; }
        public int SearchEngineId { get; set; }

        public string Ranking { get; set; }

        public DateTime SearchDate { get; set; }
    }
}
