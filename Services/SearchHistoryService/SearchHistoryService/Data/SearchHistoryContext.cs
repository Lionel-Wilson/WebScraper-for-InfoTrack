using Microsoft.EntityFrameworkCore;
using SearchHistoryService.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SearchHistoryService.Data
{
    public class SearchHistoryContext : DbContext
    {
        public DbSet<SearchHistory> SearchHistories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\SQLEXPRESS;Database=SearchDB;trusted_connection=true;");
        }


    }
}
