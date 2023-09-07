using Microsoft.EntityFrameworkCore;
using SearchHistoryService.Models;
using SearchService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchService.Models;

namespace SearchHistoryService.Data
{
    public class SearchHistoryContext : DbContext
    {
        public DbSet<SearchHistory> SearchHistories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\PracticeProjectsDb;Database=SearchDB;trusted_connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SearchHistory>()
                .HasOne(e => e.SearchEngine)
                .WithMany()
                .HasForeignKey(e => e.SearchEngineId)
                .IsRequired();
        }
    }
}
