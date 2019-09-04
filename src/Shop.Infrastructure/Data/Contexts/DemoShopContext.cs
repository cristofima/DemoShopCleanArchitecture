using Microsoft.EntityFrameworkCore;
using Shop.Core.Entities;

namespace Shop.Infrastructure
{
    public class DemoShopContext : DbContext
    {
        public DemoShopContext()
        {
        }

        public DemoShopContext(DbContextOptions<DemoShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Productos> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=DemoShop;User ID=sa;Password=coronadoserver2018;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Productos>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__Producto__40F9A2077F076D42");

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasColumnName("marca")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioUnitario)
                    .HasColumnName("precioUnitario")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("tipo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Unidades)
                    .IsRequired()
                    .HasColumnName("unidades")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });
        }
    }
}