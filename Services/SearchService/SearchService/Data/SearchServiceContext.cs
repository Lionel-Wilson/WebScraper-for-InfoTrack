using Microsoft.EntityFrameworkCore;
using SearchService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchService.Data
{
    public class SearchServiceContext :DbContext
    {
        public DbSet<SearchEngine> SearchEngines { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\PracticeProjectsDb;Database=SearchDB;trusted_connection=true;");
        }
    }
}
