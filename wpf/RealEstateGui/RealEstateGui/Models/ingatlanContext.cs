using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RealEstateGui.Models
{
    public partial class ingatlanContext : DbContext
    {
        public ingatlanContext()
        {
        }

        public ingatlanContext(DbContextOptions<ingatlanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Realestate> Realestates { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=ingatlan;uid=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.18-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_hungarian_ci");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_hungarian_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Realestate>(entity =>
            {
                entity.ToTable("realestates");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_hungarian_ci");

                entity.HasIndex(e => e.CategoryId, "FK_realestates_categoryId");

                entity.HasIndex(e => e.SellerId, "FK_realestates_sellerId");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Area)
                    .HasColumnType("int(11)")
                    .HasColumnName("area");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("categoryId");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("date")
                    .HasColumnName("createAt");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Floors)
                    .HasColumnType("int(11)")
                    .HasColumnName("floors")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Freeofcharge).HasColumnName("freeofcharge");

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("imageUrl");

                entity.Property(e => e.Latlong)
                    .HasMaxLength(50)
                    .HasColumnName("latlong");

                entity.Property(e => e.Rooms)
                    .HasColumnType("int(11)")
                    .HasColumnName("rooms")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.SellerId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("sellerId");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Realestates)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_realestates_categoryId");

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.Realestates)
                    .HasForeignKey(d => d.SellerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_realestates_sellerId");
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.ToTable("sellers");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_hungarian_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .HasColumnName("phone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
