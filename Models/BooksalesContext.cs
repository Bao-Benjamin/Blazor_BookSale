using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorBookSale.Models;

public partial class BooksalesContext : DbContext
{
    public BooksalesContext()
    {
    }

    public BooksalesContext(DbContextOptions <BooksalesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booksale> Booksales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseMySQL("server=localhost; database=booksales; uid=root; password=root;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booksale>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("booksale");

            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.SaleId).HasColumnName("saleID");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
