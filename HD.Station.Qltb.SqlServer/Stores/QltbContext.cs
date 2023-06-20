using Microsoft.EntityFrameworkCore;
using HD.Station.Qltb.Abstractions.Data;

namespace HD.Station.Qltb.SqlServer
{
    public class QltbContext : DbContext
    {
        public QltbContext(DbContextOptions<QltbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
            .HasIndex(u => u.Email).IsUnique();

            modelBuilder.Entity<Thietbi>(entity =>
            {
                entity.HasKey(k => k.Matb);
                entity.HasOne<Donvi>(s => s.Donvi).WithMany(b => b.Thietbis).HasForeignKey(p => p.Madv);
                entity.HasOne<Loaithietbi>(s => s.Loaithietbi).WithMany(b => b.Thietbis).HasForeignKey(p => p.Maloai);
            });

            modelBuilder.Entity<Donvi>(entity =>
            {
                entity.HasKey(k => k.Madv);
                entity.HasMany(e => e.Thietbis);
            });
            modelBuilder.Entity<Loaithietbi>(entity =>
            {
                entity.HasKey(k => k.Maloai);
                entity.ToTable("Loaithietbi");
                //entity.HasMany(e => e.Thietbis);

                entity.Property(e => e.Danhmuc).HasMaxLength(30);
                entity.Property(e => e.Ghichu).HasMaxLength(30);
                entity.Property(e => e.Tenloai).HasMaxLength(30);
            });
        }

        public DbSet<Thietbi> Thietbi { get; set; }
        public DbSet<Donvi> Donvi { get; set; }
        public DbSet<Loaithietbi> Loaithietbi { get; set; }
        public DbSet<User> User { get; set; }
    }
}
