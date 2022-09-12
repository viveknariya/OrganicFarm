using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OrganicFarm.Models
{
    public partial class ShopContext : DbContext
    {
        //public ShopContext()
        //{
        //}

        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<OrganicProduct> OrganicProduct { get; set; }
        public virtual DbSet<OrganicShop> OrganicShop { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<TblRole> TblRole { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string,
//you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263
//for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=C1JUN22; User Id = sa; Password=pass@word1; Database = Shop;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrganicProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__OrganicP__B40CC6CD33220930");

                entity.Property(e => e.ExpiryDate).HasColumnType("date");

                entity.Property(e => e.Price).HasMaxLength(50);

                entity.Property(e => e.ProductName).HasMaxLength(50);

                entity.Property(e => e.ProductType).HasMaxLength(50);

                entity.HasOne(d => d.OrganicShop)
                    .WithMany(p => p.OrganicProduct)
                    .HasForeignKey(d => d.OrganicShopId)
                    .HasConstraintName("FK__OrganicPr__Organ__398D8EEE");
            });

            modelBuilder.Entity<OrganicShop>(entity =>
            {
                entity.HasKey(e => e.ShopId)
                    .HasName("PK__OrganicS__67C557C9032E3CEC");

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.ShopAddress).HasMaxLength(50);

                entity.Property(e => e.ShopName).HasMaxLength(50);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.EmailId).HasMaxLength(50);

                entity.Property(e => e.PersonName).HasMaxLength(50);

                entity.Property(e => e.Ppassword)
                    .HasColumnName("PPassword")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Person__RoleId__3E52440B");
            });

            modelBuilder.Entity<TblRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__tblRole__8AFACE1AECC13967");

                entity.ToTable("tblRole");

                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
