using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BrewBlissInfo.Models;

public partial class BrewBlissInfoDbContext : DbContext
{
    public BrewBlissInfoDbContext()
    {
    }

    public BrewBlissInfoDbContext(DbContextOptions<BrewBlissInfoDbContext> options)
        : base(options)
    {
    }

    public  DbSet<CategoryInfo> CategoryInfos { get; set; }

    public DbSet<MenuItemDetail> MenuItemDetails { get; set; }

    public DbSet<MessageFeedback> MessageFeedbacks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=BrewBlissInfoDB;User Id=sa;Password=Carol@2006;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
modelBuilder.Entity<CategoryInfo>(entity =>
{
    entity.HasKey(e => e.Id).HasName("PK__Category__3214EC07A763DBE7");

    entity.ToTable("CategoryInfo");

    entity.Property(e => e.CategoryInfoName)
        .HasMaxLength(100)
        .IsRequired();
});

        modelBuilder.Entity<MenuItemDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MenuItem__3214EC0755DDE07B");

            entity.Property(e => e.Ingredients).HasMaxLength(255);
            entity.Property(e => e.NameItem).HasColumnName("NameItem");
        });

        modelBuilder.Entity<MessageFeedback>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MessageF__3214EC078D6FA600");

            entity.ToTable("MessageFeedback");

            entity.Property(e => e.AdminResponse).HasMaxLength(1000);
            entity.Property(e => e.ReviewedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
