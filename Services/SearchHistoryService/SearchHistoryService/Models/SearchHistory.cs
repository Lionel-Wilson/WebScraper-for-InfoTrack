using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchHistoryService.Models
{
    public class SearchHistory
    {
        public int Id { get; set; }

        public string Keywords { get; set; }
        public string SearchEngineId { get; set; }
        public string Ranking { get; set; }

        public DateTime SearchDate { get; set; }
    }
}
