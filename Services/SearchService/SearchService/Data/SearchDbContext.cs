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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\PracticeProjectsDb;Initial Catalog=SearchDB;Integrated Security=True;");

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
