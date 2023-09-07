using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchService.Models
{
    public class SearchEngine
    {
        public int Id { get; set; }

        public string Name { get; set; }    
        public string BaseUrl { get; set; }

        public string? regexPattern { get; set; } 
    }
}
