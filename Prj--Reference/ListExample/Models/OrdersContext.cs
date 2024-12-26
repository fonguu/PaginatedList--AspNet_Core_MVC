using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ListExample.Models
{
    public partial class OrdersContext : DbContext
    {
        public OrdersContext()
        {
        }

        public OrdersContext(DbContextOptions<OrdersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Test> Tests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Orders;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_Taiwan_Stroke_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Number);

                entity.ToTable("customers");

                entity.Property(e => e.Number)
                    .HasMaxLength(50)
                    .HasColumnName("number");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Tel)
                    .HasMaxLength(50)
                    .HasColumnName("tel");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Number);

                entity.ToTable("orders");

                entity.Property(e => e.Number)
                    .HasMaxLength(50)
                    .HasColumnName("number");

                entity.Property(e => e.CustomerNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("customer_number");

                entity.Property(e => e.CustomerSignature)
                    .HasMaxLength(100)
                    .HasColumnName("customer_signature");

                entity.Property(e => e.ShippingAddress)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("shipping_address");

                entity.Property(e => e.ShippingDate).HasColumnName("shipping_date");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("total");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("order_details");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.OrderNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("order_number");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("price");

                entity.Property(e => e.ProductNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("product_number");

                entity.Property(e => e.Remark)
                    .HasMaxLength(500)
                    .HasColumnName("remark");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("total");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Number);

                entity.ToTable("products");

                entity.Property(e => e.Number)
                    .HasMaxLength(50)
                    .HasColumnName("number");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("price");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.ToTable("test");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.Property(e => e.Type).HasColumnName("type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
