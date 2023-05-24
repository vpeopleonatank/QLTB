using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QLTB.Test_models;

public partial class QltbContext : DbContext
{
    public QltbContext()
    {
    }

    public QltbContext(DbContextOptions<QltbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Donvi> Donvis { get; set; }

    public virtual DbSet<Loaithietbi> Loaithietbis { get; set; }

    public virtual DbSet<Thietbi> Thietbis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:QLTBContext");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Donvi>(entity =>
        {
            entity.HasKey(e => e.Madv).HasName("PK__Donvi__272379DF4863E338");

            entity.ToTable("Donvi");

            entity.Property(e => e.Tendv).HasMaxLength(30);
        });

        modelBuilder.Entity<Loaithietbi>(entity =>
        {
            entity.HasKey(e => e.Maloai).HasName("PK__Loaithie__3E1DB46D6C48EED1");

            entity.ToTable("Loaithietbi");

            entity.Property(e => e.Danhmuc).HasMaxLength(30);
            entity.Property(e => e.Ghichu).HasMaxLength(30);
            entity.Property(e => e.Tenloai).HasMaxLength(30);
        });

        modelBuilder.Entity<Thietbi>(entity =>
        {
            entity.HasKey(e => e.Matb).HasName("PK__Thietbi__272404378C25F77C");

            entity.ToTable("Thietbi");

            entity.Property(e => e.Nuocsx).HasMaxLength(15);
            entity.Property(e => e.Tentb).HasMaxLength(30);

            entity.HasOne(d => d.MadvNavigation).WithMany(p => p.Thietbis)
                .HasForeignKey(d => d.Madv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Thietbi__Madv__286302EC");

            entity.HasOne(d => d.MaloaiNavigation).WithMany(p => p.Thietbis)
                .HasForeignKey(d => d.Maloai)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Thietbi__Maloai__29572725");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
