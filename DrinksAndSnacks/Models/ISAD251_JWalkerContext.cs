using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DrinksAndSnacks.Models
{
    public partial class ISAD251_JWalkerContext : DbContext
    {
        public ISAD251_JWalkerContext()
        {
        }

        public ISAD251_JWalkerContext(DbContextOptions<ISAD251_JWalkerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<OrderItems> OrderItems { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Products> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=socem1.uopnet.plymouth.ac.uk;Database=ISAD251_JWalker;User Id=JWalker; Password=ISAD251_22205400");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItems>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId })
                    .HasName("pk_Order_Items");

                entity.ToTable("Order_Items");

                entity.Property(e => e.OrderId).HasColumnName("Order_Id");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("pk_Orders");

                entity.Property(e => e.OrderId).HasColumnName("Order_Id");

                entity.Property(e => e.OrderTime)
                    .HasColumnName("Order_Time")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.TableNumber).HasColumnName("Table_Number");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("pk_Products");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.ProductName)
                    .HasColumnName("Product_Name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ReOrderLevel).HasColumnName("Re_Order_Level");

                entity.Property(e => e.StockLevel).HasColumnName("Stock_Level");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
