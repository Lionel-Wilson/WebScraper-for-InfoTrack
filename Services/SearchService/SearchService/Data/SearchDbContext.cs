using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SearchService.Models;

namespace SearchService.Data;

public partial class SearchDbContext : DbContext
{
    public SearchDbContext()
    {
    }

    public SearchDbContext(DbContextOptions<SearchDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<SearchEngine> SearchEngines { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\SQLEXPRESS;Initial Catalog=SearchDB;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SearchEngine>(entity =>
        {
            entity.ToTable("SearchEngine");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
